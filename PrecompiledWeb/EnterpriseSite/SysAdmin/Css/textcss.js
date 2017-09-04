function GetIEVersion()
{
	try
	{
		if(!window.clientInformation)return false;
		if(window.clientInformation.appName.toLowerCase()!="microsoft internet explorer")return false;
		if(window.clientInformation.appVersion.toLowerCase().indexOf("msie")==-1)return false;
		var a=window.clientInformation.appVersion.toLowerCase().split(";");
		for(var i=0;i<a.length;i++)
		{
			a[i]=a[i].replace(" ","");
			if(a[i].indexOf("msie")==0)
			{
				var version=a[i].substr(4,a[i].indexOf(".")-2);
				return version;
			}
		}
	}
	catch(exception)
	{
	}
	return false;
}
window.IEVersion=GetIEVersion();

if(parseInt(window.IEVersion)<6){document.write("<style>.content {behavior:url('../../Css/tacontent.htc')}</style>");}