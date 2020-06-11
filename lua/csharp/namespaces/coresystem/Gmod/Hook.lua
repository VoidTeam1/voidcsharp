local System = System

local arrObj = System.Array(System.Object)


local Hook = System.define("Void.GLua.Hook", {
  Add = function (str, id, callback)
    hook.Add(str, id, function (...)
        local tbl = callback(arrObj(...))
        if (tbl) then
          return unpack(tbl)
        end
    end)
  end,
  Run = function (str, tbl)
    hook.Run(str, unpack(tbl))
  end
})
