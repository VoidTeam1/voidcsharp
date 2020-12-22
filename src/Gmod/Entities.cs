using System;
using System.Collections.Generic;
using System.Linq;

namespace VoidSharp
{
    public static class Entities
    {
        /// <summary>
        /// Returns a table of all existing entities. The table is sequential
        /// </summary>
        /// <returns></returns>
        public static Entity[] GetAll()
        {
            List<Entity> ents = new List<Entity>();
            
            foreach (dynamic gmodEnt in Globals.Ents.GetAll())
            {
                if (gmodEnt != null && gmodEnt.IsValid())
                {
                    ents.Add(Entity.FromGmod(gmodEnt));
                }
            }

            return ents.ToArray();
        }
    }
}