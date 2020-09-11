VoidSharp = VoidSharp or {}
VoidSharp.Loader = {}

if (SERVER) then
    AddCSLuaFile("voidsharp/codelauncher.lua")
end

local launcher = include("voidsharp/codelauncher.lua")
VoidSharp.Loader.Launcher = launcher

if (SERVER) then
    AddCSLuaFile("voidsharp/namespaces/all.lua")
end
    
include("voidsharp/namespaces/all.lua")("voidsharp")

VoidSharp.Loader.Loaded = true

hook.Run("VoidSharp.Loader.Loaded", launcher)
print("[VoidSharp] Launcher loaded!")

/*
