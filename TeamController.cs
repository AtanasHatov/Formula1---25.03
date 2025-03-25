using Microsoft.EntityFrameworkCore;
using project1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Controllers
{
    public class TeamController
    {
        Formula1Context formula1=new Formula1Context();

        public async Task<List<Team>> GetAllTeams()
        {
            var teams = await formula1.Teams.ToListAsync();
            return teams;
        }

        public async Task<Team> GetTeamById(int id)
        {
            var teams=await formula1.Teams.FirstOrDefaultAsync(t=>t.TeamId==id);
            return teams;
            
        }

        public async Task<List<Team>> GetTeamsByCountry(string country)
        {
            var teams = await formula1.Teams.Where(t => t.Country == country).ToListAsync();
            return teams;
        }

        public async Task<Team> GetOldestTeam()
        {
            var team = await formula1.Teams.OrderBy(x=>x.FoundationYear).FirstOrDefaultAsync();
            return team;
        }
    }
}
