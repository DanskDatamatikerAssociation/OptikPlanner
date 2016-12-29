using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptikPlanner.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptikPlanner.Controller.Tests
{
    [TestClass()]
    public class CreateAppointmentControllerTests
    {
        private CreateAppointmentController controller;

        [TestInitialize]
        public void BeforeTest()
        {
            controller = new CreateAppointmentController(null);
        }

        [TestMethod()]
        public void CreateAppointmentControllerTest()
        {

        }

        [TestMethod()]
        public void PostAppointmentTest()
        {

        }

        [TestMethod()]
        public void GetNextAppointmentIdTest()
        {

        }

        [TestMethod()]
        public void GetAppointmentsTest()
        {

        }

        [TestMethod()]
        public void GetRoomsTest()
        {

        }

        [TestMethod()]
        public void GetUsersTest()
        {

        }

        [TestMethod()]
        public void GetCustomersTest()
        {

        }

        [TestMethod()]
        public void GetAppointmentRoomTest()
        {

        }

        [TestMethod()]
        public void GetAppointmentUserTest()
        {

        }

        [TestMethod()]
        public void PutAppointmentTest()
        {

        }

        [TestMethod()]
        public void FindCustomerWithCprTest()
        {
            var testCustomer = controller.FindCustomerWithCpr("190303-0103");
            Assert.AreEqual("Hansen", testCustomer.CS_LASTNAME);
        }

        [TestMethod()]
        public void GetFutureAppointmentsTest()
        {
            var testCustomer = controller.FindCustomerWithCpr("190303-0103");
            Assert.AreEqual("Hansen", testCustomer.CS_LASTNAME);

            var futureAppointments = controller.GetFutureAppointments(testCustomer);
            Assert.IsTrue(futureAppointments.Count > 0);

        }

        [TestMethod()]
        public void GetPastAppointmentsTest()
        {

        }
    }
}