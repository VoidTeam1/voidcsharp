VoidSharp = VoidSharp or {}
VoidSharp.Loader = {}

VoidSharp.TimerLastId = 0

VoidSharp.Config = {
    setTimeout = function (f, ms)
        local timerId = "VoidSharp." .. VoidSharp.TimerLastId + 1
        timer.Create(timerId, ms/1000, 1, f)
        return timerId
    end,
    clearTimeout = function (id)
        timer.Remove(id)
    end
}

local function includeFile(str)
    include(str)
end

if (SERVER) then
    AddCSLuaFile("voidsharp/codelauncher.lua")
end

local launcher = include("voidsharp/codelauncher.lua")
VoidSharp.Loader.Launcher = launcher

if (SERVER) then
    AddCSLuaFile("voidsharp/namespaces/all.lua")
end
    
include("voidsharp/namespaces/all.lua")("voidsharp", VoidSharp.Config)
launcher("voidsharp/lib", "VoidSharp", includeFile)

VoidSharp.Loader.Loaded = true

hook.Run("VoidSharp.Loader.Loaded", launcher)
print("[VoidSharp] Launcher loaded!")