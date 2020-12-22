using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoidSharp.ORM;
using VoidSharp.Utilities;

namespace VoidSharp.ORM.Migrations
{
    public interface IMigrationManager
    {
        public int CurrentVersion { get; set; }
        
        /// <summary>
        /// Updates the database to the latest migration.
        /// </summary>
        /// <param name="database">The database conenction.</param>
        /// <returns></returns>
        public async Task UpdateMigrations(Database database)
        {
            CurrentVersion = await GetLatestMigrationVersion(database);

            List<Migration> migrations = typeof(Migration)
                .Assembly.GetExportedTypes()
                .Where(t => t.IsSubclassOf(typeof(Migration)))
                .Select(t => (Migration)Activator.CreateInstance(t))
                .ToList();

            int highestVersion = 0;
            foreach (var migration in migrations)
            {
                if (migration.Version <= CurrentVersion) continue;
                
                string migrationName = migration.GetType().Name;
                
                Logger.LogInfo($"Applying migration name {migrationName}!", "Migrations");
                await migration.Up(database);
                Logger.LogInfo($"Applied migration {migrationName}!", "Migrations");

                if (migration.Version > highestVersion)
                {
                    highestVersion = migration.Version;
                }
            }

            if (highestVersion != 0)
            {
                CurrentVersion = highestVersion;
                await UpdateMigrationVersion(database);
            }
        }

        /// <summary>
        /// Returns the latest migration version.
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public Task<int> GetLatestMigrationVersion(Database database);

        public Task<int> GetLatestMigrationTimesUpdated(Database database);
        public Task UpdateMigrationVersion(Database database);
    }
}