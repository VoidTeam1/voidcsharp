
return function (path, funcName)
    print("[CSHARP] Executing code...")

    print("[CSHARP] Loading namespaces..")
    include(path .. "/namespaces/all.lua")(path)

    print("[CSHARP] Loading compiled code..")
    include(path .. "/compiled/manifest.lua")(path .. "/compiled")

    print("[CSHARP] Executing main method..")
    _G[funcName].Program.Main()
end