using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL;
using DAL;
using DAL.Repository;
using DAL.DBEntities;
using Microsoft.Extensions.DependencyInjection;

namespace AtaPPZlab4_5con
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new UserMappingProfile());
            //});
            //var mapper = config.CreateMapper();

            //var serviceProvider = new ServiceCollection()
            //    .AddSingleton(mapper)
            //    .BuildServiceProvider();

            //using (var context = new ShowContext())
            //{
            //    var newshow = new DBShow();
            //    newshow.Author = "test1";
            //    newshow.Date = DateTime.Now;
            //    newshow.Price = 1;
            //    newshow.CountSeats = 1;
            //    newshow.Name = "test1";
            //    newshow.Genre = "test1";
            //    newshow.DBShowId = 1;
            //    context.Shows.Add(newshow);
            //    context.SaveChanges();
            //}
            //using (var context = new ShowContext())
            //{
            //    var newticket = new DBTicket();
            //    newticket.Date = DateTime.Now;
            //    newticket.Price = 1;
            //    newticket.NameShow = "test1";
            //    newticket.NameOfOwner = "test1";
            //    context.Tickets.Add(newticket);
            //    context.SaveChanges();
            //}
            //var context = new ShowContext();
            //ShowService showService = new ShowService(serviceProvider.GetService<IMapper>());
            //showService.DeleteShow(2);
            //showService.AddTicket(new Ticket("zcxzczc", 111, "Z.X.c", new DateTime(2020, 1, 31)));
            //var show = showService.GetShows();
            ProgramLogic programLogic =new ProgramLogic();
            //Console.WriteLine(programLogic.AddTicket(3, "Garabere"));
            //Console.WriteLine(programLogic.AddTicket(3, "Dosa nosa"));
            //Console.WriteLine(programLogic.AddTicket(3, "Basosa nosa"));
            //Console.WriteLine(programLogic.AddTicket(3, "Opa nosa"));
            //programLogic.AddShow("Baka", "Anime", "Anime", 5, DateTime.Today, 50);
            //programLogic.AddShow("Vaka", "HAnime", "BAnime", 3, DateTime.Today, 50);
            //Console.WriteLine(programLogic.CheckSoldTickets(1));
            //Console.WriteLine(programLogic.DeleteTicket("Vaka", "Garabere"));
            Console.WriteLine(programLogic.DeleteTicket("Vaka", "Garabere"));
            //programLogic.DeleteShow(1);
            programLogic.GetShows();
            programLogic.GetTickets();
            int i = 1;
            //showService.AddShow(new Show("Avgus", "Billi Ppo", "Boo", 12, new DateTime(2025, 12, 21), 1000));
            //ShowService showService = new ShowService(new DAL.Repository.UnitOfWork());
            Console.ReadLine();
        }
    }
}
