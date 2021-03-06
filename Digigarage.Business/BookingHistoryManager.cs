using Digigarage.Business.Interface;
using Digigarage.BusinessEntities;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Business
{
    public class BookingHistoryManager : IBookingHistoryManager
    {
        private readonly IBookingHistoryRepository _BookingHistoryRepository;

        public BookingHistoryManager(IBookingHistoryRepository BookingHistoryRepository)
        {
            _BookingHistoryRepository = BookingHistoryRepository;
        }
        

        public BookingHistoryViewModel GetBookingHistory(int? Id)
        {
            return _BookingHistoryRepository.GetBookingHistory(Id);
        }

        public string updateBookingHistory(BookingHistoryViewModel bookingHistory)
        {
            return _BookingHistoryRepository.updateBookingHistory(bookingHistory);
        }
    }
}
