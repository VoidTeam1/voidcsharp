


return function (path, funcName)

    if (SERVER) then
        AddCSLuaFile(path .. "/namespaces/all.lua")
    end
    include(path .. "/namespaces/all.lua")(path)
    
    if (SERVER) then
        AddCSLuaFile(path .. "/compiled/manifest.lua")
    end
    include(path .. "/compiled/manifest.lua")(path .. "/compiled")

    _G[funcName].Program.Main()
end