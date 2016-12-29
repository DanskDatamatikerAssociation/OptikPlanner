using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptikPlanner.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Calendar;
using OptikPlanner.Model;
using OptikPlanner.View;

namespace OptikPlanner.Controller.Tests
{
    [TestClass()]
    public class CalendarViewControllerTests
    {
        private CalendarViewController controller;

        [TestInitialize]
        public void BeforeTest()
        {
            controller = new CalendarViewController(null);
        }


        [TestMethod()]
        public void GetAppointmentsTest()
        {
            var appointments = controller.GetAppointments();
            Assert.AreNotEqual(0, appointments.Count);
            Assert.AreEqual(typeof(APTDETAILS), appointments[0].GetType());
        }

        [TestMethod()]
        public void GetCustomersTest()
        {
            var customers = controller.GetCustomers();
            Assert.AreNotEqual(0, customers.Count);
            Assert.AreEqual(typeof(CUSTOMERS), customers[0].GetType());
        }

        [TestMethod()]
        public void GetRoomsTest()
        {
            var rooms = controller.GetRooms();
            Assert.AreNotEqual(0, rooms.Count);
            Assert.AreEqual(typeof(EYEEXAMROOMS), rooms[0].GetType());

        }

        [TestMethod()]
        public void GetUsersTest()
        {
            var users = controller.GetUsers();
            Assert.AreNotEqual(0, users.Count);
            Assert.AreEqual(typeof(USERS), users[0].GetType());
        }


        [TestMethod()]
        public void GetAppointmentTypeTest()
        {
            var appointments = controller.GetAppointments();
            var firstAppointment = appointments[0];
            Assert.AreEqual(1, firstAppointment.APD_TYPE);

           var type = CalendarViewController.GetAppointmentType(
               firstAppointment);
            Assert.AreEqual("Synsprøve", type);
        }

        [TestMethod()]
        public void GetAppointmentRoomTest()
        {
            var appointments = controller.GetAppointments();
            var firstAppointment = appointments[0];

            var appointmentRoom = controller.GetAppointmentRoom(firstAppointment);
            Assert.AreEqual(1, appointmentRoom.ERO_STAMP);

        }

        [TestMethod()]
        public void GetAppointmentUserTest()
        {
            var appointments = controller.GetAppointments();
            var firstAppointment = appointments[0];

            var appointmentUser = controller.GetAppointmentUser(firstAppointment);
            Assert.AreEqual(11, appointmentUser.US_STAMP);
        }

    }
}