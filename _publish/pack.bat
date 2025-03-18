@echo off
ECHO Batak, ktery vytvori baliky pro NUGET.
ECHO Baliky by mely mit nastavenou verzi a popisky zmen ve svych *.csproj
ECHO Budou se pakovat projekty:
ECHO - EasyConsole
ECHO Ve vsech *.csproj je treba nastavit:
ECHO - Spravnou verzi
ECHO - PackageReleaseNotes
PAUSE
dotnet pack "..\EasyConsole\EasyConsole.csproj" -c Release -o .\
ECHO .
ECHO .
ECHO .
ECHO Vytvoreni baliku probehlo.
ECHO Nyni budou publikovany na OcelovyNuget. 
ECHO Ted je chvile je zkontrolovat (je spravne nastavena verze?, jsou zde pouze baliky, ktere bud publikovany?).
ECHO Pokud je neco spatne, tak CTRL + C pro zruseni, jinak pokracovat libovolnou klavesou.
PAUSE
nuget push *
ECHO Nyni Budou smazany nepotrebne *.nupkg baliky
ECHO To je treba udelat, protoze pri publikace jsou publikovany vsechny baliky z tohoto adresare
PAUSE
del *.nupkg
ECHO Smazano.
PAUSE