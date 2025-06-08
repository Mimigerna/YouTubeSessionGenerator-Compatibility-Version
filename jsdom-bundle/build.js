const fs = require('fs');
const path = require('path');
const ncc = require('@vercel/ncc');
const terser = require('terser');
const zlib = require('zlib')

const outputDir = path.resolve(__dirname, 'dist');
const outputPath = path.resolve(outputDir, 'bundle.js');
const outputCompressedPath = path.resolve(outputDir, 'bundle.compressed.txt');

(async () => {
    console.log("fs: Deleting old bundle...");
    if (fs.existsSync(outputPath))
        fs.unlinkSync(outputPath);
    if (fs.existsSync(outputCompressedPath))
        fs.unlinkSync(outputCompressedPath);

    console.log("ncc: Bundling...");
    const bundle = await ncc("./index.js", {
        cache: false,
        quiet: true,
        minify: true
    });

    console.log("terser: Minifying...");
    const minified = await terser.minify(bundle.code, {
        format: {
            comments: false,
            beautify: false,
        },
        compress: {
            passes: 3,
            unsafe: true,
            unsafe_arrows: true,
            unsafe_comps: true,
            unsafe_Function: true,
            unsafe_math: true,
            unsafe_symbols: true,
            unsafe_methods: true,
            drop_console: true,
            hoist_vars: true,
            hoist_funs: true,
            pure_getters: true,
            reduce_funcs: true,
            reduce_vars: true,
            toplevel: true,
            dead_code: true,
        },
        mangle: {
            toplevel: true,
        },
    });
    const code = minified.code.slice("(()=>{".length, -",module.exports=__webpack_exports__})();".length) + ";";

    console.log("zlib: Compressing...");
    const compressedBuffer = zlib.brotliCompressSync(Buffer.from(code, "utf-8"), { [zlib.constants.BROTLI_PARAM_QUALITY]: 0 })
    const compressedCode = compressedBuffer.toString('base64');

    console.log("fs: Saving...");
    fs.mkdirSync(outputDir, { recursive: true });
    fs.writeFileSync(outputPath, code, "utf8");
    fs.writeFileSync(outputCompressedPath, compressedCode, "utf8");
})();
