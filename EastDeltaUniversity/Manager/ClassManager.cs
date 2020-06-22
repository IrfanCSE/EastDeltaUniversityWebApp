using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Gateway;
using EastDeltaUniversity.Models;
using EastDeltaUniversity.Models.ViewModels;
using Microsoft.Ajax.Utilities;

namespace EastDeltaUniversity.Manager
{
    public class ClassManager
    {
        private ClassGateway _classGateway;

        public ClassManager()
        {
            _classGateway = new ClassGateway();
        }

        public List<Room> GetRooms()
        {
            return _classGateway.GetRooms();
        }

        public List<Day> GetDays()
        {
            return _classGateway.GetDays();
        }

        public void Allocate(Class aClass)
        {
            _classGateway.Allocate(aClass);
        }

        public List<ClassView> ClassInfo(int departmentId)
        {
            return _classGateway.ClassInfo(departmentId);
        }

        public void Unassign()
        {
            _classGateway.Unassign();
        }

        public void RoomSave(Room room)
        {
            _classGateway.RoomSave(room);
        }

        public Room GetRoomById(int? id)
        {
            return _classGateway.GetRoomById(id);
        }

        public void RoomDelete(int id)
        {
            _classGateway.RoomDelete(id);
        }


    }
}