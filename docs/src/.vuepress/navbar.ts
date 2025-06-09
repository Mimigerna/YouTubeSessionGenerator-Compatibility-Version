import { navbar } from "vuepress-theme-hope";

export default navbar([
  {
    text: "Home",
    icon: "material-symbols:home",
    link: "/",
  },
  {
    text: "Guide",
    icon: "ph:chat-fill",
    link: "/guide/",
    activeMatch: "^/guide/"
  },
  {
    text: "Reference",
    icon: "ooui:reference",
    link: "/reference/",
    activeMatch: "^/reference/",
  }
]);
