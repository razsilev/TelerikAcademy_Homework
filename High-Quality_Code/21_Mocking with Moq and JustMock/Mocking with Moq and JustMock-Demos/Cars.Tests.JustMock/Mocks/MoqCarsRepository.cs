namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System.Linq;

    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.Is<int>(id => id != -1))).Returns(this.FakeCarCollection.First());
            mockedCarsRepository.Setup(r => r.GetById(It.Is<int>(id => id == -1))).Returns((Car)null);
            // add sort
            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());
            mockedCarsRepository.SetupGet(r => r.TotalCars).Returns(this.FakeCarCollection.Count);
            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
