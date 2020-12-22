using System;
using System.Collections.Generic;
using System.Linq;

namespace VoidSharp.DarkRP
{
    // ReSharper disable once InconsistentNaming
    public static class DarkRP
    {
        
        public static bool IsLoaded { get; set; }
        
        public static dynamic GetJob(Team team)
        {
            return Globals.G.RPExtraTeams[team.Index];
        }

        public static List<Job> GetAllJobs()
        {
            var teams = Team.GetAllTeams();
            List<Job> jobs = new List<Job>();
            foreach (Team team in teams)
            {
                Job job = new Job(team);
                jobs.Add(job);
            }

            return jobs;
        }
        
        public static Job GetJobByCommand(string command)
        {
            var teams = Team.GetAllTeams();
            foreach (var team in teams)
            {
                Job job = new Job(team);
                if (job.Command == command)
                {
                    return job;
                }
            }

            return null;
        }
    }
}