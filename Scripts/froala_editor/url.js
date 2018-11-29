/*!
 * froala_editor v2.9.1 (https://www.froala.com/wysiwyg-editor)
 * License https://froala.com/wysiwyg-editor/terms/
 * Copyright 2014-2018 Froala Labs
 */

!function(t){"function"==typeof define&&define.amd?define(["jquery"],t):"object"==typeof module&&module.exports?module.exports=function(e,n){return n===undefined&&(n="undefined"!=typeof window?require("jquery"):require("jquery")(e)),t(n)}:t(window.jQuery)}(function(f){f.FE.URLRegEx="(^| |\\u00A0)("+f.FE.LinkRegEx+"|([a-z0-9+-_.]{1,}@[a-z0-9+-_.]{1,}\\.[a-z0-9+-_]{1,}))$",f.FE.PLUGINS.url=function(i){var l=null;function n(e,n,t){for(var r="";t.length&&"."==t[t.length-1];)r+=".",t=t.substring(0,t.length-1);var o=t;if(i.opts.linkConvertEmailAddress)i.helpers.isEmail(o)&&!/^mailto:.*/i.test(o)&&(o="mailto:"+o);else if(i.helpers.isEmail(o))return n+t;return/^((http|https|ftp|ftps|mailto|tel|sms|notes|data)\:)/i.test(o)||(o="//"+o),(n||"")+"<a"+(i.opts.linkAlwaysBlank?' target="_blank"':"")+(l?' rel="'+l+'"':"")+' data-fr-linked="true" href="'+o+'">'+t.replace(/&amp;/g,"&").replace(/&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;")+"</a>"+r}function a(){return new RegExp(f.FE.URLRegEx,"gi")}function s(e){return i.opts.linkAlwaysNoFollow&&(l="nofollow"),i.opts.linkAlwaysBlank&&(i.opts.linkNoOpener&&(l?l+=" noopener":l="noopener"),i.opts.linkNoReferrer&&(l?l+=" noreferrer":l="noreferrer")),e.replace(a(),n)}function p(e){var n=e.split(" ");return n[n.length-1]}function t(){var n=i.selection.ranges(0),t=n.startContainer;if(!t||t.nodeType!==Node.TEXT_NODE||n.startOffset!==(t.textContent||"").length)return!1;if(function e(n){return!!n&&("A"===n.tagName||!(!n.parentNode||n.parentNode==i.el)&&e(n.parentNode))}(t))return!1;if(a().test(p(t.textContent))){f(t).before(s(t.textContent));var r=f(t.parentNode).find("a[data-fr-linked]");r.removeAttr("data-fr-linked"),t.parentNode.removeChild(t),i.events.trigger("url.linked",[r.get(0)])}else if(t.textContent.split(" ").length<=2&&t.previousSibling&&"A"===t.previousSibling.tagName){var o=t.previousSibling.innerText+t.textContent;a().test(p(o))&&(f(t.previousSibling).replaceWith(s(o)),t.parentNode.removeChild(t))}}return{_init:function(){i.events.on("keypress",function(e){!i.selection.isCollapsed()||"."!=e.key&&")"!=e.key&&"("!=e.key||t()},!0),i.events.on("keydown",function(e){var n=e.which;!i.selection.isCollapsed()||n!=f.FE.KEYCODE.ENTER&&n!=f.FE.KEYCODE.SPACE||t()},!0),i.events.on("paste.beforeCleanup",function(e){if(i.helpers.isURL(e)){var n=null;return i.opts.linkAlwaysBlank&&(i.opts.linkNoOpener&&(n?n+=" noopener":n="noopener"),i.opts.linkNoReferrer&&(n?n+=" noreferrer":n="noreferrer")),"<a"+(i.opts.linkAlwaysBlank?' target="_blank"':"")+(n?' rel="'+n+'"':"")+' href="'+e+'" >'+e+"</a>"}})}}}});