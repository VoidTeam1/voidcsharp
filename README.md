# VoidSharp
A Garry's Mod C# abstraction layer.

## How to set this up and start making addons?
1. Download voidsharp and put it to your addons folder. Name it `voidsharp`.
2. Create a new folder and follow this template: https://github.com/m0uka/voidsharp-example , basically you need to create a Lua loader that executes your addon and a .csproj where you will be writing C# code, the devenv folder contains the CSharp.lua compiler.
3. Copy compile.bat from https://github.com/VoidTeam1/voidcsharp/blob/master/src/compile.bat and put it into your src folder
4. Compile VoidSharp as a dll, or if you are lazy download it from here: https://github.com/VoidTeam1/voidcsharp/blob/master/src/bin/Debug/netcoreapp3.1/VoidSharp.dll, note you will need to update/compile everytime VoidSharp changes
5. In your project, add a reference to the DLL (this is how it's done in Rider - https://m0uka.dev/u/HMvAgj.png)
6. Your project should now have no errors, the VoidSharp library should be available.
7. If you have no errors in your project, you can transpile the code by running compile.bat
8. Restart your server and your code should be working
