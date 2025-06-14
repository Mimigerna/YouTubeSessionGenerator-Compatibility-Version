import { hopeTheme } from "vuepress-theme-hope";

import navbar from "./navbar.js";
import sidebar from "./sidebar.js";

export default hopeTheme({
  hostname: "localhost",
  docsDir: "docs/src",

  author: {
    name: "IcySnex",
    url: "https://github.com/IcySnex",
  },
  repo: "IcySnex/YouTubeSessionGenerator",

  iconAssets: "iconify",
  logo: "logo.png",

  navbar,
  sidebar,

  footer: "Made with ♥️ in Germany",
  copyright: "Copyright (C) 2025 IcySnex",
  displayFooter: true,
  breadcrumb: false,

  plugins: {
    search: {
      locales: {
        "/": {
          placeholder: "Search"
        }
      }
    },

    shiki: {
      theme: "min-dark",
      notationHighlight: true
    },

    mdEnhance: {
      align: true,
      attrs: true,
      component: true,
      demo: true,
      include: true,
      mark: true,
      plantuml: true,
      spoiler: true,
      stylize: [
        {
          matcher: "Recommended",
          replacer: ({ tag }) => {
            if (tag === "em")
              return {
                tag: "Badge",
                attrs: { type: "tip" },
                content: "Recommended",
              };
          },
        },
      ],
      sub: true,
      sup: true,
      tasklist: true,
      vPre: true,
    },

    markdownTab: {
      codeTabs: true,
      tabs: true
    }
  }
});
