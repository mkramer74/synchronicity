@echo off
if "%1" == "/?" goto help
if "%1" == ""   goto help
goto start

:help
echo This file is part of Create Synchronicity.
echo Create Synchronicity is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
echo Create Synchronicity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
echo You should have received a copy of the GNU General Public License along with Create Synchronicity.  If not, see http://www.gnu.org/licenses/.
echo Created by:   Clément Pit--Claudel.
echo Web site:     http://synchronicity.sourceforge.net.
echo.
echo.
echo.
echo This program implements the common post-sync script interface defined in
echo Create Synchronicity's manual. It serves as an interface between Create
echo Synchronicity and a smtp client such as blat.exe, the current default.
echo.
echo To use this script, you need to do two things (total estimated time: ^< 5mn)
echo 1. Open your installation folder, and locate the *mail.bat* file, in the 
echo    "scripts" folder. It contains a "SMTP Configuration" section, which you 
echo    should edit to reflect your own SMTP settings.
echo 2. Launch Create Synchronicity, and press Ctrl+O. You are taken to your
echo    configuration folder. Open the .sync file corresponding to the profile 
echo    which you wish to send logs for, and add the following line to it:
echo        Post-sync action:scripts\mail.bat
echo 3. Enjoy!
echo.
echo.
pause

goto end

:start

rem ========================
rem =  SMTP Configuration  =
rem ========================
rem 
rem Customize the following values to match your personal configuration.
rem If you leave username or password empty, Create Synchronicity will try to
rem connect to your SMTP server without authentication.
rem
rem Do not add whitespace after the '=' signs.
rem

set username=
set password=
set server=
set port=25

set sender=
set recipient=

rem ==================
rem =  You're done!  =
rem ==================

set basepath=%~dp0
set mail=%basepath%mail\blat.exe
set log=%basepath%mail\log.txt

set profilename=%~1
set success=%~2
set errors=%~3
set body=%~6

if "%success%" equ "True" (
	if "%errors%" equ "0" (
		set subject=Create Synchronicity - %profilename% completed successfully!
	) else (
		set subject=Create Synchronicity - %profilename% completed with %errors% error^(s^).
	)
) else (
	set subject=Create Synchronicity - %profilename% could not complete.
)

if "%username%" neq "" (
	set usr=-u "%username%"
) else (
	set usr=
)

if "%password%" neq "" (
	set pwd=-pw %password%
) else (
	set pwd=
)

"%mail%" "%body%" -f "%sender%" -server "%server%:%port%" %usr% %pwd% -to "%recipient%" -subject "%subject%" > "%log%"

:end

rem Implementations notes
rem =====================
rem Write 'set var=value', not 'set var =value' or 'set var = value'.
rem To access variables in their definition scope (e.g. an 'if' block), call
rem 'Setlocal EnableDelayedExpansion', and !var! instead of %var%. Use
rem 'EndLocal' at the end of the file.
