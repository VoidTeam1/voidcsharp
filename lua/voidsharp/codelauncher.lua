return function (path, funcName)
    if (SERVER) then
        AddCSLuaFile(path .. "/manifest.lua")
    end
    include(path .. "/manifest.lua")(path)

    _G[funcName].Program.Main()
end