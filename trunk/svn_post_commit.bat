cd /D "D:\Documents\Programmes\Visual Basic\Visual Studio\Create Synchronicity\trunk\"
set ver=%4
set ver=###%ver%###
set ver=%ver:"###=%
set ver=%ver:###"=%
set ver=%ver:###=%
spawn-visual post-commit.exe sql-log.txt http://synchronicity.sourceforge.net/code/post-commit.php createsoftware synchronicity %* 
package.bat %ver% > buildlog.txt 
