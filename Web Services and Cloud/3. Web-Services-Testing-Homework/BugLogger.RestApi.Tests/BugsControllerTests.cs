﻿using System;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using BugLogger.DataLayer;
using BugLogger.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugLogger.RestApi.Tests.Fakes;
using BugLogger.RestApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace BugLogger.RestApi.Tests
{
    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1"
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2"
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3"
                }
            };

            fakeRepo.Entities = bugs;

            var controller = new BugsController(fakeRepo as IRepository<Bug>);

            //act

            var result = controller.GetAll();

            //assert

            CollectionAssert.AreEquivalent(bugs, result.ToList<Bug>());
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            //arrange
            var repo = new FakeRepository<Bug>();
            repo.IsSaveCalled = false;
            repo.Entities = new List<Bug>();
            var bug = new Bug()
            {
                Text = "NEW TEST BUG"
            };
            var controller = new BugsController(repo);
            this.SetupController(controller);

            //act
            controller.PostBug(bug);

            //assert
            Assert.AreEqual(repo.Entities.Count, 1);
            var bugInDb = repo.Entities.First();
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LogDate);
            Assert.AreEqual(Status.Pending, bugInDb.Status);
            Assert.IsTrue(repo.IsSaveCalled);
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection_WithMocks()
        {
            //arrange
            var repo = Mock.Create<IRepository<Bug>>();

            Bug[] bugs =
            {
                new Bug() { Text = "Bug1" },
                new Bug() { Text = "Bug2" }
            };

            Mock.Arrange(() => repo.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(repo);
            //act
            var result = controller.GetAll();

            //assert
            CollectionAssert.AreEquivalent(bugs, result.ToArray<Bug>());
        }

        [TestMethod]
        public void GetBugsAfterSpecificDate_WhenDateIsValid_ShowdReturnBugsWithBiggerExperitionDate()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1",
                    LogDate = DateTime.Now
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2",
                    LogDate = DateTime.Now.AddDays(5)
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3",
                    LogDate = DateTime.Now
                }
            };

            fakeRepo.Entities = bugs;

            var controller = new BugsController(fakeRepo as IRepository<Bug>);

            //act
            var date = DateTime.Now.AddDays(1);
            var result = controller.GetAfter(date).ToList<Bug>();

            //assert

            Assert.AreEqual(bugs[1], result[0]);
        }

        [TestMethod]
        public void GetBugsByStatus_WhenStatusIsValid_ShowdReturnBugsCollectionFromSearchedStatus()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1",
                    Status = Status.Pending
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2",
                    Status = Status.Fixed
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3",
                    Status = Status.Fixed
                }
            };

            fakeRepo.Entities = bugs;

            var controller = new BugsController(fakeRepo as IRepository<Bug>);

            //act
            var result = controller.GetByStatus(Status.Fixed).ToList<Bug>();

            //assert
            int numberOfBugsWithStatusFixed = 2;
            Assert.AreEqual(numberOfBugsWithStatusFixed, result.Count);
        }

        [TestMethod]
        public void ChangeBugStatus_WhenStatusIsChanged_ShowdReturnBugsCollectionFromSearchedStatus()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Text = "TEST NEW BUG 1",
                    Status = Status.Pending
                }
            };

            fakeRepo.Entities = bugs;

            var controller = new BugsController(fakeRepo as IRepository<Bug>);

            this.SetupController(controller);

            //act
            controller.PutBug(1, Status.Fixed);

            //assert

            Assert.AreEqual(Status.Fixed, bugs[0].Status);
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}