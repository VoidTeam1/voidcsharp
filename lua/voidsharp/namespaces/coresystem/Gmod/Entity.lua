local System = System
local throw = System.throw
local InvalidCastException = System.InvalidCastException

-- Entity
local meta = FindMetaTable("Entity")

function meta:ToPlayer()
    if (self:IsPlayer()) then
        return self -- lol wtf
    else
        throw(InvalidCastException("Unable to cast object of type Entity to type Player.", 1))
    end
end

local entity = table.Copy(meta)

local ent = System.define("VoidSharp.Entity", entity)

local ArrayEntity = System.Array(ent)

-- Player
local plyMeta = FindMetaTable("Player")
local ply = table.Copy(plyMeta)


local playerD = System.define("VoidSharp.Player", ply)

local ArrayPlayer = System.Array(playerD)

-- Player table

local plyTbl = table.Copy(player)

local plyGetAll = player.GetAll
plyTbl.GetAll = function ()
    local arr = ArrayPlayer(unpack(plyGetAll()))
    return arr
end

local Player_ = System.define("VoidSharp.Players", plyTbl)

-- Ents
local funcTbl = table.Copy(ents)

local entsGetAll = ents.GetAll
funcTbl.GetAll = function ()
    return System.arrayFromTable(entsGetAll(), ent)
end

local entsByClass = ents.FindByClass
funcTbl.FindByClass = function (str)
    return System.arrayFromTable(entsByClass(str), ent)
end

local entsGetById = ents.GetByIndex
funcTbl.GetById = function (id)
    return Entity(id)
end

local Ents = System.define("VoidSharp.Ents", funcTbl)

