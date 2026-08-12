@echo off
setlocal

set "SOLUTION=%~dp0WorkDoAuto.sln"
set "CONFIGURATION=%~1"
if not defined CONFIGURATION set "CONFIGURATION=Release"
set "OUTPUT_ROOT=%~dp0artifacts\%CONFIGURATION%"

set "MSBUILD_EXE="
set "VSWHERE=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"

if exist "%VSWHERE%" (
    for /f "usebackq delims=" %%I in (`"%VSWHERE%" -latest -products * -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe`) do (
        if not defined MSBUILD_EXE set "MSBUILD_EXE=%%I"
    )
)

if not defined MSBUILD_EXE (
    for /f "delims=" %%I in ('where msbuild.exe 2^>nul') do (
        if not defined MSBUILD_EXE set "MSBUILD_EXE=%%I"
    )
)

if not defined MSBUILD_EXE (
    echo ERROR: MSBuild was not found.
    echo Install Visual Studio or Visual Studio Build Tools with the .NET desktop build tools workload.
    exit /b 1
)

echo Restoring NuGet packages...
echo MSBuild: %MSBUILD_EXE%

"%MSBUILD_EXE%" "%SOLUTION%" /t:Restore /m /p:RestorePackagesConfig=true /v:minimal
if errorlevel 1 (
    echo.
    echo PACKAGE RESTORE FAILED.
    echo Check your network connection and NuGet package sources, then try again.
    exit /b 1
)

echo.
echo Building WorkDoAuto [%CONFIGURATION%]...
"%MSBUILD_EXE%" "%SOLUTION%" /t:Build /m /p:Configuration="%CONFIGURATION%" /v:minimal
if errorlevel 1 (
    echo.
    echo BUILD FAILED.
    echo If a DLL is locked, close the running WorkDoWinService and try again.
    exit /b 1
)

echo.
echo BUILD SUCCEEDED.
echo Output: %OUTPUT_ROOT%
exit /b 0
