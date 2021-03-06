using Digigarage.BusinessEntities;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using Digigarage.Data.Models;
using AutoMapper;
using System.Data.Entity;
using System.Linq;

namespace Digigarage.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DigiGarageEntities _dbContext;

        public BookingRepository()
        {
            _dbContext = new DigiGarageEntities();
        }
        public string CreateBooking(BookingViewModel model)
        {
            if (model != null)
            {
                int noOfBooking = _dbContext.Bookings.Where(a => a.VehicleId == model.VehicleId).Where(a => a.ServiceId == model.ServiceId && a.Status!=3 && a.Status!=4).Count();
                if (noOfBooking != 0) 
                {
                    return "Exist";
                }
                    
                model.BookingDate = DateTime.Now;
                model.Status = 1;
                if (model.ServiceId == 4)
                {
                    model.DepartmentId = 2;
                }
                else if (model.ServiceId == 5)
                {
                    model.DepartmentId = 3;
                }
                else
                {
                    model.DepartmentId = model.ServiceId;
                }
                Booking entity = Mapper.Map<BookingViewModel, Booking>(model);
                _dbContext.Bookings.Add(entity);
                _dbContext.SaveChanges();
                BookingHistory bookingHistory = new BookingHistory();
                bookingHistory.ServiceId = model.ServiceId;
                bookingHistory.BookingId = entity.BookingId;
                bookingHistory.VehicleId = model.VehicleId;
                bookingHistory.DepartmentId = model.DepartmentId;
                _dbContext.BookingHistories.Add(bookingHistory);
                _dbContext.SaveChanges();
                return "Booking added";
                
            }
            return "Model is null";
        }

        public string DeleteBooking(int? Id)
        {
            Booking entity = _dbContext.Bookings.Find(Id);
            _dbContext.Bookings.Remove(entity);
            _dbContext.SaveChanges();
            return "Deleted";
        }

        public IEnumerable<BookingViewModel> GetAllBooking()
        {
            IEnumerable<Booking> Booking = _dbContext.Bookings;
            IEnumerable<BookingViewModel> bookingsEntities =
                Mapper.Map<IEnumerable<BookingViewModel>>(Booking);
            return bookingsEntities;
        }

        

        public BookingViewModel GetBooking(int? Id)
        {
            BookingViewModel bookingsEntities = Mapper.Map<BookingViewModel>(_dbContext.Bookings.Find(Id));
            return bookingsEntities;
        }

       
        public string UpdateBooking(BookingViewModel model)
        {
            if (model != null)
            {
                Booking entity = _dbContext.Bookings.Find(model.BookingId);
                Mapper.Map(model, entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return "Booking updated";
            }
            return "Model is null";
        }
    }
}
