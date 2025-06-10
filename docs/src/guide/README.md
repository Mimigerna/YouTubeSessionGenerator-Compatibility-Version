---
title: Introduction
icon: material-symbols:info
order: 1
---


## About
YouTubeSessionGenerator is a .NET library which allows you to generate valid trusted sessions for the internal YouTube API (InnerTube) including **Visitor Data**, **Proof of Origin Tokens** (PoTokens) & **Rollout Tokens**. Some of these parameters may be required to access certain parts of the InnerTube API.

This library is especially useful for services, automation tools, or projects that require valid authentication for YouTube communication - without the overhead of a full browser environment.


## Session Tokens Explained
The tokens - **Visitor Data**, **Proof of Origin Token** & **Rollout Token** - are part of YouTube's internal session and request validation framework, mostly used by the web and mobile frontends. While not officially documented by Google, through reverese engineering by the community and consistent behavior across endpoints, we can understand what they are and how they work.

### Visitor Data
A unique session identifier assigned to a client.
- Acts a s a kind of session fingerprint.
- Helps YouTube tie requests to a particular anonymous or signed-in user context.
- Appears in the context.client.visitorData field in many internal API payloads.
- Enables personalized recommendations and analytics even before login.

### Proof of Origin Token
A cryptographically signed token issued by YouTube’s [BotGuard](https://botguard.net/en/home) challenge system to prove the client is a legitimate YouTube frontend.
- Verifies request come from a *real* YouTube client (e.g., Chrome browser, Android app, TV).
- *Prevents* abuse from automated tools or unofficial clients.
- May be required when accessing streams from GVS (Google Video Servers), internal player requests or subtitle requests.
- Requires executing a [BotGuard](https://botguard.net/en/home) JavaScript challenge (YouTube’s internal bot detection system).
- Tied to the visitor data and JavaScript interpreter output.

### Rollout Token
An opaque token that controls feature flag rollouts and UI experiment states for a particular client session.
- Enables or disables experimental UI or API behavior on a per-session basis.
- Part of A/B testing infrastructure.
- Without it, you might get different or older behavior/UI from the API.


## Credits
This library would not be possible without the extensive reveres-engineering efforts and research done by the open-source community. Most of the underlying mechanisms used by YouTube's internal APIs were uncovered by talented developers who generously shared their findings.

Special thanks to the following projects and individuals:
- [LuanRT/BgUtils](https://github.com/LuanRT/BgUtils) - for their extensive description of how PoToken are generated.
- [LuanRT/YouTube.js](https://github.com/LuanRT/YouTube.js) - for their detailed understanding of the InnerTube API.
- [yt-dlp](https://github.com/yt-dlp/yt-dlp/wiki/PO-Token-Guide) - for their research of when and where PoTokens are required.
- [Hao Kuang](https://kuangbyte.medium.com/peeking-behind-the-curtain-decoding-youtubes-api-design-through-network-traffic-e3a68463df05) - for their detailed explanation of YouTube's internal API design.


## License
This project is licensed under the [GLP-3.0 license](../license.html).


<!-- ## Content
<Catalog hideHeading="true"/> -->