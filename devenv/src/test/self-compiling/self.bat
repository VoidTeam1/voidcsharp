set dir=bin/Release/PublishOutput/
dotnet publish ../../ --configuration Release --output %dir%
set obj="../../CSharp.lua/obj"
if exist %obj% rd /s /q %obj%
dotnet "%dir%CSharp.lua.Launcher.dll" -s ../../CSharp.lua/ -d out -l %dir%Microsoft.CodeAnalysis.CSharp.dll;%dir%Microsoft.CodeAnalysis.dll -metadata
rd /s /q bin
pause