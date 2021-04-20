del /S /Q "obj\Debug\netcoreapp3.1\.NETCoreApp,Version=v3.1.AssemblyAttributes.cs"
cd ../devenv/
CSharp.lua.Launcher.exe -s ../src -d ../lua/voidsharp/lib -c -a -metadata -module
cd ../src/