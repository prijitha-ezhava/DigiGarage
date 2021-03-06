using Digigarage.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Business.Interface
{
    public interface IBookingManager
    {
        BookingViewModel GetBooking(int? Id);
        IEnumerable<BookingViewModel> GetAllBooking();
        string CreateBooking(BookingViewModel model);
        string UpdateBooking(BookingViewModel model);
        string DeleteBooking(int? Id);
    }
}
