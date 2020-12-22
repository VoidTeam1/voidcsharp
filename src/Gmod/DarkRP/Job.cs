using System;
using System.Collections.Generic;

namespace VoidSharp.DarkRP
{
    public class Job
    {
        public Team Team { get; }
        public string Category { get; }
        public string Command { get; }
        public string Description { get; }
        public string[] Models { get; }
        public int Salary { get; }
        public int? MaxPlayers { get; }

        public Job(Team team)
        {
            dynamic jobTable = DarkRP.GetJob(team);
            if (jobTable == null)
            {
                throw new Exception("The specified job does not exist.");
            }

            Category = jobTable.category;
            Command = jobTable.command;
            Description = jobTable.description;
            Salary = jobTable.salary;
            MaxPlayers = jobTable.max;

            var models = new List<string>();
            
            /*
            [[
            if (istable(jobTable.model)) then
                for k, v in ipairs(jobTable.model) do
                    models:Add(v)
                end
            else
                models:Add(jobTable.model)
            end
            ]]
            */

            Models = models.ToArray();
            
            Team = team;
        }

    }
}