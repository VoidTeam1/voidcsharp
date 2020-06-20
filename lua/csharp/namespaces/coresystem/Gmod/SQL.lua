local sql = sql
local sqlEscape = sql.SQLStr
local System = System
local DictStringObject = System.Dictionary(System.String, System.Object)
local ArrayDictStringObject = System.Array(DictStringObject)


local Hook = System.define("Void.GLua.SQLite", {
  Query = function (s, str)
    local q = sql.Query(str)
    if (q == false) then
        System.throw(System.new(DatabaseSQLQueryError, 2, "SQL Error: " .. sql.LastError()))
    end
    if (istable(q)) then
      if (!q) then
        return {}
      end
      local arr = ArrayDictStringObject()
      for _, tbl in ipairs(q) do
          local dict = DictStringObject()
          for key, val in pairs(tbl) do
              dict:AddKeyValue(key, val)
          end
          arr[_] = dict
      end

      return arr
    else
      return q
    end
  end,
  Escape = function (s, str, b)
    return sqlEscape(str, b)
  end
})
