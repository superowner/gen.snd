﻿; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "MidiSmf Tool"
#define MyAppVersion "1.0"
#define MyAppPublisher "tfwroble@gmail.com"
#define MyAppURL "mailto:tfwroble@gmail.com"
#define MyAppExeName "midsmf.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{3E180F8C-80E6-4F71-8110-CDF015CC9635}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\MIDI SMF
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputBaseFilename=Setup Midi Smf Tool
SetupIconFile=F:\DEV\WIN\CS_ROOT\Projects\svn_sound\xmid\speaker_tosort.ico
Compression=lzma
SolidCompression=yes
VersionInfoVersion=1.0
VersionInfoCompany=tfooo@gmail.com
VersionInfoCopyright=tfwroble@gmail.com
VersionInfoProductName=MIDI SMF Tool (modēst100)
VersionInfoProductTextVersion=modēst100 v1.0 (experimental-beta)
OutputDir=bin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

#include "setup-files.iss"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"               
Name: "{group}\Wizard"; Filename: "{app}\SoundOut.exe";
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{commondesktop}\Wizard"; Filename: "{app}\SoundOut.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: files; Name: "{app}\settings.cfg"

[Components]
Name: "app_main"; Description: "Main Executable Files"; Types: full custom compact; Flags: fixed
Name: "app_main\wiz"; Description: "Sound Wizard"; Types: full custom
Name: "app_config"; Description: "Support Files"; Types: full custom compact ; Flags: fixed