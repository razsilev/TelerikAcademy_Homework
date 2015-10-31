namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        // work with -> JustMockCarsRepository and MoqCarsRepository
        public CarsControllerTests()
            : this(new MoqCarsRepository())
            
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = string.Empty,
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = string.Empty,
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DetailsForCarShouldThrowAnArgumentNullExceptionIfCarIdIsInvalid()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(-1));
        }

        [TestMethod]
        public void SortingCarByMakeShouldMakeSortByMake()
        {
            var model = (List<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(model.Count, this.carsData.All().Count);
        }

        [TestMethod]
        public void SortingCarByYearShouldMakeSortByYear()
        {
            var model = (List<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(model.Count, this.carsData.All().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingCarByInvalidParametherShouldThrowAnException()
        {
            var model = (List<Car>)this.GetModel(() => this.controller.Sort(string.Empty));
        }

        [TestMethod]
        public void SearchingCarByConditionShouldReturnCar()
        {
            var model = (List<Car>)this.GetModel(() => this.controller.Search("bmw"));

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void CarsControllerMastBeCreatedAndWithoutParamets()
        {
            var controller = new CarsController();

            Assert.IsNotNull(controller);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
