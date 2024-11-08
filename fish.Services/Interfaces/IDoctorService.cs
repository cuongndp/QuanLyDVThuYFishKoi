using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fish.Repositories.Models;

namespace fish.Services.Interfaces
{
    public interface IDoctorService
    {
        List<Booking> GetBookingsForDoctor(int doctorId);
    }
}
