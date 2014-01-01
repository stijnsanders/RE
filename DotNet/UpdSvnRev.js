if(WScript.Arguments.length==0)
{
    WScript.Echo("Usage UpdSvnRev.js <ProjectName> [<SvnDir>]");
}
else
{
    var ProjectDir=WScript.Arguments(0);
    var SvnDir=ProjectDir;//WScript.Arguments(1);    

    var svn=new ActiveXObject("SubWCRev.object");
	svn.GetWCInfo(SvnDir,true,false);
	var rev=svn.MaxRev;
		
	var fso=new ActiveXObject("Scripting.FileSystemObject");
	fn=ProjectDir+"\\Properties\\AssemblyInfo.vb";
	if(!fso.FileExists(fn))fn=ProjectDir+"\\Properties\\AssemblyInfo.cs";
	if(!fso.FileExists(fn))fn=ProjectDir+"\\My Project\\AssemblyInfo.vb";
	if(!fso.FileExists(fn))fn=ProjectDir+"\\My Project\\AssemblyInfo.cs";
	if(!fso.FileExists(fn))fn=ProjectDir+"\\AssemblyInfo.vb";
	if(!fso.FileExists(fn))fn=ProjectDir+"\\AssemblyInfo.cs";
	if(!fso.FileExists(fn))fn="NoneFound";
	f1=fso.OpenTextFile(fn);
	var dc=f1.ReadAll();
	f1.Close();

	dc=dc.replace(new RegExp("([Aa]ssembly: AssemblyFileVersion(Attribute)?\\(\"[0-9]+?\\.[0-9]+?\\.[0-9]+?)\\.[0-9]+?(\"\\))","m"),"$1."+rev+"$3");

	f1=fso.CreateTextFile(fn,1);
	f1.Write(dc);
	f1.Close();
}