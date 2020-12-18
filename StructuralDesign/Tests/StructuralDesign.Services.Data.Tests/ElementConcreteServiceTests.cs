namespace StructuralDesign.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using StructuralDesign.Data;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;
    using Xunit;

    public class ElementConcreteServiceTests
    {/*
        [Fact]
        public void IsCorrectInertialMomentAndRadiusCalculationOfRectangle()
        {
            var elementConcrete = new ElementConcrete
            {
                Name = "C1",
                Length = 1000,
                LeftBoundaryCondition = BoundaryCondition.Pinned,
                RightBoundaryCondition = BoundaryCondition.Pinned,
                ProjectId = "123",
                ConcreteId = 1,
                MaterialRebarId = 1,
                LoadId = 1,
                Load = new Load
                {
                    Type = LoadType.DesigLoad,
                    AxialForce = -200,
                },
                SectionId = 12,
                Section = new Section
                {
                    Type = SectionType.Rectangle,
                    Height = 250,
                    Width = 250,
                },
                ReinforcementBarId = 12,
            };
            elementConcrete.
            elementConcrete.Name = "C1"

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
        public async Task AreCorrectCalculationsForSlendernessCoefficient()
        {
            var list = new List<ElementConcrete>();
            var mockRepo = new Mock<IRepository<ElementConcrete>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ElementConcrete>())).Callback(
                (ElementConcrete elementConcrete) => list.Add(elementConcrete));

            var listSection = new List<Section>();
            var mockRepoSection = new Mock<IDeletableEntityRepository<Section>>();
            mockRepoSection.Setup(x => x.All()).Returns(listSection.AsQueryable());
            mockRepoSection.Setup(x => x.AddAsync(It.IsAny<Section>())).Callback(
                (Section section) => listSection.Add(section));

            var listLoad = new List<Load>();
            var mockRepoLoad = new Mock<IRepository<Load>>();
            mockRepoLoad.Setup(x => x.All()).Returns(listLoad.AsQueryable());
            mockRepoLoad.Setup(x => x.AddAsync(It.IsAny<Load>())).Callback(
                (Load load) => listLoad.Add(load));

            var serviceLoad = new LoadService(mockRepoLoad.Object);
            var serviceSection = new SectionsService(mockRepoSection.Object);
            var service = new ElementConcreteService(mockRepo.Object, serviceLoad, serviceSection);

            var section = await serviceSection.CreateAsync(new Web.ViewModels.Section.CreateSectionInputModel
            {
                SectionName = "C25/50",
                SectionType = (Web.ViewModels.Section.SectionType)SectionType.Rectangle,
                Height = 500,
                Width = 250,
            });

            var load = await serviceLoad.CreateAsync(new Web.ViewModels.Load.CreateLoadInputModel
            {
                Type = (Web.ViewModels.Load.LoadType)LoadType.DesigLoad,
                AxialForce = -1000,
            });

            var elementConcrete = new ElementConcrete
            {
                Name = "C1",
                Length = 1000,
                LeftBoundaryCondition = BoundaryCondition.Pinned,
                RightBoundaryCondition = BoundaryCondition.Pinned,
                ProjectId = "pr1",
                ConcreteId = input.ConcreteId,
                MaterialRebarId = input.MaterialRebarId,
                LoadId = loadId,
                Load = this.loadService.GetSectionById(loadId),
                SectionId = sectionId,
                Section = this.sectionsService.GetSectionById(sectionId),
                ReinforcementBarId = input.ReinforcementBarId,
            }

            var actualStaticMomentY = list[0].StaticMomentY;
            var actuaStaticMomentZ = list[0].StaticMomentZ;

            double expectedStaticMomentY = 25 * 25 * 12.5;
            double expectedStaticMomentZ = 12.5 * 50 * 12.5 / 2;

            Assert.Equal(expectedStaticMomentY, actualStaticMomentY);
            Assert.Equal(expectedStaticMomentZ, actuaStaticMomentZ);
    }


    }

    class MyTestGameAll : IMapFrom<ElementConcrete>
    {
        public string Name { get; set; }
    }
    [Fact]
    public async Task TestGetAll()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var repositoryGame = new IRepository<ElementConcrete>(new ApplicationDbContext(options.Options));
        var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
        var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
        var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
        repositoryGame.AddAsync(new Game { Name = "abc" }).GetAwaiter().GetResult();
        repositoryGame.AddAsync(new Game { Name = "abcd" }).GetAwaiter().GetResult();
        repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
        var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
        AutoMapperConfig.RegisterMappings(typeof(MyTestGameAll).Assembly);
        var game = service.GetAll<MyTestGameAll>();
        Assert.Equal(2, game.Count());
    }*/
    }
}
