using BLL;
using System;
using System.Collections.Generic;

namespace PL
{
    public class Menu
    {
        public ProgramLogic programLogic;
        public CheckInfo checkInfo;
        public void MainMenu()
        {
            programLogic = new ProgramLogic();
            checkInfo= new CheckInfo();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Theatre box office:\n1-Create new Show" +
                    "\n2-Delete Show\n3-Buy Ticket\n4-Return Ticket" +
                    "\n5-Get info about Shows\n6-Get info about Tickets\n7-Check sold tickets on show\n8-Exit");
                string check=Console.ReadLine();
                switch(check) 
                {
                    case "1":
                        CreateShow();
                        break;
                    case "2":
                        DeleteShow();
                        break;
                    case "3":
                        BuyTicket();
                        break;
                    case "4":
                        ReturnTicket();
                        break;
                    case "5":
                        GetShows();
                        break;
                    case "6":
                        GetTickets();
                        break;
                    case "7":
                        CheckSoldTickets();
                        break;
                    case "8":
                        break;
                    default: 
                        IncorrectData();
                        WaitMenu();
                        break;
                }
                if (check == "8")
                    break;
            }
        }

        private void CheckSoldTickets()
        {
            Console.WriteLine("Enter a number of show");
            string nameshow = Console.ReadLine();
            if (checkInfo.CheckShow(programLogic.theatreBox, nameshow))
                Console.WriteLine(programLogic.CheckSoldTickets(int.Parse(nameshow)));
            else
                IncorrectData();
            WaitMenu();
        }

        private void CreateShow()
        {
            Console.WriteLine("Enter a name of show");
            string nameshow = Console.ReadLine();
            Console.WriteLine("Enter an author of show");
            string authorshow = Console.ReadLine();
            Console.WriteLine("Enter a genre of show");
            string genreshow = Console.ReadLine();
            string countseat = "";
            string price = "";
            string date = "";
            while (true)
            {
                Console.WriteLine("Enter a count of seats on show");
                countseat = Console.ReadLine();
                if (checkInfo.IntTryParse(countseat))
                    break;
                else
                    IncorrectData();
            }
            while (true)
            {
                Console.WriteLine("Enter a price of show");
                price = Console.ReadLine();
                if (checkInfo.DoubleTryParse(price))
                    break;
                else
                    IncorrectData();
            }
            while (true)
            {
                Console.WriteLine("Enter a date of show");
                date = Console.ReadLine();
                if (checkInfo.DateTryParse(date))
                    break;
                else
                    IncorrectData();
            }
            programLogic.AddShow(nameshow, authorshow,genreshow,int.Parse(countseat),DateTime.Parse(date),double.Parse(price));

        }
        private void GetTickets()
        {
            Console.WriteLine("Enter a number of show");
            string nameshow = Console.ReadLine();
            if (checkInfo.CheckShow(programLogic.theatreBox, nameshow))
            {
                List<string> list = programLogic.GetTickets(int.Parse(nameshow));
                if (list.Count == 0)
                {
                    Console.WriteLine("No tickets on this show\n");
                    WaitMenu();
                }
                else
                {
                    for (int i = 0; i < list.Count; i++)
                        Console.WriteLine(list[i]);
                    WaitMenu();
                }
            }
            else
            {
                IncorrectData();
                WaitMenu();
            }
        }

        private void GetShows()
        {
            List<string> list = programLogic.GetShows();
            for(int i=0;i<list.Count;i++) 
                Console.WriteLine(list[i]);
            WaitMenu();
        }

        private void ReturnTicket()
        {
            while (true)
            {
                Console.WriteLine("Enter a number of show");
                string nameshow = Console.ReadLine();
                if (checkInfo.CheckShow(programLogic.theatreBox, nameshow))
                {
                    Console.WriteLine("Enter the name for which the ticket was purchased");
                    string nameown = Console.ReadLine();
                    Console.WriteLine(programLogic.DeleteTicket(int.Parse(nameshow), nameown));
                    WaitMenu();
                    break;
                }
                else
                {
                    IncorrectData();
                    WaitMenu();
                    break;
                }
            }
        }

        private void DeleteShow()
        {
            while (true)
            {
                Console.WriteLine("Enter a number of show");
                string nameshow = Console.ReadLine();
                if (checkInfo.CheckShow(programLogic.theatreBox, nameshow))
                {
                    Console.WriteLine(programLogic.DeleteShow(int.Parse(nameshow)));
                    WaitMenu();
                    break;
                }
                else
                {
                    IncorrectData();
                    WaitMenu();
                    break;
                }
            }
        }

        private void BuyTicket()
        {
            Console.WriteLine("Enter a number of show");
            string nameshow = Console.ReadLine();
            if (checkInfo.CheckShow(programLogic.theatreBox, nameshow))
            {
                Console.WriteLine("Enter the your name");
                string nameown = Console.ReadLine();
                Console.WriteLine(programLogic.AddTicket(int.Parse(nameshow), nameown));
                WaitMenu();
            }
            else{
                IncorrectData();
                WaitMenu();
            }
        }

        private void IncorrectData()
        {
            Console.WriteLine("Incorrect data\n");
        }
        private void WaitMenu()
        {
            Console.WriteLine("Press 'Enter' to continue\n");
            Console.ReadLine();
        }
    }
}