; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Art of Machines"
#define MyAppVersion "1.1"
#define MyAppExeName "SandBoxTest.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{96A95067-A8D2-4B5C-B323-6BF960050AA0}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName={autopf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=C:\Users\lvandehey\Desktop\Sandbox\Installer
OutputBaseFilename=mysetup
SetupIconFile=C:\Users\lvandehey\Desktop\Sandbox\SandBoxTest\Assets\Prefabs\TempLogo.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\lvandehey\Desktop\Sandbox\Build\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\lvandehey\Desktop\Sandbox\Build\UnityCrashHandler64.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\lvandehey\Desktop\Sandbox\Build\UnityPlayer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\lvandehey\Desktop\Sandbox\Build\MonoBleedingEdge\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\lvandehey\Desktop\Sandbox\Build\SandBoxTest_Data\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

