namespace StructuralDesign.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Data.Sections;
    using Xunit;

    public class SectionsServiceTests
    {
        [Fact]
        public void IsCorrectAreaCalculationOfRectangle()
        {
            var rectangle = new Rectangle(2, 3);

            var actualAreaValue = rectangle.Area();
            var expectedAreaValue = 2 * 3;

            Assert.Equal(expectedAreaValue, actualAreaValue);
        }

        [Fact]
        public void IsCorrectAreaCalculationOfDoubleT()
        {
            var doubleT = new DoubleT(100, 20, 1, 1);

            var actualAreaValue = doubleT.Area();
            var expectedAreaValue = (98 * 1) + (2 * 20 * 1);

            Assert.Equal(expectedAreaValue, actualAreaValue);
        }

        [Fact]
        public void IsCorrectInertialMomentAndRadiusCalculationOfRectangle()
        {
            var rectangle = new Rectangle(50, 25);

            var actualInertialMomentY = rectangle.InertialMomentY();
            double expectedInertialMomentY = 25.0 * 50 * 50 * 50 / 12;
            var actualInertialRadiusY = rectangle.InertialRadiusY();
            var expectedInertialRadiusY = Math.Sqrt(expectedInertialMomentY / 25 / 50);

            var actualInertialMomentZ = rectangle.InertialMomentZ();
            var expectedInertialMomentZ = 50.0 * 25 * 25 * 25 / 12;
            var actualInertialRadiusZ = rectangle.InertialRadiusZ();
            var expectedInertialRadiusZ = Math.Sqrt(expectedInertialMomentZ / 25 / 50);

            Assert.Equal(expectedInertialMomentY, actualInertialMomentY);
            Assert.Equal(expectedInertialMomentZ, actualInertialMomentZ);
            Assert.Equal(expectedInertialRadiusY, actualInertialRadiusY);
            Assert.Equal(expectedInertialRadiusZ, actualInertialRadiusZ);
        }

        [Fact]
        public void IsCorrectInertialMomentAndRadiusCalculationOfDoubleT()
        {
            var doubleT = new DoubleT(100, 20, 1, 1);

            var area = doubleT.Area();

            var actualInertialMomentY = doubleT.InertialMomentY();
            double expectedInertialMomentY = (2.0 * (20 * 1 * 1 * 1 / 12.0)) + (2.0 * (20 * 1 * 49.5 * 49.5)) + (1.0 * 98 * 98 * 98 / 12.0);
            var actualInertialRadiusY = doubleT.InertialRadiusY();
            var expectedInertialRadiusY = Math.Sqrt(expectedInertialMomentY / area);

            var actualInertialMomentZ = doubleT.InertialMomentZ();
            var expectedInertialMomentZ = (2.0 * (20.0 * 20 * 20 * 1 / 12.0)) + (1.0 * 1 * 1 * 98 / 12.0);
            var actualInertialRadiusZ = doubleT.InertialRadiusZ();
            var expectedInertialRadiusZ = Math.Sqrt(expectedInertialMomentZ / area);

            Assert.Equal(expectedInertialMomentY, actualInertialMomentY);
            Assert.Equal(expectedInertialMomentZ, actualInertialMomentZ);
            Assert.Equal(expectedInertialRadiusY, actualInertialRadiusY);
            Assert.Equal(expectedInertialRadiusZ, actualInertialRadiusZ);
        }

        [Fact]
        public void IsCorrectResistanceMomentCalculationOfRectangle()
        {
            var rectangle = new Rectangle(50, 25);

            var actualResistanceMomentY = rectangle.ResistanceMomentY();
            double expectedResistanceMomentY = 25.0 * 50 * 50 / 6;

            var actualResistanceMomentZ = rectangle.ResistanceMomentZ();
            var expectedResistanceMomentZ = 50.0 * 25 * 25 / 6;

            Assert.Equal(expectedResistanceMomentY, actualResistanceMomentY);
            Assert.Equal(expectedResistanceMomentZ, actualResistanceMomentZ);
        }

        [Fact]
        public void IsCorrectResistanceMomentCalculationOfDoubleT()
        {
            var doubleT = new DoubleT(50, 25, 1, 1);

            var actualResistanceMomentY = doubleT.ResistanceMomentY();
            double expectedResistanceMomentY = doubleT.InertialMomentY() / (doubleT.Height / 2 );

            var actualResistanceMomentZ = doubleT.ResistanceMomentZ();
            double expectedResistanceMomentZ = doubleT.InertialMomentZ() / (doubleT.Width / 2);

            Assert.Equal(expectedResistanceMomentY, actualResistanceMomentY);
            Assert.Equal(expectedResistanceMomentZ, actualResistanceMomentZ);
        }

        [Fact]
        public async Task AreCorrectSettedParametersOfSection()
        {
            var list = new List<Section>();
            var mockRepo = new Mock<IDeletableEntityRepository<Section>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Section>())).Callback(
                (Section section) => list.Add(section));

            var service = new SectionsService(mockRepo.Object);

            await service.CreateAsync(new Web.ViewModels.Section.CreateSectionInputModel
            {
                SectionName = "B25/50",
                SectionType = (Web.ViewModels.Section.SectionType)SectionType.Rectangle,
                Height = 50,
                Width = 25,
            });
            var actualSectionName = list[0].Name;
            var actualHeight = list[0].Height;
            var actualWidth = list[0].Width;

            var expectedSectionName = "B25/50";
            var expectedHeight = 50;
            var expectedWidth = 25;

            Assert.Single(list);
            Assert.Equal(expectedSectionName, actualSectionName);
            Assert.Equal(expectedHeight, actualHeight);
            Assert.Equal(expectedWidth, actualWidth);
        }

        [Fact]
        public async Task AreCorrectCalculationsForInertialMomentAndRadiusOfRectangle()
        {
            var list = new List<Section>();
            var mockRepo = new Mock<IDeletableEntityRepository<Section>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Section>())).Callback(
                (Section section) => list.Add(section));

            var service = new SectionsService(mockRepo.Object);

            await service.CreateAsync(new Web.ViewModels.Section.CreateSectionInputModel
            {
                SectionName = "B25/50",
                SectionType = (Web.ViewModels.Section.SectionType)SectionType.Rectangle,
                Height = 50,
                Width = 25,
            });
            await service.CreateAsync(new Web.ViewModels.Section.CreateSectionInputModel
            {
                SectionName = "B30/50",
                SectionType = (Web.ViewModels.Section.SectionType)SectionType.Rectangle,
                Height = 50,
                Width = 30,
            });
            var actualInertialMomentY = list[0].InertialMomentY;
            double expectedInertialMomentY = 25.0 * 50 * 50 * 50 / 12;
            var actualInertialRadiusY = list[0].InertialRadiusY;
            var expectedInertialRadiusY = Math.Sqrt(expectedInertialMomentY / 25 / 50);

            var actualInertialMomentZ = list[1].InertialMomentZ;
            var expectedInertialMomentZ = 50.0 * 30 * 30 * 30 / 12;
            var actualInertialRadiusZ = list[1].InertialRadiusZ;
            var expectedInertialRadiusZ = Math.Sqrt(expectedInertialMomentZ / 30 / 50);

            Assert.Equal(2, list.Count);
            Assert.Equal(expectedInertialMomentY, actualInertialMomentY);
            Assert.Equal(expectedInertialMomentZ, actualInertialMomentZ);
            Assert.Equal(expectedInertialRadiusY, actualInertialRadiusY);
            Assert.Equal(expectedInertialRadiusZ, actualInertialRadiusZ);
        }

        [Fact]
        public async Task AreCorrectCalculationsForResistanceMomentOfRectangle()
        {
            var list = new List<Section>();
            var mockRepo = new Mock<IDeletableEntityRepository<Section>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Section>())).Callback(
                (Section section) => list.Add(section));

            var service = new SectionsService(mockRepo.Object);

            await service.CreateAsync(new Web.ViewModels.Section.CreateSectionInputModel
            {
                SectionName = "B25/50",
                SectionType = (Web.ViewModels.Section.SectionType)SectionType.Rectangle,
                Height = 50,
                Width = 25,
            });

            var actualResistanceMomentY = list[0].ResistanceMomentY;
            var actualResistanceMomentZ = list[0].ResistanceMomentZ;

            double expectedResistanceMomentY = 25.0 * 50 * 50 / 6;
            double expectedResistanceMomentZ = 25.0 * 25 * 50 / 6;

            Assert.Equal(expectedResistanceMomentY, actualResistanceMomentY);
            Assert.Equal(expectedResistanceMomentZ, actualResistanceMomentZ);
        }

        [Fact]
        public async Task AreCorrectCalculationsForStaticMomentOfRectangle()
        {
            var list = new List<Section>();
            var mockRepo = new Mock<IDeletableEntityRepository<Section>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Section>())).Callback(
                (Section section) => list.Add(section));

            var service = new SectionsService(mockRepo.Object);

            await service.CreateAsync(new Web.ViewModels.Section.CreateSectionInputModel
            {
                SectionName = "B25/50",
                SectionType = (Web.ViewModels.Section.SectionType)SectionType.Rectangle,
                Height = 50,
                Width = 25,
            });

            var actualStaticMomentY = list[0].StaticMomentY;
            var actuaStaticMomentZ = list[0].StaticMomentZ;

            double expectedStaticMomentY = 25 * 25 * 12.5;
            double expectedStaticMomentZ = 12.5 * 50 * 12.5 / 2;

            Assert.Equal(expectedStaticMomentY, actualStaticMomentY);
            Assert.Equal(expectedStaticMomentZ, actuaStaticMomentZ);
        }

        [Fact]
        public async Task AreCorrectCalculationsForStaticMomentOfDoubleT()
        {
            var list = new List<Section>();
            var mockRepo = new Mock<IDeletableEntityRepository<Section>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Section>())).Callback(
                (Section section) => list.Add(section));

            var service = new SectionsService(mockRepo.Object);

            await service.CreateAsync(new Web.ViewModels.Section.CreateSectionInputModel
            {
                SectionName = "B25/50",
                SectionType = (Web.ViewModels.Section.SectionType)SectionType.IPE,
                Height = 50,
                Width = 25,
                WebThickness = 1,
                FlangeThickness = 1,
            });

            var actualStaticMomentY = list[0].StaticMomentY;
            var actuaStaticMomentZ = list[0].StaticMomentZ;

            double expectedStaticMomentY = (25 * 1 * 24.5) + (24 * 1 * 12);
            double expectedStaticMomentZ = (48 * 0.5 * 0.25) + (2 * 12.5 * 1 * 12.5 / 2);

            Assert.Equal(expectedStaticMomentY, actualStaticMomentY);
            Assert.Equal(expectedStaticMomentZ, actuaStaticMomentZ);
        }
    }
}
