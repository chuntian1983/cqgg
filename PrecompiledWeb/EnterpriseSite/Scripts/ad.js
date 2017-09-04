
var ad=Class.create();
ad.prototype={
	initialize:function(ads){
		this.ads=ads;
		this.popWinCount=0;
		this.popWinName='popad';
		this.picPath='pic/original/';
		this.scrollY=200;
		this.delta=0.15;
		this.createAD();
	},
	
    createAD:function(){
        $A(this.ads).each(function(item){
            switch(item.state)
            {
                case '3':this.popWin(item);break;
                case '4':this.leftPair(item);break;
                case '5':this.rightPair(item);break;
                case '6':this.leftScroll(item);break;
                case '7':this.rightScroll(item);break;
                case '8':this.floatAd(item);break;
                default:break;
            }}.bind(this));
	
    },
    
    popWin:function(ad){
        window.open('popad.aspx?adID='+ad.adid,this.popWinName+(this.popWinCount++),
            'toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=0,resizable=no,width=80,height=60,top=0,left=0');
    },
    
    leftPair:function(ad){
        var arr=[];
        arr.push('<div style="position: absolute;  z-index: 1; left: 5; top: 10;>');
        arr.push('<p align="center"><a href="#" onClick="this.parentNode.style.display=\'none\';" style="font-size:12px; color:#000000; ">关闭</a><br>');
        arr.push('<a href="'+ad.link+'" target="_blank"><img src="'+this.picPath+ad.adpic+'"  border="0" alt="'+ad.adname+'"></a></p></div>');
        new Insertion.Bottom(document.body,arr.join(''));
    },
    
    rightPair:function(ad){
        var arr=[];
        arr.push('<div style="position: absolute;  z-index: 1; right: 5; top: 10; ">');
        arr.push('<p align="center"><a href="#" onClick="this.parentNode.parentNode.style.display=\'none\';" style="font-size:12px; color:#000000; ">关闭</a><br>');
        arr.push('<a href="'+ad.link+'" target="_blank"><img src="'+this.picPath+ad.adpic+'"  border="0" alt="'+ad.adname+'"></a></p></div>');
        new Insertion.Bottom(document.body,arr.join(''));
    },
    
    leftScroll:function(ad){
        var arr=[];
        arr.push('<div id="divScrollLeft" style="position:absolute;z-index:2;left:0px;top:200px;margin:0px"><p align="center"><a href="#" onClick="this.parentNode.style.display=\'none\';" style="font-size:12px; color:#000000; ">关闭</a><br><a href="'+ad.link+'" target="_blank">');
        arr.push('<img src="'+this.picPath+ad.adpic+'"  border="0" alt="'+ad.adname+'"></a></p></div>');
        new Insertion.Bottom(document.body,arr.join(''));
        new PeriodicalExecuter(function(){
            var ele=$('divScrollLeft');
            var scrollTop=window.pageYOffset|| document.documentElement.scrollTop|| document.body.scrollTop|| 0;
            var scrollLeft=window.pageXOffset|| document.documentElement.scrollLeft|| document.body.scrollLeft|| 0;
            if(ele.offsetTop!=scrollTop+this.scrollY)
            {
                var dy=(scrollTop+this.scrollY-ele.offsetTop)*this.delta;
                dy=(dy>0?1:-1)*Math.ceil(Math.abs(dy));
                ele.style.top=ele.offsetTop+dy;
            }
            var x=5;
            if(ele.offsetLeft!=(scrollLeft+x))
            {
                var dx=(scrollLeft+x-ele.offsetLeft)*this.delta;
                dx=(dx>0?1:-1)*Math.ceil(Math.abs(dx));
                ele.style.left=ele.offsetLeft+dx;
            }
            }.bind(this),0.01);
    },
    
    rightScroll:function(ad){
        var arr=[];
        arr.push('<div id="divScrollRight" style="position:absolute;z-index:500;right:0px;top:200px;margin:0px"><p align="center"><a href="#" onClick="this.parentNode.style.display=\'none\';" style="font-size:12px; color:#000000; ">关闭</a><br><a href="'+ad.link+'" target="_blank">');
        arr.push('<img src="'+this.picPath+ad.adpic+'"  border="0" alt="'+ad.adname+'"></a></p></div>');
        new Insertion.Bottom(document.body,arr.join(''));
        new PeriodicalExecuter(function(){
            var ele=$('divScrollRight');
            var scrollTop=window.pageYOffset|| document.documentElement.scrollTop|| document.body.scrollTop|| 0;
            var scrollLeft=window.pageXOffset|| document.documentElement.scrollLeft|| document.body.scrollLeft|| 0;
            if(ele.offsetTop!=scrollTop+this.scrollY)
            {
                var dy=(scrollTop+this.scrollY-ele.offsetTop)*this.delta;
                dy=(dy>0?1:-1)*Math.ceil(Math.abs(dy));
                ele.style.top=ele.offsetTop+dy;
            }
            var x=document.body.clientWidth-ele.offsetWidth-5;
            if(ele.offsetLeft!=(scrollLeft+x))
            {
                var dx=(scrollLeft+x-ele.offsetLeft)*this.delta;
                dx=(dx>0?1:-1)*Math.ceil(Math.abs(dx));
                ele.style.left=ele.offsetLeft+dx;
            }
            }.bind(this),0.01);
    },
    
    floatAd:function(ad){
        var divFloat=document.createElement('div');
        $(divFloat).setStyle({position:'absolute',zIndex:'1000px'});
        divFloat.innerHTML='<a href="'+ad.link+'" target="_blank"><img src="'+this.picPath+ad.adpic+'"  border="0" alt="'+ad.adname+'"></a>';
        document.body.appendChild(divFloat);
        var floatMin=2;
		var floatMax=5;
		var vx=floatMin+floatMax*Math.random();
		var vy=floatMin+floatMax*Math.random();
		var xx=0;
		var yy=0;
		var w=divFloat.offsetWidth+5;
		var h=divFloat.offsetHeight+5;
        var pe=new PeriodicalExecuter(function(){
            pageX=window.pageXOffset|| document.documentElement.scrollLeft|| document.body.scrollLeft|| 0;
			pageW=window.innerWidth||window.document.body.offsetWidth;
			pageY=window.pageYOffset|| document.documentElement.scrollTop|| document.body.scrollTop|| 0;
			pageH=window.innerHeight||window.document.body.offsetHeight;
            xx+=vx;
            yy+=vy;
            vx+=(Math.random()-0.5)*3;
            vy+=(Math.random()-0.5)*3;
            if(vx>(floatMin+floatMax))  vx=(floatMax+floatMin)*2-vx;
		    if(vx<(-floatMin-floatMax)) vx=(-floatMax-floatMin)*2-vx;
		    if(vy>(floatMax+floatMin))  vy=(floatMax+floatMin)*2-vy;
		    if(vy<(-floatMin-floatMax)) vy=(-floatMin-floatMax)*2-vy;
		    if(xx<=pageX)
		    {
			    xx=pageX;
			    vx=floatMin+floatMax*Math.random();
		    }
		    if(xx>=pageX+pageW-w)
		    {
			    xx=pageX+pageW-w;
			    vx=-floatMin-floatMax*Math.random();
		    }
		    if(yy<=pageY)
		    {
			    yy=pageY;
			    vy=floatMin+floatMax*Math.random();
		    }
		   
		      if(yy>=pageH-h)
		    { 
			    yy=pageH-h;
			    vy=-floatMin-floatMax*Math.random();
		    }
		    divFloat.style.left=xx;
		    divFloat.style.top=yy;},0.06);
        Event.observe(divFloat,'mouseover',function(){pe.stop();});
		Event.observe(divFloat,'mouseout',function(){pe.registerCallback();});
    }
}

function op(operation,values ,retFun,asynchronous)
{ 
    if(asynchronous==undefined) asynchronous=true;
    var url='sysadmin/Advertisement/temp/op.aspx';
    var pars='operation='+operation+'&values='+values+'&rd='+Math.random();
    var myAjax = new Ajax.Request(url, {method: 'post', parameters: pars,asynchronous:asynchronous, onComplete: retFun}); 
}

function showads(originalRequest)
{ 
    var ads=originalRequest.responseText.evalJSON();
    new ad(ads);
}
 
document.body.onload=function(){op('getads','',showads);}