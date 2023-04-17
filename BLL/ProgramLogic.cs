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

namespace BLL
{
    public class ProgramLogic
    {
        ShowService showService;
        TheatreBoxOffice theatreBox;

        public ProgramLogic()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            });
            var mapper = config.CreateMapper();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(mapper)
                .BuildServiceProvider();
            showService = new ShowService(serviceProvider.GetService<IMapper>());
            var shows = showService.GetShows();
            var tickets = showService.GetTickets();
            List<Show> lshows = (List<Show>)shows;
            List<Ticket> ltickets = (List<Ticket>)tickets;
            theatreBox = new TheatreBoxOffice(lshows, ltickets);
        }
        public void AddShow(string name, string author, string genre, int countseats, DateTime dateTime, double price)
        {
            theatreBox.AddShow(name, author, genre, countseats, dateTime, price);
            showService.AddShow(theatreBox.shows.Last());
        }
        public string AddTicket(int countshow, string nameofowner)
        {
            if (CheckFreeSeats(countshow))
            {
                theatreBox.BuyTicket(--countshow, nameofowner);
                showService.AddTicket(theatreBox.tickets.Last());
                return "You have successfully purchased a ticket ";
            }
            else
                return "I'm sorry but there are no available seats for this show";
        }
        public string DeleteShow(string nameshow,string nameauthor)
        {
            for (int i = 0; i < theatreBox.shows.Count; i++)
            {
                if (theatreBox.shows[i].Name==nameshow&& theatreBox.shows[i].Author == nameauthor)
                {
                    theatreBox.DeleteShow(i);
                    showService.DeleteShow(nameshow, nameauthor);
                    return "Show was deleted";
                }
            }
            return "This show wasn`t found";
        }
        public string DeleteTicket(string showname, string nameofowner)
        {
            for (int i = 0; i < theatreBox.tickets.Count; i++)
            {
                if (theatreBox.tickets[i].NameShow == showname && theatreBox.tickets[i].NameOfOwner == nameofowner)
                {
                    string check = theatreBox.ReturnTicket(i);
                    if (check == "Too late to return tickets")
                        return check;
                    else
                    {
                        showService.DeleteTicket(showname,nameofowner);
                        return check;
                    }
                }
            }
            return "You haven`t tickets on this show";
        }
        public string CheckSoldTickets(int numshow)
        {
            int countsold = 0;
            for (int i = 0; i < theatreBox.tickets.Count; i++)
            {
                if (theatreBox.tickets[i].NameShow == theatreBox.shows[numshow].Name)
                    countsold++;
            }
            return $"This show has sold {countsold} tickets";
        }
        public List<string> GetShows()
        {
            List<string> shows=new List<string>();
            for (int i = 0; i < theatreBox.shows.Count; i++)
                shows.Add(theatreBox.shows[i].ToString());
            return shows;
        }
        public List<string> GetTickets()
        {
            List<string> tickets = new List<string>();
            for (int i = 0; i < theatreBox.tickets.Count; i++)
                tickets.Add(theatreBox.tickets[i].ToString());
            return tickets;
        }
        public bool CheckFreeSeats(int numshow)
        {
            int countsold = 0;
            int countseat = theatreBox.shows[--numshow].CountSeats;
            for (int i = 0; i < theatreBox.tickets.Count; i++)
            {
                if (theatreBox.tickets[i].NameShow == theatreBox.shows[numshow].Name)
                    countsold++;
            }
            if(countsold<countseat)
                return true;
            else
                return false;
        }
    }
}