function analysis(){var d=$("slid");for(var s=0;s<d.length;s++){var a=$("slid").eq(0);var c=$(a).attr("type");var g=$(a).parent();var q=100;var k=100;var y="";var r="";var B="";var x="";var z=$(a).attr("imgUrl");var h=$(a).attr("width");var l=$(a).attr("height");var m=$(a).attr("linkUrl");var v=$(a).attr("title");var w=$(a).attr("detail");if(z!=null&&typeof(z)!="undefined"){y=z;if(y.substring(y.length-1,y.length)==","){y=y.substring(0,y.length-1)}y=y.split(",")}if(m!=null&&typeof(m)!="undefined"){r=m;if(r.substring(r.length-1,r.length)==","){r=r.substring(0,r.length-1)}r=r.split(",")}if(v!=null&&typeof(v)!="undefined"){B=v;if(B.substring(B.length-1,B.length)==","){B=B.substring(0,B.length-1)}B=B.split(",")}if(w!=null&&typeof(w)!="undefined"){x=w;if(x.substring(x.length-2,x.length)==",$"){x=x.substring(0,x.length-2)}x=x.split(",$")}if(h!=null&&typeof(h)!="undefined"){q=h}if(l!=null&&typeof(l)!="undefined"){k=l}switch(c){case"slidA":$(a).remove();var u="";var f="";for(var p=0;p<y.length;p++){if(p==0){u=u+'<span class="curent">'+(p+1)+"</span>";f=f+'<div class="slidItem"><a href="'+r[p]+'" title="'+B[p]+'" target="_blank"><img style="width:'+q+"px; height:"+k+'px;" src="'+y[p]+'"/></a></div>'}else{u=u+"<span>"+(p+1)+"</span>";f=f+'<div style="display:none;" class="slidItem"><a href="'+r[p]+'" title="'+B[p]+'" target="_blank"><img style="width:'+q+"px; height:"+k+'px;" src="'+y[p]+'"/></a></div>'}}g.append('<div class="S_slidA"><div class="slid" style="width:'+q+"px; height:"+k+'px">'+f+'<div class="showNo">'+u+"</div></div></div>");break;case"slidB":$(a).remove();var u="";var f="";var j="";for(var p=0;p<y.length;p++){if(p==0){u=u+'<span class="curent">'+(p+1)+"</span>";f=f+'<div class="slidItem"><a href="'+r[p]+'" title="'+B[p]+'" target="_blank"><img style="width:'+q+"px; height:"+k+'px;" src="'+y[p]+'"/></a></div>';j=j+'<a class="titleItem" href="'+r[p]+'" title="'+B[p]+'">'+B[p]+"</a>"}else{u=u+"<span>"+(p+1)+"</span>";f=f+'<div style="display:none;" class="slidItem"><a href="'+r[p]+'" title="'+B[p]+'" target="_blank"><img style="width:'+q+"px; height:"+k+'px;" src="'+y[p]+'"/></a></div>';j=j+'<a class="titleItem" href="'+r[p]+'" style="display:none;" title="'+B[p]+'">'+B[p]+"</a>"}}g.append('<div class="S_slidB"><div class="slid" style="width:'+q+"px; height:"+k+'px">'+f+'<div class="showNo">'+u+"</div>"+j+"</div></div>");break;case"slidC":$(a).remove();var u="";var f="";var j="";for(var p=0;p<y.length;p++){if(p==0){u=u+'<span class="curent">'+(p+1)+"</span>";f=f+'<div class="slidItem"><a href="'+r[p]+'" title="'+B[p]+'" target="_blank"><img style="width:'+q+"px; height:"+k+'px;" src="'+y[p]+'"/></a></div>';j=j+'<div class="titleItem"><h3><a href="'+r[p]+'" title="'+B[p]+'">'+B[p]+"</a></h3><div>"+x[p]+"</div></div>"}else{u=u+"<span>"+(p+1)+"</span>";f=f+'<div style="display:none;" class="slidItem"><a href="'+r[p]+'" title="'+B[p]+'" target="_blank"><img style="width:'+q+"px; height:"+k+'px;" src="'+y[p]+'"/></a></div>';j=j+'<div class="titleItem" style="display:none;"><h3><a href="'+r[p]+'" title="'+B[p]+'">'+B[p]+"</a></h3><div>"+x[p]+"</div></div>"}}g.append('<div class="S_slidC"><div class="slid" style="width:'+q+"px; height:"+k+'px">'+f+'<div class="showNo">'+u+"</div></div>"+j+"</div>");break;case"slidD":$(a).remove();var t=(q-13)/6;var e='<div class="originalImg" style="width:'+5*t+"px; height:"+k+'px; float:left;"><a href="'+r[0]+'" target="_blank"><img src="'+y[0]+'" style="width:'+5*t+"px; height:"+k+'px;"/></a><a href="'+r[1]+'" style="display:none;" target="_blank"><img src="'+y[1]+'" style="width:'+5*t+"px; height:"+k+'px;"/></a></div>';var b='<div style="float:left; margin-left:7px; width:'+(t+6)+'px;"><ul>';for(var p=0;p<y.length;p++){var A=((k-(13*y.length)+7)/y.length);var o=((k-(13*y.length)+7)/(2*y.length)-3);if(p==0){b=b+'<li style="float:left; position:relative;"><a class="adItem_Selected" style="height:'+A+"px; width:"+t+'px;" number="'+p+'" href="javascript:void(0);" linkUrl="'+r[p]+'"><img style="height:'+A+"px; width:"+t+'px;" src="'+y[p]+'"/></a><div class="arrow" style="top:'+o+'px;"></div></li>'}else{b=b+'<li style="float:left; margin-top:7px; position:relative;"><a class="adItem" number="'+p+'" href="javascript:void(0);" linkUrl="'+r[p]+'"  style="height:'+A+"px; width:"+t+'px;"><img style="height:'+A+"px; width:"+t+'px;" src="'+y[p]+'"/></a></li>'}}b=b+"</ul></div>";g.append('<div class="S_slidD"><div class="slid" style="width:'+q+"px; height:"+k+'">'+e+b+'<div class="clear"></div></div></div>');break;case"slidE":$(a).remove();var t=(q-6)/5;var e='<div class="originalImg" style="width:'+t*3+"px; height:"+(k-6)+'px; float:left; padding:3px;"><a href="'+r[0]+'" target="_blank"><img src="'+y[0]+'" style="width:'+t*3+"px; height:"+(k-6)+'px;"/></a><a href="'+r[1]+'" style="display:none;" target="_blank"><img src="'+y[1]+'" style="width:'+t*3+"px; height:"+(k-6)+'px;"/></a></div>';var b='<div style="float:left; width:'+t*2+'px;"><ul>';for(var p=0;p<y.length;p++){var A=(k-y.length)/y.length;if(p==0){b=b+'<li style="float:left; position:relative;"><a class="adItem_Selected" style="height:'+(A-10)+"px; width:"+(t*2-10)+'px;" number="'+p+'" href="javascript:void(0);" linkUrl="'+r[p]+'" src="'+y[p]+'">'+B[p]+'</a><div class="arrow" style="top:0px;"></div></li>'}else{b=b+'<li style="float:left; position:relative;"><a class="adItem" number="'+p+'" href="javascript:void(0);" linkUrl="'+r[p]+'"  style="height:'+(A-10)+"px; width:"+(t*2-10)+'px;" src="'+y[p]+'">'+B[p]+"</a></li>"}}b=b+"</ul></div>";g.append('<div class="S_slidE"><div class="slid" style="width:'+q+"px; height:"+k+'">'+e+b+'<div class="clear"></div></div></div>');break}}playSlid()}function playSlid(){if($(".S_slidA").length!=0){$(".S_slidA").find(".showNo").find("span").click(function(){var e=parseInt($(this).html());var d=$(this.parentNode.parentNode).find("div[class='slidItem']");var b=$(this.parentNode).find("span");$(b).attr("class","");$(b).eq(e-1).attr("class","curent");if(d.length>1){for(var c=0;c<d.length;c++){if($(d).eq(c).css("display")!="none"){$(d).eq(c).fadeOut("slow")}}$(d).eq(e-1).fadeIn("slow")}});$(".S_slidA").find("div[class='slidItem']").mouseover(function(){clearInterval(a)});$(".S_slidA").find("div[class='slidItem']").mouseout(function(){a=setInterval("autoPlay()",3000)})}if($(".S_slidB").length!=0){$(".S_slidB").find(".showNo").find("span").click(function(){var f=parseInt($(this).html());var e=$(this.parentNode.parentNode).find("div[class='slidItem']");var b=$(this.parentNode).find("span");var d=$(this.parentNode.parentNode).find("a[class='titleItem']");$(b).attr("class","");$(b).eq(f-1).attr("class","curent");if(e.length>1){for(var c=0;c<e.length;c++){if($(e).eq(c).css("display")!="none"){$(e).eq(c).fadeOut("slow");$(d).eq(c).fadeOut("slow")}}$(e).eq(f-1).fadeIn("slow");$(d).eq(f-1).fadeIn("slow")}});$(".S_slidB").find("div[class='slidItem']").mouseover(function(){clearInterval(a)});$(".S_slidB").find("div[class='slidItem']").mouseout(function(){a=setInterval("autoPlay()",3000)})}if($(".S_slidC").length!=0){$(".S_slidC").find(".showNo").find("span").click(function(){var f=parseInt($(this).html());var e=$(this.parentNode.parentNode).find("div[class='slidItem']");var b=$(this.parentNode).find("span");var d=$(this.parentNode.parentNode.parentNode).find("div[class='titleItem']");$(b).attr("class","");$(b).eq(f-1).attr("class","curent");if(e.length>1){for(var c=0;c<e.length;c++){if($(e).eq(c).css("display")!="none"){$(e).eq(c).fadeOut("slow");$(d).eq(c).fadeOut("slow")}}$(e).eq(f-1).fadeIn("slow");$(d).eq(f-1).fadeIn("slow")}});$(".S_slidC").find("div[class='slidItem']").mouseover(function(){clearInterval(a)});$(".S_slidC").find("div[class='slidItem']").mouseout(function(){a=setInterval("autoPlay()",3000)})}if($(".S_slidD").length!=0){$(".S_slidD").find("li").find("a").click(function(){var f=$(this).find("img").attr("src");var d=$(this).attr("linkUrl");var b="";var g=parseInt($(this).attr("number"));if($(".S_slidD").find("li").find("a").length>1){for(var c=0;c<$(".S_slidD").find("li").find("a").length;c++){$(".S_slidD").find("li").find("a").eq(c).attr("class","adItem")}$(".S_slidD").find("li").find("a").eq(g).attr("class","adItem_Selected");for(var c=0;c<$(".S_slidD").find("li").length;c++){if($(".S_slidD").find("li").eq(c).find(".arrow").length!=0){b=$(".S_slidD").find("li").eq(c).find(".arrow").eq(0).clone();$(".S_slidD").find("li").eq(c).find(".arrow").remove()}}$(this.parentNode).append(b);var e=$(this.parentNode.parentNode.parentNode.parentNode).find(".originalImg").find("a");for(var c=0;c<e.length;c++){if($(e[c]).css("display")=="none"){$(e[c]).attr("href",d);$(e[c]).find("img").attr("src",f);$(e[c]).fadeIn("show")}else{$(e[c]).fadeOut("show")}}}});$(".S_slidD").find("li").find("a").mouseover(function(){clearInterval(a)});$(".S_slidD").find("li").find("a").mouseout(function(){a=setInterval("autoPlay()",3000)})}if($(".S_slidE").length!=0){$(".S_slidE").find("li").find("a").click(function(){var f=$(this).attr("src");var d=$(this).attr("linkUrl");var b="";var g=parseInt($(this).attr("number"));if($(".S_slidE").find("li").find("a").length>1){for(var c=0;c<$(".S_slidE").find("li").find("a").length;c++){$(".S_slidE").find("li").find("a").eq(c).attr("class","adItem")}$(".S_slidE").find("li").find("a").eq(g).attr("class","adItem_Selected");for(var c=0;c<$(".S_slidE").find("li").length;c++){if($(".S_slidE").find("li").eq(c).find(".arrow").length!=0){b=$(".S_slidE").find("li").eq(c).find(".arrow").eq(0).clone();$(".S_slidE").find("li").eq(c).find(".arrow").remove()}}$(this.parentNode).append(b);var e=$(this.parentNode.parentNode.parentNode.parentNode).find(".originalImg").find("a");for(var c=0;c<e.length;c++){if($(e[c]).css("display")=="none"){$(e[c]).attr("href",d);$(e[c]).find("img").attr("src",f);$(e[c]).fadeIn("show")}else{$(e[c]).fadeOut("show")}}}});$(".S_slidE").find("li").find("a").mouseover(function(){clearInterval(a)});$(".S_slidE").find("li").find("a").mouseout(function(){a=setInterval("autoPlay()",3000)})}var a=setInterval("autoPlay()",3000)}function autoPlay(){if($(".S_slidA").length!=0){var d=$(".S_slidA");for(var b=0;b<d.length;b++){var a=$(".S_slidA").eq(b).find(".showNo").find("span");var c=0;for(var e=0;e<a.length;e++){if($(a).eq(e).attr("class")=="curent"){c=e}}c++;if((c)==a.length){c=0}$(a).eq(c).click()}}if($(".S_slidB").length!=0){var d=$(".S_slidB");for(var b=0;b<d.length;b++){var a=$(".S_slidB").eq(b).find(".showNo").find("span");var c=0;for(var e=0;e<a.length;e++){if($(a).eq(e).attr("class")=="curent"){c=e}}c++;if((c)==a.length){c=0}$(a).eq(c).click()}}if($(".S_slidC").length!=0){var d=$(".S_slidC");for(var b=0;b<d.length;b++){var a=$(".S_slidC").eq(b).find(".showNo").find("span");var c=0;for(var e=0;e<a.length;e++){if($(a).eq(e).attr("class")=="curent"){c=e}}c++;if((c)==a.length){c=0}$(a).eq(c).click()}}if($(".S_slidD").length!=0){var d=$(".S_slidD");for(var b=0;b<d.length;b++){var a=$(".S_slidD").eq(b).find("li").find("a");var c=0;for(var e=0;e<a.length;e++){if($(a).eq(e).attr("class")=="adItem_Selected"){c=e}}c++;if((c)==a.length){c=0}$(a).eq(c).click()}}if($(".S_slidE").length!=0){var d=$(".S_slidE");for(var b=0;b<d.length;b++){var a=$(".S_slidE").eq(b).find("li").find("a");var c=0;for(var e=0;e<a.length;e++){if($(a).eq(e).attr("class")=="adItem_Selected"){c=e}}c++;if((c)==a.length){c=0}$(a).eq(c).click()}}}$(function(){analysis()});
//焦点图 120505
function FocusPic(BigPicID,SmallPicsID,TitleID,MemoID,width,height){this.Data=[];this.ImgLoad=[];this.TimeOut=5000;var isIE=navigator.appVersion.indexOf("MSIE")!=-1?true:false;this.width=width;this.height=height;this.adNum=0;var TimeOutObj;if(!FocusPic.childs){FocusPic.childs=[]};this.showTime=null;this.showSum=10;this.ID=FocusPic.childs.push(this)-1;this.listCode='<span><a href="[$url]" target="_blank"><img src="[$pic]" onmouseover="FocusPic.childs[[$thisId]].select([$num])" alt="[$title]" /></a></span>';this.Add=function(BigPic,SmallPic,Title,Url,Memo){var ls;this.Data.push([BigPic,SmallPic,Title,Url,Memo]);ls=this.ImgLoad.length;this.ImgLoad.push(new Image);this.ImgLoad[ls].src=BigPic};this.TimeOutBegin=function(){clearInterval(TimeOutObj);TimeOutObj=setInterval("FocusPic.childs["+this.ID+"].next()",this.TimeOut)};this.TimeOutEnd=function(){clearInterval(TimeOutObj)};this.select=function(num){if(num>this.Data.length-1){return};if(num==this.adNum){return};this.TimeOutBegin();if(BigPicID){if(this.$(BigPicID)){var aObj=this.$(BigPicID).getElementsByTagName("a")[0];aObj.href=this.Data[num][2];if(this.aImgY){this.aImgY.style.display='none';this.aImg.style.zIndex=0};this.aImgY=this.$('F'+this.ID+'BF'+this.adNum);this.aImg=this.$('F'+this.ID+'BF'+num);clearTimeout(this.showTime);this.showSum=10;this.showTime=setTimeout("FocusPic.childs["+this.ID+"].show()",50)}};if(TitleID){if(this.$(TitleID)){this.$(TitleID).innerHTML="<a href=\""+this.Data[num][2]+"\" target=\"_blank\">"+this.Data[num][3]+"</a>"}};if(MemoID){if(this.$(MemoID)){this.$(MemoID).innerHTML=this.Data[num][4]}};if(SmallPicsID){if(this.$(SmallPicsID)){var sImg=this.$(SmallPicsID).getElementsByTagName("span"),i;for(i=0;i<sImg.length;i++){if(i==num||num==(i-this.Data.length)){sImg[i].className="selected"}else{sImg[i].className=""}}}};if(this.onselect){this.onselect()};this.adNum=num};var absPosition=function(obj,parentObj){var left=obj.offsetLeft,top=obj.offsetTop,tempObj=obj;while(tempObj.id!=document.body&tempObj.id!=document.documentElement&tempObj!=parentObj){tempObj=tempObj.offsetParent;left+=tempObj.offsetLeft;top+=tempObj.offsetTop};return{left:left,top:top}};this.show=function(){this.showSum--;if(this.aImgY){this.aImgY.style.display='block'};this.aImg.style.display='block';if(isIE){this.aImg.style.filter="alpha(opacity=0)";this.aImg.style.filter="alpha(opacity="+(10-this.showSum)*10+")"}else{this.aImg.style.opacity=0;this.aImg.style.opacity=(10-this.showSum)*0.1};if(this.showSum<=0){if(this.aImgY){this.aImgY.style.display='none'};this.aImg.style.zIndex=0;this.aImgY=null}else{this.aImg.style.zIndex=2;this.showTime=setTimeout("FocusPic.childs["+this.ID+"].show()",50)}};this.next=function(){var temp=this.adNum;temp++;if(temp>=this.Data.length){temp=0};this.select(temp)};this.pre=function(){var temp=this.adNum;temp--;if(temp<0){temp=this.Data.length-1};this.select(temp)};this.MInStopEvent=function(ObjID){if(ObjID){if(this.$(ObjID)){if(this.$(ObjID).attachEvent){this.$(ObjID).attachEvent("onmouseover",Function("FocusPic.childs["+this.ID+"].TimeOutEnd()"));this.$(ObjID).attachEvent("onmouseout",Function("FocusPic.childs["+this.ID+"].TimeOutBegin()"))}else{this.$(ObjID).addEventListener("mouseover",Function("FocusPic.childs["+this.ID+"].TimeOutEnd()"),false);this.$(ObjID).addEventListener("mouseout",Function("FocusPic.childs["+this.ID+"].TimeOutBegin()"),false)}}}};this.begin=function(){this.MInStopEvent(TitleID);this.MInStopEvent(SmallPicsID);this.MInStopEvent(BigPicID);this.adNum=-1;var i,temp="";if(BigPicID){if(this.$(BigPicID)){var aObj=this.$(BigPicID).getElementsByTagName("a")[0];aObj.style.zoom=1;this.$(BigPicID).style.position="relative";this.$(BigPicID).style.zoom=1;this.$(BigPicID).style.overflow="hidden";for(i=0;i<this.Data.length;i++){temp+='<img src="'+this.Data[i][0]+'" id="F'+this.ID+'BF'+i+'" style="display:'+(i==0?'block':'none')+'" galleryimg="no"'+(this.width?' width="'+this.width+'"':'')+(this.height?' height="'+this.height+'"':'')+' alt="'+this.Data[i][3]+'" />'};aObj.innerHTML=temp;var imgObjs=aObj.getElementsByTagName("img"),XY=absPosition(imgObjs[0],this.$(BigPicID));for(i=0;i<imgObjs.length;i++){imgObjs[i].style.position="absolute";imgObjs[i].style.top=XY.top+"px";imgObjs[i].style.left=XY.left+"px"}}};if(SmallPicsID){if(this.$(SmallPicsID)){tempHTML="";for(i=0;i<this.Data.length;i++){temp=this.listCode;temp=temp.replace(/\[\$url\]/ig,this.Data[i][2]);temp=temp.replace(/\[\$pic\]/ig,this.Data[i][1]);temp=temp.replace(/\[\$thisId\]/ig,this.ID);temp=temp.replace(/\[\$num\]/ig,i);temp=temp.replace(/\[\$num\+1\]/ig,i+1);temp=temp.replace(/\[\$title\]/ig,this.Data[i][3]);tempHTML+=temp};this.$(SmallPicsID).innerHTML=tempHTML}};this.TimeOutBegin();this.select(0)};this.$=function(objName){if(document.getElementById){return eval('document.getElementById("'+objName+'")')}else{return eval('document.all.'+objName)}}};
