using CertificateApp1;

namespace CertificateApp.Tests
{
    public class Service_Tests
    {
        [Test]
        public void TestsOfStatisticsMaxValume()
        {
            var service = new ServiceInMemory("Salon Beauty", "Mariola");
            //Arange
            service.AddPoint(8);
            service.AddPoint(10);
            service.AddPoint(9);
            //Act
            var statistics = service.GetStatistics("Makeup");
            //Assert
            Assert.That(statistics.Max, Is.EqualTo(10));
        }

        [Test]
        public void TestsOfStatisticsMinValume()
        {
            var service = new ServiceInMemory("Salon Beauty", "Mariola");
            //Arange
            service.AddPoint(8);
            service.AddPoint(10);
            service.AddPoint(9);
            //Act
            var statistics = service.GetStatistics("Makeup");
            //Assert
            Assert.That(statistics.Min, Is.EqualTo(8));
        }

        [Test]
        public void TestsOfStatisticsAverageValume()
        {
            var service = new ServiceInMemory("Salon Beauty", "Mariola");
            //Arange
            service.AddPoint(8);
            service.AddPoint(10);
            service.AddPoint(9);
            //Act
            var statistics = service.GetStatistics("Nails");
            //Assert
            Assert.That(statistics.Average, Is.EqualTo(9));
        }
    }
}