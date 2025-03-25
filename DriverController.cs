using Microsoft.EntityFrameworkCore;
using project1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Controllers
{
    public class DriverController
    {
        Formula1Context formula1 = new Formula1Context();

        public async Task<List<Driver>> GetAllDrivers()
        {
            var drivers = await formula1.Drivers.ToListAsync();
            return drivers;
        }

        public async Task<Driver> GetDriverById(int id)
        {
            var drivers = await formula1.Drivers.FirstOrDefaultAsync(x=>x.DriverId == id);
            return drivers;
        }

        public async Task<Driver> GetDriverByLastName(string lastName)
        {
            var driver = await formula1.Drivers.FirstOrDefaultAsync(x=>x.LastName == lastName);
            return driver;
        }

        public async Task<List<Driver>> GetDriversByNationality(string nationality)
        {
            var drivers = await formula1.Drivers.Where(x=>x.Nationality== nationality).ToListAsync();
            return drivers;
        }
    }
}
