using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Gateway
{
    public class ClassGateway
    {
        private ApplicationDbContext _context;

        public ClassGateway()
        {
            _context = new ApplicationDbContext();
        }

        public List<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }

        public List<Day> GetDays()
        {
            return _context.Days.ToList();
        }

        public void Allocate(Class aClass)
        {
            _context.Classes.Add(aClass);
        }

    }
}