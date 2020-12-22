-- Generated by CSharp.lua Compiler
local System = System
local Linq = System.Linq.Enumerable
local VoidSharpORMMigrations
local VoidSharpUtilities
System.import(function (out)
  VoidSharpORMMigrations = VoidSharp.ORM.Migrations
  VoidSharpUtilities = VoidSharp.Utilities
end)
System.namespace("VoidSharp.ORM.Migrations", function (namespace)
  namespace.interface("IMigrationManager", function ()
    local UpdateMigrations
    -- <summary>
    -- Updates the database to the latest migration.
    -- </summary>
    -- <param name="database">The database conenction.</param>
    -- <returns></returns>
    UpdateMigrations = function (this, database)
      return System.async(function (async, this, database)
        this:setCurrentVersion(async:await(this:GetLatestMigrationVersion(database)))

        local migrations = Linq.ToList(Linq.Select(Linq.Where(System.typeof(VoidSharpORMMigrations.Migration):getAssembly():GetExportedTypes(), function (t)
          return t:IsSubclassOf(System.typeof(VoidSharpORMMigrations.Migration))
        end), function (t)
          return System.cast(VoidSharpORMMigrations.Migration, System.Activator.CreateInstance(t))
        end, VoidSharpORMMigrations.Migration))

        local highestVersion = 0
        for _, migration in System.each(migrations) do
          local continueLoop
          repeat
            if migration:getVersion() <= this:getCurrentVersion() then
              continueLoop = true
              break
            end

            local migrationName = migration:GetType():getName()

            VoidSharpUtilities.Logger.LogInfo("Applying migration name " .. migrationName .. "!", "Migrations")
            async:await(migration:Up(database))
            VoidSharpUtilities.Logger.LogInfo("Applied migration " .. migrationName .. "!", "Migrations")

            if migration:getVersion() > highestVersion then
              highestVersion = migration:getVersion()
            end
            continueLoop = true
          until 1
          if not continueLoop then
            break
          end
        end

        if highestVersion ~= 0 then
          this:setCurrentVersion(highestVersion)
          async:await(this:UpdateMigrationVersion(database))
        end
      end, nil, this, database)
    end
    return {
      extern = {
        UpdateMigrations = UpdateMigrations
      },
      __metadata__ = function (out)
        return {
          methods = {
            { "UpdateMigrations", 0x186, UpdateMigrations, out.VoidSharp.ORM.Database, System.Task }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)