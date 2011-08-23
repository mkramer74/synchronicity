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

@set REV=%1
@REM Inherits other variables from build.bat

echo (*) Building r%REV%
call build.bat "r%REV%"

echo (*) Creating current-build.txt
(
echo.
echo -----
) >> %LOG%

(
echo Current build: r%REV% & date /t & time /t
echo.
echo "https://sourceforge.net/projects/synchronicity/files/Create Synchronicity/Unreleased (SVN Builds)/Create_Synchronicity-r%REV%.zip/download"
echo "https://sourceforge.net/projects/synchronicity/files/Create Synchronicity/Unreleased (SVN Builds)/Create_Synchronicity_Setup-r%REV%.exe/download"
echo "https://sourceforge.net/projects/synchronicity/files/Create Synchronicity/Unreleased (SVN Builds)/Create_Synchronicity-r%REV%-DEBUG.zip/download"
echo "https://sourceforge.net/projects/synchronicity/files/Create Synchronicity/Unreleased (SVN Builds)/Create_Synchronicity-r%REV%-Linux.zip/download"
echo "https://sourceforge.net/projects/synchronicity/files/Create Synchronicity/Unreleased (SVN Builds)/Create_Synchronicity-r%REV%-Extensions.zip/download"
) > build\current-build.txt

echo (*) Uploading builds to frs.sourceforge.net and rev info to web.sourceforge.net
(
echo.
echo -----
echo Uploading files via SCP.
"C:\Program Files (x86)\PuTTY\pscp.exe" "%BUILD%\current-build.txt" "createsoftware,synchronicity@web.sourceforge.net:/home/groups/s/sy/synchronicity/htdocs/code"
"C:\Program Files (x86)\PuTTY\pscp.exe" "%BUILD%\Create_Synchronicity-r%REV%.zip" "%BUILD%\Create_Synchronicity-r%REV%-DEBUG.zip" "%BUILD%\Create_Synchronicity_Setup-r%REV%.exe" "%BUILD%\Create_Synchronicity-r%REV%-Linux.zip" "%BUILD%\Create_Synchronicity-r%REV%-Extensions.zip" "createsoftware,synchronicity@frs.sourceforge.net:/home/pfs/project/s/sy/synchronicity/Create Synchronicity/Unreleased (SVN Builds)"
) >> %LOG%

echo (*) Building manual and uploading it to web.sourceforge.net.
(
echo.
echo -----
call manual.bat
) >> %LOG%

@goto end

:help
@echo This script is designed to be called by a SVN hook script.
@echo If used from the command line, it should be passed the revision number as its first parameter.
@echo Requires 7-zip installed in "C:\Program Files\7-Zip\7z.exe" and Putty installed in "C:\Program Files (x86)\PuTTY\pscp.exe".
@echo Pageant (putty key handler) should know the private key to connect to the scp server.
:end