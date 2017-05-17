#define MySourceDir "..\KeepAliveHD\bin\Release"
#define MyOutputDir ".\Releases"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{8623BFAD-9E79-4188-9EB4-9740CEDD3B44}
AppName=KeepAliveHD
AppVerName=KeepAliveHD 1.6.1 beta
AppPublisher=Megabit d.o.o.
AppPublisherURL=
AppSupportURL=
AppUpdatesURL=
DefaultDirName={pf}\Megabit\KeepAliveHD
DefaultGroupName=KeepAliveHD
DisableProgramGroupPage=yes
OutputDir="{#MyOutputDir}"
OutputBaseFilename=KeepAliveHDSetup
Compression=lzma
SolidCompression=yes

[Languages]
;Name: "English"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#MySourceDir}\KeepAliveHD.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MySourceDir}\Settings.xml"; DestDir: "{app}"; Flags: onlyifdoesntexist
; NOTE: Don't use "Flags: ignoreversion" on any shared system files


[Icons]
Name: "{group}\KeepAliveHD"; Filename: "{app}\KeepAliveHD.exe"
Name: "{commondesktop}\KeepAliveHD"; Filename: "{app}\KeepAliveHD.exe"; Tasks: desktopicon
Name: "{group}\Uninstall"; Filename: "{uninstallexe}"




