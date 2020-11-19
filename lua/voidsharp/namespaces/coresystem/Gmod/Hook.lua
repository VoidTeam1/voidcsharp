local System = System

local arrObj = System.Array(System.Object)


local Hook = System.define("VoidSharp.Hook", {
  Add = function (str, id, callback)
    hook.Add(str, id, function (...)
        if (#{...} > 0) then
          local tbl = callback(arrObj(...))
          if (tbl) then
            return unpack(tbl)
          end
        else
          callback(arrObj())
        end
    end)
  end,
  Run = function (str, tbl)
    hook.Run(str, unpack(tbl))
  end
})
