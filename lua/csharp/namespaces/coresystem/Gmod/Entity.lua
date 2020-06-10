local System = System

-- Entity
local meta = FindMetaTable("Entity")
local entity = table.Copy(meta)

local ent = System.define("GLua.Entity", entity)

-- local ArrayEntity = System.Array(ent)

-- Ents
local funcTbl = table.Copy(ents)

local entsGetAll = ents.GetAll
funcTbl.GetAll = function ()
    local arr = ArrayEntity(unpack(entsGetAll()))
    return arr
end


local Ents = System.define("Void.GLua.Ents", funcTbl)
