import { defineUserConfig } from "vuepress";
import theme from "./theme.js";

export default defineUserConfig({
  base: "/YouTubeSessionGenerator/",
  lang: "en-US",

  title: "YouTubeSessionGenerator",
  description: "Generate valid trusted sessions for YouTube including VisitorData, PoTokens & RolloutTokens.",

  head: [
    ["link", { rel: "icon", href: "/YouTubeSessionGenerator/favicon.png" }]
  ],

  theme
});
