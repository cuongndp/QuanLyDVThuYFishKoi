using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModel = Fish.Repositories.Models.ServiceModel;


namespace Fish.Repositories.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string TenDichVu { get; set; }
        public string MoTaDichVu { get; set; }
        public decimal Gia { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
