using project1.Controllers;
using project1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Presentation
{
    public class Display
    {
        TeamController teamController=new TeamController();
        DriverController driverController=new DriverController();
        public async Task ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - End");
                Console.WriteLine("2 -  GetTeams");
                Console.WriteLine("3 -  GetTeamById <id>");
                Console.WriteLine("4 -  GetTeamsByCountry <country>");
                Console.WriteLine("5 -  GetOldestTeam");
                Console.WriteLine("6 -  GetDrivers");
                Console.WriteLine("7 -  GetDriverById <id>");
                Console.WriteLine("8 -  GetDriverByName <lastName>");
                Console.WriteLine("9 -  GetDriversByNationality <nationality>");

                int n = int.Parse(Console.ReadLine());

                if (n == 1)
                {
                    break;
                }

                switch(n)
                {
                    case 1:
                        Console.WriteLine();
                        break;
                        case 2:
                        List<Team> team= await teamController.GetAllTeams();
                        if (team.Count == 0)
                        {
                            Console.WriteLine("Prazno");
                        }
                        else
                        {
                            foreach (var item in team)
                            {
                                Console.WriteLine(item.TeamName);
                            }
                        }
                        break;
                        case 3:
                        Console.WriteLine("iD=?");
                        int id= int.Parse(Console.ReadLine());
                        Team team1 = await teamController.GetTeamById(id);
                        Console.WriteLine($"{team1.TeamName} - {team1.FoundationYear} - {team1.Country}");
                        break;
                    case 4:
                        Console.WriteLine("Country=?");
                        string country= Console.ReadLine();
                        List<Team> teams = await teamController.GetTeamsByCountry(country);
                        if (teams.Count == 0)
                        {
                            Console.WriteLine("Prazno");
                        }
                        else
                        {
                            foreach (var item in teams)
                            {
                                Console.WriteLine(item.TeamName);
                            }
                        }
                        break;
                        case 5:
                        Team team2 = await teamController.GetOldestTeam();
                        Console.WriteLine(team2.TeamName);
                        break;
                        case 6:
                        List<Driver> driver = await driverController.GetAllDrivers();
                        if (driver.Count == 0)
                        {
                            Console.WriteLine("Prazno");
                        }
                        else
                        {
                            foreach (var item in driver)
                            {
                                Console.Write(item.FirstName);
                                Console.WriteLine(item.LastName);
                            }
                        }
                        break;
                        case 7:
                        Console.WriteLine("iD=?");
                        int id1 = int.Parse(Console.ReadLine());
                        Driver driver1 = await driverController.GetDriverById(id1);
                        Console.WriteLine($"{driver1.FirstName} - {driver1.LastName}");
                        break;
                        case 8:
                        Console.WriteLine("Lastname=?");
                        string name = Console.ReadLine();
                        Driver drivers = await driverController.GetDriverByLastName(name);
                        Console.WriteLine(drivers.FirstName);
                        break;
                        case 9:
                        Console.WriteLine("Nationaly=?");
                        string nation = Console.ReadLine();
                        List<Driver> drivers2 = await driverController.GetDriversByNationality(nation);
                        if (drivers2.Count == 0)
                        {
                            Console.WriteLine("Prazno");
                        }
                        else
                        {
                            foreach (var item in drivers2)
                            {
                                Console.WriteLine(item.FirstName);
                            }
                        }
                        break;
                }
            }



        }
    }
}
