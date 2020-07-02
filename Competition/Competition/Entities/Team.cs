using Competition.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Competition.Entities
{
    public class Team : BaseEntity
    {
        public string Country { get; set; }

        public int GetCount(int id)
        {
            int count = 0;
            AthleteRepository repoA = new AthleteRepository();
            List<Athlete> athletes = repoA.GetAll();

            foreach (var item in athletes)
            {
                if (item.TeamId == id)
                {
                    count++;
                }
            }

            return count;
        }
    }
}