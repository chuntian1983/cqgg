//弹出对话框
function fPopUpDlg(endtarget,ctl,WINname,WINwidth,WINheight,Left,Height){
	
	//showx =  WINwidth + 200  ; // + deltaX;
	//showy = WINheight ; // + deltaY;
	showx=Left;
	showy=Height;

	newWINwidth = WINwidth + 4 + 18;
	var features =
		'dialogWidth:'  + newWINwidth  + 'px;' +
		'dialogHeight:' + WINheight + 'px;' +
		'dialogLeft:'   + showx     + 'px;' +
		'dialogTop:'    + showy     + 'px;' +
		'directories:no; localtion:no; menubar:no; status=no; toolbar=no;scrollbars:yes;Resizeable=no';
	
	retval = window.showModalDialog(endtarget, WINname , features );
	if( retval != null ){
		ctl.value = retval;
	}else{
		//alert("canceled");
	}
}



//全选 反选
function SelectAll()
{
	var e=document.getElementsByTagName("input");
	for(var i=0;i<e.length;i++)
	{
		if (e[i].type=="checkbox")
		{
			if(document.getElementById("selall").checked==true)
				e[i].checked=true;
			else
				e[i].checked=false;
		}
	}
}

//获取url参数 strname:参数名称
function GetParaStr(strname){
    var pageUrl=document.location.href;
    pageUrl=pageUrl.substring(pageUrl.indexOf("?")+1);
    var para=pageUrl.split("&");
    var tempstr="";
    for (var i=0; i<para.length; i++){
        tempstr=para[i].split("=");
        if (strname==tempstr[0])
        {
            return tempstr[1];
        }
        //document.write(tempstr+'\n');
    }
}

//取消按纽
function on_resert(){
	var obj=document.form1.getElementsByTagName("input");
	var i=0;
	for (i=0;i<obj.length;i++){		
		if ((obj[i].type=="text"))
			obj[i].value="";
	}
}


//判断单选框或者复选框是否选中
function check_select(obj){
	var rad_obj=eval(obj).all.tags("input");
	var result;
	for(i=0;i<rad_obj.length;i++){
		if (rad_obj[i].type=="radio"||rad_obj[i].type=="checkbox"){
			if (rad_obj[i].checked==true){
				result=true;
				break;
			}
		}
	}	
	if(i>=rad_obj.length){
		result=false;
	}
	return result;
}


function checked_select(obj){
	var rad_obj=eval(obj).all.tags("input");
	var result="";
	for(i=0;i<rad_obj.length;i++){
		if (rad_obj[i].type=="checkbox"){
			if (rad_obj[i].checked==true){
				result+=rad_obj[i].value+",";
			}
		}
	}	
	if(result==""){
		result=false;
	}
	else{
		result=result.substr(0,result.length-1)
	}
	return result;
}

function GetQueryValue(sorStr,panStr) 
{ 
	var vStr="";
	if (sorStr==null || sorStr=="" || panStr==null || panStr=="") return vStr; 
	//sorStr = sorStr.toLowerCase();
	panStr += "="; 
	var itmp=sorStr.indexOf(panStr); 
	if (itmp<0){return vStr;} 
	sorStr = sorStr.substr(itmp + panStr.length); 
	itmp=sorStr.indexOf("&"); 
	if (itmp<0)
	{
		return sorStr; 
	} 
	else 
    {
		sorStr=sorStr.substr(0,itmp); 
		return sorStr;
	} 
}


//建立Ajax模型,发送XML字符串
function SaveXMLDom(strUrl,strxml,BackUrl){
    if (window.ActiveXObject) {
        try {
	        xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        } 
        catch (e) {
	        try {
		        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
	        } 
	        catch (e) {}
		}
	}
	        
    xmlHttp.open("post",strUrl,true);
    xmlHttp.onreadystatechange=function() {
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
				var msg=xmlHttp.getResponseHeader("msg");
				if (msg=="") {
					alert("操作成功！");
					//alert(xmlHttp.responseBody);
					location.reload();
				}else{
					alert(msg);
				}
			}
			else{
				alert("页面请求有异常！");
				alert(xmlHttp.responseBody);
			}
		}
	}
	xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded;");
	xmlHttp.send(strxml);
}

function SaveXMLDom1(strUrl,strxml,AlertMsg){
    if (window.ActiveXObject) {
        try {
	        xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        } 
        catch (e) {
	        try {
		        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
	        } 
	        catch (e) {}
		}
	}
	        
    xmlHttp.open("post",strUrl,true);
    xmlHttp.onreadystatechange=function() {
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
				var msg=xmlHttp.getResponseHeader("msg");
				if (msg=="") {
					if (AlertMsg != "")
					{
						alert(AlertMsg);
					}
					location.reload();
				}else{
					alert(msg);
				}
			}
			else{
				alert("页面请求有异常！");
				alert(xmlHttp.responseBody);
			}
		}
	}
	xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded;");
	xmlHttp.send(strxml);
}

/**
function SaveXMLDom2(strUrl,strxml){
	var objHttp=new ActiveXObject("Microsoft.XMLHTTP");
	objHttp.open("post",strUrl,false);
	objHttp.send(strxml);
	var ReValue;
	if (objHttp.status==200)
		{
			if(objHttp.readyState==4)
				
				{
					var msg=objHttp.getResponseHeader("msg");
					if (msg=="") 
						{
							ReValue=objHttp.getResponseHeader("ReValue");
						}else
						{
							alert(msg);
							ReValue=false;
						}
				}else
				{
					alert("错误！");
					ReValue=false;
				}
		}else
		{
			alert("找不到该页面"+objHttp.status);
			ReValue=false;
		}
	return ReValue;	
}
**/

function GetXMLDom(strUrl){
	var save_http=new ActiveXObject("Microsoft.XMLHTTP");
	save_http.open("post",strUrl,false);
	save_http.send();
	var strreturn="";
	if (save_http.status==200){
		if(save_http.readyState==4){
			var msg=save_http.getResponseHeader("msg");
			if(msg==""){
				strreturn=save_http.responseXML;
			}
			else{
				alert(msg);
				strreturn=false;
			}
		}
		else{
			alert("出现错误");
			strreturn=false;
		}
	}
	else{
		alert("找不到该页面"+save_http.status);
		alert(save_http.responseBody);
		strreturn=false;
	}
	return strreturn;
}



function GetObjValue(Obj){
	var strObjValue="";
	switch (Obj.type){
		case "text":
		case "hidden":
		case "password":
		case "textarea":
			strObjValue=Obj.value;
			break;
		case "radio":
		case "checkbox":
			if(Obj.checked){
				strObjValue=Obj.value;
			}
			break;
		case "select-one":
			strObjValue=Obj.options[Obj.selectedIndex].value;
			break;
		case "select-multiple":{
			for(var i=0;i<Obj.length;i++){
				if(Obj.options[i].selected){
					strObjValue+=","+Obj.options[i].value;
					break;
				}
			}
		}		
	}
	return strObjValue;
}


function SetObjValue(strObj,RootDom,strPrefix){
	var Obj_Arr=strObj.split(",");
	for(var i=0;i<Obj_Arr.length;i++){
		var Obj=eval(strPrefix+Obj_Arr[i]);
		Obj.value=RootDom.selectSingleNode(Obj_Arr[i]).text;
	}
}


//读取页面表单元素,建立Dom字符串
function CreateDom(strNode,strPrefix){
	var arrNode=strNode.split(",");	
	var resultDom=new ActiveXObject("Microsoft.XMLDOM");
	resultDom.async=false;
	var rootdom=resultDom.createElement("root");
	for(var i=0;i<arrNode.length;i++){
		//var Obj=eval(strPrefix+arrNode[i].replace(/(^\s*)|(\s*$)/g, ""));
		var Obj=document.getElementById(arrNode[i]);
		var Nodes=resultDom.createElement(arrNode[i].replace(/(^\s*)|(\s*$)/g, ""));
		var strValue;
		strValue=GetObjValue(Obj);
		if(Obj.type=="textarea"){
			var NodeCdata=resultDom.createCDATASection(strValue);
			Nodes.appendChild(NodeCdata);
		}
		else{
			Nodes.text=strValue;
		}
		rootdom.appendChild(Nodes);		
	}
	return rootdom;
}


function create_select(obj,select_text,select_value,auto_select,filepath){//控件，显示的文字，选项值，以选择的，文件路径
	var xml_dom=new ActiveXObject("Microsoft.XMLDOM");
	xml_dom.async=false;
	xml_dom.load(filepath);
	var rootdom=xml_dom.documentElement;
	var find="";
	var xml_nodes=rootdom.selectNodes("//recorders");
	eval(obj).length=0;
	eval(obj).length=1;
	eval(obj).options[0].value="0";
	eval(obj).options[0].text="请选择";
	for(var i=0;i<xml_nodes.length;i++){
		eval(obj).length+=1;
		var xml_node=xml_nodes.item(i);
		eval(obj).options[eval(obj).length-1].text=xml_node.selectSingleNode("./"+select_text).text
		NodeValue=xml_node.selectSingleNode("./"+select_value).text;
		eval(obj).options[eval(obj).length-1].value=NodeValue;
		if(auto_select==NodeValue){
			eval(obj).options[eval(obj).length-1].selected=true;
		}
	}	
}



function create_select_multiple(obj,select_text,select_value,auto_select,filepath){//控件，显示的文字，选项值，已选择的，文件路径
	var xml_dom=new ActiveXObject("Microsoft.XMLDOM");
	xml_dom.async=false;
	xml_dom.load(filepath);
	var rootdom=xml_dom.documentElement;
	var find="";
	var xml_nodes=rootdom.selectNodes("//recorders");
	eval(obj).length=0;
	for(var i=0;i<xml_nodes.length;i++){
		eval(obj).length+=1;
		var xml_node=xml_nodes.item(i);
		eval(obj).options[eval(obj).length-1].text=xml_node.selectSingleNode("./"+select_text).text
		NodeValue=xml_node.selectSingleNode("./"+select_value).text;
		eval(obj).options[eval(obj).length-1].value=NodeValue;
		if(auto_select.indexOf(NodeValue)!=-1){
			eval(obj).options[eval(obj).length-1].selected=true;
		}
	}
	
}


function create_select_hasParent(obj,select_text,select_value,auto_select,filepath,ParentNum,otherCondition){//控件，显示的文字，选项值，以选择的，文件路径
	var xml_dom=new ActiveXObject("Microsoft.XMLDOM");
	xml_dom.async=false;
	xml_dom.load(filepath);
	var rootdom=xml_dom.documentElement;
	var find="//recorders[./ParentNum='"+ParentNum+"'";
	if(otherCondition!="")
	{
		find+=" "+otherCondition;
	}
	find+="]";
	
	var xml_nodes=rootdom.selectNodes(find);
	eval(obj).length=0;
	eval(obj).length=1;
	eval(obj).options[0].value="0";
	eval(obj).options[0].text="请选择";
	for(var i=0;i<xml_nodes.length;i++){
		eval(obj).length+=1;
		var xml_node=xml_nodes.item(i);
		eval(obj).options[eval(obj).length-1].text=xml_node.selectSingleNode("./"+select_text).text
		NodeValue=xml_node.selectSingleNode("./"+select_value).text;
		eval(obj).options[eval(obj).length-1].value=NodeValue;
		if(auto_select==NodeValue){
			eval(obj).options[eval(obj).length-1].selected=true;
		}
	}
}