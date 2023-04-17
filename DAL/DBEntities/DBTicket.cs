using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBEntities
{
    public class DBTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DBTicketId { get; set; }
        public string NameShow { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string NameOfOwner { get; set; }
    }
}
