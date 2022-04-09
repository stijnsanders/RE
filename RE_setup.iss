; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{9DA5420E-0943-4839-B1EE-844B9EC01336}
AppName=Regular Expression
AppVerName=Regular Expression 2.0.4.646
AppPublisher=Double Sigma Programming
AppPublisherURL=http://yoy.be/re
AppSupportURL=http://yoy.be/re
AppUpdatesURL=http://yoy.be/re
DefaultDirName={pf}\RE
DefaultGroupName=Regular Expression
AllowNoIcons=yes
OutputDir=.
OutputBaseFilename=RE_setup
SetupIconFile=DotNet\RE\App.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "DotNet\bin\Release\net5.0-windows\RE.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\RE.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\RELib.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\REBasic.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\RERegex.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\REMulti.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\REFileSystem.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\REXML.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\REJSON.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net5.0-windows\REHTTP.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\WhatsNew.txt"; DestDir: "{app}"
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKCR; Subkey: ".rxe"; ValueType: string; ValueData: "rxeDataFile"
Root: HKCR; Subkey: ".rxe"; ValueType: string; ValueName: "Content Type"; ValueData: "text/xml"
Root: HKCR; Subkey: "rxeDataFile"; ValueType: string; ValueData: "Regular Expression Structure"
Root: HKCR; Subkey: "rxeDataFile\DefaultIcon"; ValueType: string; ValueData: "{app}\RELib.dll,0"
Root: HKCR; Subkey: "rxeDataFile\shell"; ValueType: string; ValueData: "open"
Root: HKCR; Subkey: "rxeDataFile\shell\open"; ValueType: string; ValueData: "Open"
Root: HKCR; Subkey: "rxeDataFile\shell\open\command"; ValueType: string; ValueData: """{app}\Re.exe"" ""%l"""
Root: HKCR; Subkey: "Applications\RE.exe\shell"; ValueType: string; ValueData: "open"
Root: HKCR; Subkey: "Applications\RE.exe\shell\open"; ValueType: string; ValueData: "Open"
Root: HKCR; Subkey: "Applications\RE.exe\shell\open\command"; ValueType: string; ValueData: """{app}\Re.exe"" ""%l"""

[Icons]
Name: "{group}\Regular Expression"; Filename: "{app}\RE.exe"
Name: "{commondesktop}\Regular Expression"; Filename: "{app}\RE.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\RE.exe"; Description: "{cm:LaunchProgram,Regular Expression}"; Flags: shellexec postinstall skipifsilent

