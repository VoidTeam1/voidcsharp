local sql = sql
local sqlEscape = sql.SQLStr
local System = System
local DictStringObject = System.Dictionary(System.String, System.Object)
local ListDictStringObject = System.List(DictStringObject)

local VoidChar2ORM
System.import(function (out)
  VoidChar2ORM = VoidChar2.ORM
end)

local SQLite = System.define("VoidSharp.SQLite", {
  Query = function (s, str)
    local task = System.TaskCompletionSource()

    local q = sql.Query(str)
    if (q == false) then
        System.throw(System.Exception("SQL Error: " .. sql.LastError()))
    end

    if (q == nil) then
        q = {}
    end

    if (istable(q)) then
      if (!q) then
        return {}
      end
      local arr = ListDictStringObject()
      for _, tbl in ipairs(q) do
          local dict = DictStringObject()
          for key, val in pairs(tbl) do
              dict:AddKeyValue(key, val)
          end
          arr:Add(dict)
      end

      task:SetResult(arr)
    else
      task:SetResult(q)
    end

    return task:getTask()
  end,
  Escape = function (s, str, b)
    return sqlEscape(str, b)
  end
})

local mysqlooConn = nil

local MySQLoo = System.define("VoidSharp.MySQLoo", {
  Connect = function (s, credentials)
    local task = System.TaskCompletionSource()
    mysqlooConn = mysqloo.connect(credentials.Host, credentials.Username, credentials.Password, credentials.Database, credentials.Port)
    mysqlooConn:connect()

    mysqlooConn.onConnected = function (db)
      local result = VoidChar2ORM.DatabaseConnectionResult(false, nil)
      task:SetResult(result)
    end

    mysqlooConn.onConnectionFailed = function (db, err)
      local result = VoidChar2ORM.DatabaseConnectionResult(true, err)
      task:SetResult(result)
    end

    return task:getTask()
  end,
  Query = function (s, str)
    local task = System.TaskCompletionSource()

    local query = mysqlooConn:query(str)
    query:start()

    query.onSuccess = function (q, data)
      if (istable(data)) then
        local arr = ListDictStringObject()
        for _, tbl in ipairs(data) do
            local dict = DictStringObject()
            for key, val in pairs(tbl) do
                dict:AddKeyValue(key, val)
            end
            arr:Add(dict)
        end

        task:SetResult(arr)
      else
        task:SetResult(data)
      end
    end

    query.onError = function (q, err, sql)
      System.throw(System.Exception("SQL Error: " .. err))
    end

    return task:getTask()
  end,
  Escape = function (s, str, b)
    return mysqlooConn:escape(str)
  end
})
