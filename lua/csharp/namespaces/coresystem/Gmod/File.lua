local System = System

local ArrayString = System.Array(System.String)

local funcTbl = table.Copy(file)

local fileFind = file.Find
funcTbl.FindFiles = function (name, path, sorting)
    local tbl1, tbl2 = fileFind(name, path, sorting)
    local arr = ArrayString(unpack(tbl1))
    return arr
end

funcTbl.FindDirs = function (name, path, sorting)
    local tbl1, tbl2 = fileFind(name, path, sorting)
    local arr2 = ArrayString(unpack(tbl2))
    return arr2
end


local File = System.define("Void.GLua.File", funcTbl)