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

local ent = System.define("Void.GLua.Entity", entity)

local ArrayEntity = System.Array(ent)

-- Player
local plyMeta = FindMetaTable("Player")
local ply = table.Copy(plyMeta)


local playerD = System.define("Void.GLua.Player", ply)

local ArrayPlayer = System.Array(playerD)

-- Player table

local plyTbl = table.Copy(player)

local plyGetAll = player.GetAll
plyTbl.GetAll = function ()
    local arr = ArrayPlayer(unpack(plyGetAll()))
    return arr
end

local Player_ = System.define("Void.GLua.Players", plyTbl)

-- Ents
local funcTbl = table.Copy(ents)

local entsGetAll = ents.GetAll
funcTbl.GetAll = function ()
    local arr = ArrayEntity(unpack(entsGetAll()))
    return arr
end


local Ents = System.define("Void.GLua.Ents", funcTbl)

