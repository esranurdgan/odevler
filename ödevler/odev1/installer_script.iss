; Inno Setup Script for Neon Tetris OOP
; Demonstrates Single-Installation Mechanism

[Setup]
AppId={{C6F4A83B-764E-464A-A9F7-4DF889C55C6A}
AppName=Neon Tetris OOP
AppVersion=1.0
DefaultDirName={autopf}\NeonTetrisOOP
DefaultGroupName=Neon Tetris OOP
OutputDir=.
OutputBaseFilename=TetrisSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Files]
Source: "bin\Release\net10.0-windows\TetrisApp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\net10.0-windows\TetrisApp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\net10.0-windows\TetrisApp.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\net10.0-windows\TetrisApp.deps.json"; DestDir: "{app}"; Flags: ignoreversion

[Registry]
; THIS IS THE KEY TO THE SINGLE-INSTALLATION MECHANISM
; By default, registry keys are NOT deleted on uninstall unless 'uninsdeletekey' is specified.
; Omitting flags ensures the key stays forever.
Root: HKCU; Subkey: "Software\NeonTetrisOOP_Project"; ValueType: string; ValueName: "Installed"; ValueData: "True"

[Icons]
Name: "{group}\Neon Tetris OOP"; Filename: "{app}\TetrisApp.exe"
Name: "{autodesktop}\Neon Tetris OOP"; Filename: "{app}\TetrisApp.exe"

[Code]
function InitializeSetup: Boolean;
begin
  Result := True;
  
  // Check if the persistent registry key exists
  if RegKeyExists(HKEY_CURRENT_USER, 'Software\NeonTetrisOOP_Project') then
  begin
    MsgBox('HATA: Bu oyun bu bilgisayara zaten bir kez kurulmus! Tekil kurulum mekanizmasi geregi, uygulama bir kez kurulduktan sonra (silinse dahi) tekrar kurulamaz.', mbCriticalError, MB_OK);
    Result := False; // Aborts the installation
  end;
end;
