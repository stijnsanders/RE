#define MyAppName "Regular Expression"
#define MyAppVersion "2.1.1.670"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{9DA5420E-0943-4839-B1EE-844B9EC01336}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher=Double Sigma Programming
AppPublisherURL=http://yoy.be/re
AppSupportURL=http://yoy.be/re
AppUpdatesURL=http://yoy.be/re
DefaultDirName={userpf}\RE
ChangesAssociations=yes
;DefaultGroupName=Regular Expression
UninstallDisplayIcon={app}\RE.exe
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
;PrivilegesRequired=none
OutputDir=.
OutputBaseFilename=RE_setup
SetupIconFile=DotNet\RE\App.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
;Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "DotNet\bin\Release\net9.0-windows7.0\RE.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\RE.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\RE.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\RELib.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\REBasic.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\RERegex.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\REMulti.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\REFileSystem.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\REXML.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\REJSON.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\bin\Release\net9.0-windows7.0\REHTTP.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DotNet\WhatsNew.txt"; DestDir: "{app}"
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
;Root: HKCR; Subkey: ".rxe"; ValueType: string; ValueData: "rxeDataFile"
;Root: HKCR; Subkey: ".rxe"; ValueType: string; ValueName: "Content Type"; ValueData: "text/xml"
;Root: HKCR; Subkey: "rxeDataFile"; ValueType: string; ValueData: "Regular Expression Structure"
;Root: HKCR; Subkey: "rxeDataFile\DefaultIcon"; ValueType: string; ValueData: "{app}\RELib.dll,0"
;Root: HKCR; Subkey: "rxeDataFile\shell"; ValueType: string; ValueData: "open"
;Root: HKCR; Subkey: "rxeDataFile\shell\open"; ValueType: string; ValueData: "Open"
;Root: HKCR; Subkey: "rxeDataFile\shell\open\command"; ValueType: string; ValueData: """{app}\Re.exe"" ""%l"""
;Root: HKCR; Subkey: "Applications\RE.exe\shell"; ValueType: string; ValueData: "open"
;Root: HKCR; Subkey: "Applications\RE.exe\shell\open"; ValueType: string; ValueData: "Open"
;Root: HKCR; Subkey: "Applications\RE.exe\shell\open\command"; ValueType: string; ValueData: """{app}\Re.exe"" ""%l"""

Root: HKA; Subkey: "Software\Classes\.rxe\OpenWithProgids"; ValueType: string; ValueName: "rxeDataFile"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\rxeDataFile"; ValueType: string; ValueName: ""; ValueData: "Regular Expression Structure"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\rxeDataFile\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\RE.exe,0"
Root: HKA; Subkey: "Software\Classes\rxeDataFile\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\RE.exe"" ""%l"""
Root: HKA; Subkey: "Software\Classes\Applications\RE.exe\SupportedTypes"; ValueType: string; ValueName: ".rxe"; ValueData: ""


[Icons]
;Name: "{group}\Regular Expression"; Filename: "{app}\RE.exe"
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\RE.exe"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\RE.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\RE.exe"; Description: "{cm:LaunchProgram,Regular Expression}"; Flags: nowait postinstall skipifsilent

