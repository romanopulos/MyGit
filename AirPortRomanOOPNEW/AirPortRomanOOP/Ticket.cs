using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Ticket
    {  
        public TicketClass ClassofTicket { get; set; }   
        public TicketCategory TicketCategory { get; set; }     
        public decimal Price { get; set; }

        public Ticket(int ClassofTicket, int TicketCategory, decimal Price)
        {
            this.ClassofTicket = (TicketClass)ClassofTicket;
            this.TicketCategory = (TicketCategory)TicketCategory;
            this.Price = Price;
        }

        public override string ToString()
        {
            return string.Format("The class ticket: {0}, the category {1}, the Price:{2:C}", this.ClassofTicket, 
            this.TicketCategory, this.Price);
        }
    }
}
