return function (path, funcName, includeF)
    -- Clear old receivers
    -- for k, v in pairs(net.Receivers) do
    --     local funcLower = funcName:lower()
    --     if (string.StartWith(k, funcLower)) then
    --         net.Receivers[k] = nil
    --     end
    -- end

    if (SERVER) then
        AddCSLuaFile(path .. "/manifest.lua")
    end
    include(path .. "/manifest.lua")(path, includeF)

    _G[funcName].Program.Main()
end