/*!
 * froala_editor v2.9.1 (https://www.froala.com/wysiwyg-editor)
 * License https://froala.com/wysiwyg-editor/terms/
 * Copyright 2014-2018 Froala Labs
 */

!function(n){"function"==typeof define&&define.amd?define(["jquery"],n):"object"==typeof module&&module.exports?module.exports=function(e,t){return t===undefined&&(t="undefined"!=typeof window?require("jquery"):require("jquery")(e)),n(t)}:n(window.jQuery)}(function(u){u.extend(u.FE.DEFAULTS,{listAdvancedTypes:!0}),u.FE.PLUGINS.lists=function(d){function c(e){return'<span class="fr-open-'+e.toLowerCase()+'"></span>'}function g(e){return'<span class="fr-close-'+e.toLowerCase()+'"></span>'}function r(e,t){!function(e,t){for(var n=[],a=0;a<e.length;a++){var r=e[a].parentNode;"LI"==e[a].tagName&&r.tagName!=t&&n.indexOf(r)<0&&n.push(r)}for(a=n.length-1;0<=a;a--){var o=u(n[a]);o.replaceWith("<"+t.toLowerCase()+" "+d.node.attributes(o.get(0))+">"+o.html()+"</"+t.toLowerCase()+">")}}(e,t);var n,a=d.html.defaultTag(),r=null;e.length&&(n="rtl"==d.opts.direction||"rtl"==u(e[0]).css("direction")?"margin-right":"margin-left");for(var o=0;o<e.length;o++)if("LI"!=e[o].tagName){var s=d.helpers.getPX(u(e[o]).css(n))||0;(e[o].style.marginLeft=null)===r&&(r=s);var i=0<r?"<"+t+' style="'+n+": "+r+'px;">':"<"+t+">",l="</"+t+">";for(s-=r;0<s/d.opts.indentMargin;)i+="<"+t+">",l+=l,s-=d.opts.indentMargin;a&&e[o].tagName.toLowerCase()==a?u(e[o]).replaceWith(i+"<li"+d.node.attributes(e[o])+">"+u(e[o]).html()+"</li>"+l):u(e[o]).wrap(i+"<li></li>"+l)}d.clean.lists()}function o(e){var t,n;for(t=e.length-1;0<=t;t--)for(n=t-1;0<=n;n--)if(u(e[n]).find(e[t]).length||e[n]==e[t]){e.splice(t,1);break}var a=[];for(t=0;t<e.length;t++){var r=u(e[t]),o=e[t].parentNode,s=r.attr("class");if(r.before(g(o.tagName)),"LI"==o.parentNode.tagName)r.before(g("LI")),r.after(c("LI"));else{var i="";s&&(i+=' class="'+s+'"');var l="rtl"==d.opts.direction||"rtl"==r.css("direction")?"margin-right":"margin-left";d.helpers.getPX(u(o).css(l))&&0<=(u(o).attr("style")||"").indexOf(l+":")&&(i+=' style="'+l+":"+d.helpers.getPX(u(o).css(l))+'px;"'),d.html.defaultTag()&&0===r.find(d.html.blockTagsQuery()).length&&r.wrapInner("<"+d.html.defaultTag()+i+"></"+d.html.defaultTag()+">"),d.node.isEmpty(r.get(0),!0)||0!==r.find(d.html.blockTagsQuery()).length||r.append("<br>"),r.append(c("LI")),r.prepend(g("LI"))}r.after(c(o.tagName)),"LI"==o.parentNode.tagName&&(o=o.parentNode.parentNode),a.indexOf(o)<0&&a.push(o)}for(t=0;t<a.length;t++){var p=u(a[t]),f=p.html();f=(f=f.replace(/<span class="fr-close-([a-z]*)"><\/span>/g,"</$1>")).replace(/<span class="fr-open-([a-z]*)"><\/span>/g,"<$1>"),p.replaceWith(d.node.openTagString(p.get(0))+f+d.node.closeTagString(p.get(0)))}d.$el.find("li:empty").remove(),d.$el.find("ul:empty, ol:empty").remove(),d.clean.lists(),d.html.wrap()}function s(e){d.selection.save();for(var t=0;t<e.length;t++){var n=e[t].previousSibling;if(n){var a=u(e[t]).find("> ul, > ol").last().get(0);if(a){for(var r=u("<li>").prependTo(u(a)),o=d.node.contents(e[t])[0];o&&!d.node.isList(o);){var s=o.nextSibling;r.append(o),o=s}u(n).append(u(a)),u(e[t]).remove()}else{var i=u(n).find("> ul, > ol").last().get(0);if(i)u(i).append(u(e[t]));else{var l=u("<"+e[t].parentNode.tagName+">");u(n).append(l),l.append(u(e[t]))}}}}d.clean.lists(),d.selection.restore()}function i(e){d.selection.save(),o(e),d.selection.restore()}function e(e){if("indent"==e||"outdent"==e){for(var t=!1,n=d.selection.blocks(),a=[],r=0;r<n.length;r++)"LI"==n[r].tagName?(t=!0,a.push(n[r])):"LI"==n[r].parentNode.tagName&&(t=!0,a.push(n[r].parentNode));t&&("indent"==e?s(a):i(a))}}return{_init:function(){d.events.on("commands.after",e),d.events.on("keydown",function(e){if(e.which==u.FE.KEYCODE.TAB){for(var t=d.selection.blocks(),n=[],a=0;a<t.length;a++)"LI"==t[a].tagName?n.push(t[a]):"LI"==t[a].parentNode.tagName&&n.push(t[a].parentNode);if(1<n.length||n.length&&(d.selection.info(n[0]).atStart||d.node.isEmpty(n[0])))return e.preventDefault(),e.stopPropagation(),e.shiftKey?i(n):s(n),!1}},!0)},format:function(e,t){var n,a;for(d.selection.save(),d.html.wrap(!0,!0,!0,!0),d.selection.restore(),a=d.selection.blocks(),n=0;n<a.length;n++)"LI"!=a[n].tagName&&"LI"==a[n].parentNode.tagName&&(a[n]=a[n].parentNode);if(d.selection.save(),function(e,t){for(var n=!0,a=0;a<e.length;a++){if("LI"!=e[a].tagName)return!1;e[a].parentNode.tagName!=t&&(n=!1)}return n}(a,e)?t||o(a):r(a,e),d.html.unwrap(),d.selection.restore(),t=t||"default"){for(a=d.selection.blocks(),n=0;n<a.length;n++)"LI"!=a[n].tagName&&"LI"==a[n].parentNode.tagName&&(a[n]=a[n].parentNode);for(n=0;n<a.length;n++)"LI"==a[n].tagName&&(u(a[n].parentNode).css("list-style-type",t),0===(u(a[n].parentNode).attr("style")||"").length&&u(a[n].parentNode).removeAttr("style"))}},refresh:function(e,t){var n=u(d.selection.element());if(n.get(0)!=d.el){var a=n.get(0);(a="LI"!=a.tagName&&a.firstElementChild&&"LI"!=a.firstElementChild.tagName?n.parents("li").get(0):"LI"==a.tagName||a.firstElementChild?a.firstElementChild&&"LI"==a.firstElementChild.tagName?n.get(0).firstChild:n.get(0):n.parents("li").get(0))&&a.parentNode.tagName==t&&d.el.contains(a.parentNode)&&e.addClass("fr-active")}}}},u.FE.RegisterCommand("formatUL",{title:"Unordered List",type:"button",hasOptions:function(){return this.opts.listAdvancedTypes},options:{"default":"Default",circle:"Circle",disc:"Disc",square:"Square"},refresh:function(e){this.lists.refresh(e,"UL")},callback:function(e,t){this.lists.format("UL",t)},plugin:"lists"}),u.FE.RegisterCommand("formatOL",{title:"Ordered List",hasOptions:function(){return this.opts.listAdvancedTypes},options:{"default":"Default","lower-alpha":"Lower Alpha","lower-greek":"Lower Greek","lower-roman":"Lower Roman","upper-alpha":"Upper Alpha","upper-roman":"Upper Roman"},refresh:function(e){this.lists.refresh(e,"OL")},callback:function(e,t){this.lists.format("OL",t)},plugin:"lists"}),u.FE.DefineIcon("formatUL",{NAME:"list-ul"}),u.FE.DefineIcon("formatOL",{NAME:"list-ol"})});