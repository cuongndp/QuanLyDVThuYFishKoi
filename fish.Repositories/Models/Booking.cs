using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish.Repositories.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime NgayHen { get; set; }
        public TimeSpan GioHen { get; set; }
        public string MoTa { get; set; }
        public decimal GiaTien { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int? ServiceId { get; set; }
        public virtual ServiceModel Service { get; set; }
        public int? DoctorId { get; set; }
        public virtual User Doctor { get; set; }
    }
}
