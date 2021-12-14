using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Xunit;

namespace ShopkzTest.Controller
{
    public IActionResult Index()
    {
        ViewData["Message"] = "Hello!";
        return View("Index");
    }
    /* [TestClass]
     public class UnitTest1
     {
         [TestMethod]
         public void HomeMethod()
         {
             // Arrange
             HomeController controller = new HomeController();

             // Act
             ViewResult result = controller.Index() as ViewResult;

             // Assert
             Assert.IsNotNull(result);
         }

         [TestMethod]
         public void CalendarIndex()
         {
             // Arrange
             CalendarsController controller = new CalendarsController();

             // Act
             ViewResult result = controller.Create() as ViewResult;

             // Assert
             Assert.IsNotNull(result);
         }
         [TestMethod]
         public void CategoryTaskIndex()
         {
             // Arrange
             Category_TaskController controller = new Category_TaskController();

             // Act
             ViewResult result = controller.Create() as ViewResult;

             // Assert
             Assert.IsNotNull(result);
         }
         [TestMethod]
         public void EventsIndex()
         {

             // Arrange
             EventsController controller = new EventsController();

             // Act
             ViewResult result = controller.Create() as ViewResult;

             // Assert
             Assert.IsNotNull(result);
         }

         [TestMethod]
         public void NotificationsIndex()
         {

             // Arrange
             NotificationsController controller = new NotificationsController();

             // Act
             ViewResult result = controller.Create() as ViewResult;

             // Assert
             Assert.IsNotNull(result);
         }

         [TestMethod]
         public void OrganizationsIndex()
         {
             // Arrange
             OrganizationsController controller = new OrganizationsController();

             // Act
             ViewResult result = controller.Create() as ViewResult;

             // Assert
             Assert.IsNotNull(result);
         }

         [TestMethod]
         public void UsersIndex()
         {
             // Arrange
             UsersController controller = new UsersController();

             // Act
             ViewResult result = controller.Create() as ViewResult;

             // Assert
             Assert.IsNotNull(result);
         }
     }
 }
 */
}