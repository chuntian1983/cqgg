document.writeln("<div id='divStayTopLeft1' style='position:absolute'><a href='http://#' target='_blank'><img src='/SiteAdmin/SysAdmin/upload/2007622111632.jpg' width='100' height='250' border='0' alt='广告'></a></div>");

var verticalpos="frombottom";

function JSFX_FloatTopDiv1()
{
	var rstartX = screen.availWidth-130,
	rstartY = 300;
	var rns = (navigator.appName.indexOf("Netscape") != -1);
	var rd = document;
	function ml1(id)
	{
		var rel=rd.getElementById?rd.getElementById(id):rd.all?rd.all[id]:rd.layers[id];
		if(rd.layers)rel.style=rel;
		rel.sP=function(x,y){this.style.left=x;this.style.top=y;};
		rel.x = rstartX;
		if (verticalpos=="fromtop")
		rel.y = rstartY;
		else{
		rel.y = rns ? pageYOffset + innerHeight : document.body.scrollTop + document.body.clientHeight;
		rel.y -= rstartY;
		}
		return rel;
	}
	window.stayTopLeft1=function()
	{
		if (verticalpos=="fromtop"){
		var rpY = rns ? pageYOffset : document.body.scrollTop;
		ftlObj1.y += (rpY + rstartY - ftlObj1.y)/8;
		}
		else{
		var rpY = rns ? pageYOffset + innerHeight : document.body.scrollTop + document.body.clientHeight;
		ftlObj1.y += (rpY - rstartY - ftlObj1.y)/8;
		}
		ftlObj1.sP(ftlObj1.x, ftlObj1.y);
		setTimeout("stayTopLeft1()", 10);
	}
	ftlObj1 = ml1("divStayTopLeft1");
	stayTopLeft1();
}
JSFX_FloatTopDiv1();