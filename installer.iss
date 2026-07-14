#ifndef MyArch
  #define MyArch "win-x64"
#endif
#ifndef MyVersion
  #define MyVersion "1.0.0.0"
#endif

[Setup]
AppName=PASPAS
AppVersion={#MyVersion}
AppPublisher=Berkay Gediz
AppPublisherURL=https://github.com/berkaygediz/PASPAS
AppSupportURL=https://github.com/berkaygediz/PASPAS/issues
AppUpdatesURL=https://github.com/berkaygediz/PASPAS/releases
DefaultDirName={autopf}\PASPAS
DefaultGroupName=PASPAS
UninstallDisplayIcon={app}\PASPAS.exe
Compression=lzma2
SolidCompression=yes
OutputDir=.
OutputBaseFilename=PASPAS-{#MyVersion}-Setup-{#MyArch}
PrivilegesRequired=admin
ArchitecturesAllowed=x86 x64 arm64
ArchitecturesInstallIn64BitMode=x64 arm64

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "publish\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs

[Icons]
Name: "{group}\PASPAS"; Filename: "{app}\PASPAS.exe"
Name: "{group}\{cm:UninstallProgram,PASPAS}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\PASPAS"; Filename: "{app}\PASPAS.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\PASPAS.exe"; Description: "{cm:LaunchProgram,PASPAS}"; Flags: nowait postinstall skipifsilent
