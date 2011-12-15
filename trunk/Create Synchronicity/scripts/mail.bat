@echo off

REM Don't put spaces between variable and assignement sign: write set var=value, otherwise the assignment doesn't happen. 
REM For some reason, changing 'subject="..."' to 'subject=...' confuses batch, which complains about an unexpected '.'
REM To access variables in their definition scope (eg. 'if' block), use 'Setlocal EnableDelayedExpansion', and !var! instead of %var%. Use 'EndLocal' at the end of the file.

set basepath=%~dp0
set mail=%basepath%mail\blat.exe
set log=%basepath%mail\log.txt

set profilename=%~1
set success=%~2
set errors=%~3
set body=%~6

set username=
set password=
set server=smtp.sfr.fr
set port=25

set sender=createsoftware@users.sourceforge.net
set recipient=clement.pit+sync-logs@gmail.com

set subject=
if "%success%" equ "True" (
	if "%errors%" equ "0" (
		set subject=Create Synchronicity - %profilename% completed successfully!
	) else (
		set subject=Create Synchronicity - %profilename% completed with %errors% error(s).
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