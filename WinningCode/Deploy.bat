@echo off

msbuild.exe GeekUp.sln /t:Rebuild /p:Configuration=Release

if %errorlevel%==0 (
    echo Build successful. Replacing and restarting service...
    
    Web\GeekUp.Host.exe stop
    REM Web\GeekUp.Host.exe uninstall
    
    del /F /Q Web\*
    copy Host\bin\Release\* Web
    
    Web\GeekUp.Host.exe install
    Web\GeekUp.Host.exe start
) else (
    echo Build failed. Aborting...
)
