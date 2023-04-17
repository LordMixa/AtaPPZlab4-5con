﻿using AutoMapper;
using DAL;
using DAL.DBEntities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShowService
    {
        private readonly IMapper _mapper;
        public ShowService( IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddShow(Show show)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var showRepository = new ShowRepository(unitOfWork);
                var dbshow = _mapper.Map<DBShow>(show);
                showRepository.Create(dbshow);
                unitOfWork.Save();
            }
        }
        public void AddTicket(Ticket ticket)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var ticketRepository = new TicketRepository(unitOfWork);
                var dbticket = _mapper.Map<DBTicket>(ticket);
                ticketRepository.Create(dbticket);
                unitOfWork.Save();
            }
        }
        public void DeleteShow(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var showRepository = new ShowRepository(unitOfWork);
                showRepository.Delete(id);
                unitOfWork.Save();
            }
        }
        public void DeleteTicket(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var ticketRepository = new TicketRepository(unitOfWork);
                ticketRepository.Delete(id);
                unitOfWork.Save();
            }
        }
        public IEnumerable<Show> GetShows()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var showRepository = new ShowRepository(unitOfWork);
                var dbshows=showRepository.GetAll();
                var shows = _mapper.Map<IEnumerable<Show>>(dbshows);
                return shows;
            }
        }
        public IEnumerable<Ticket> GetTickets()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var ticketRepository = new TicketRepository(unitOfWork);
                var dbtickets = ticketRepository.GetAll();
                var tickets = _mapper.Map<IEnumerable<Ticket>>(dbtickets);
                return tickets;
            }
        }
    }
}