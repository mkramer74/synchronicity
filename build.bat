@echo OFF
@if "%1" == "/?" goto help

:start
@echo This file is part of Create Synchronicity.
@echo Create Synchronicity is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
@echo Create Synchronicity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
@echo You should have received a copy of the GNU General Public License along with Create Synchronicity.  If not, see http://www.gnu.org/licenses/.
@echo Created by:   Clément Pit--Claudel.
@echo Web site:     http://synchronicity.sourceforge.net.
@echo.

@set TAG=%1
@set ROOT=%CD%
@set BUILD=%ROOT%\build
@set BIN=%ROOT%\Create Synchronicity\bin

@set LOG="%BUILD%\buildlog-%TAG%.txt"

mkdir "%BUILD%"

(echo Packaging log for %TAG% & date /t & time /t & echo.) > %LOG%

echo (**) Updating revision number
(
echo.
echo -----
cd "%ROOT%\Create Synchronicity"
subwcrev.exe %ROOT% Revision.template.vb Revision.vb
cd "%ROOT%"
) >> %LOG%

echo (**) Building program (release)
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe" "%ROOT%\Create Synchronicity.sln" /Rebuild Release /Out %LOG%

echo (**) Building program (debug)
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe" "%ROOT%\Create Synchronicity.sln" /Rebuild Debug /Out %LOG%

echo (**) Building installer
(
echo.
echo -----
"C:\Program Files (x86)\NSIS\makensis.exe" "%ROOT%\Create Synchronicity\setup_script.nsi"
echo.
echo -----
move Create_Synchronicity_Setup.exe "%BUILD%\Create_Synchronicity_Setup-%TAG%.exe"
) >> %LOG%

echo (**) Building zip files
(
echo.
echo -----
cd "%BIN%\Release"
"C:\Program Files\7-Zip\7z.exe" a "%BUILD%\Create_Synchronicity-%TAG%.zip" "Create Synchronicity.exe" "Release notes.txt" "COPYING" "languages\*"
cd "%ROOT%"

cd "%BIN%\Debug"
"C:\Program Files\7-Zip\7z.exe" a "%BUILD%\Create_Synchronicity-%TAG%-DEBUG.zip" "Create Synchronicity.exe" "Release notes.txt" "COPYING" "languages\*"
"C:\Program Files\7-Zip\7z.exe" a "%BUILD%\Create_Synchronicity-%TAG%-Extensions.zip" "compress.dll" "ICSharpCode.SharpZipLib.dll"
cd "%ROOT%"

cd "%BIN%\Linux"
"C:\Program Files\7-Zip\7z.exe" a "%BUILD%\Create_Synchronicity-%TAG%-Linux.zip" "Create Synchronicity.exe" "Release notes.txt" "run-create-synchronicity.sh" "COPYING" "languages\*"
cd "%ROOT%"
) >> %LOG%

@goto end

:help
@echo Usage: build.bat v5.0 or build.bat r2873.
@echo This script builds all versions of Create Synchronicity.
@echo Requires 7-zip installed in "C:\Program Files\7-Zip\7z.exe".
:end