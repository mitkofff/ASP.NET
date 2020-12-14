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

            Assert.Equal(1, list.Count);
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
    }
}