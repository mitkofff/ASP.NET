namespace StructuralDesign.Services.Data.Tests
{

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using Xunit;

    public class LoadsServiceTests
    {
        [Fact]
        public async Task IsCreateAsyncAddExactCountOfObjects()
        {
            var list = new List<Load>();
            var mockRepo = new Mock<IRepository<Load>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Load>())).Callback(
                (Load load) => list.Add(load));

            var service = new LoadService(mockRepo.Object);

            int id = await service.CreateAsync(new Web.ViewModels.Load.CreateLoadInputModel
            {
                AxialForce = 4,
                ShearForceY = 5,
                ShearForceZ = 6,
                BendingMomentY = 7,
                BendingMomentZ = 8,
                Type = Web.ViewModels.Load.LoadType.DesigLoad,
            });
            int id2 = await service.CreateAsync(new Web.ViewModels.Load.CreateLoadInputModel
            {
                AxialForce = 41,
                ShearForceY = 51,
                ShearForceZ = 61,
                BendingMomentY = 71,
                BendingMomentZ = 81,
                Type = Web.ViewModels.Load.LoadType.DesigLoad,
            });

            var expectedCount = 2;

            Assert.Equal(expectedCount, list.Count);
        }

        [Fact]
        public async Task AreLoadsCreatedCorrectly()
        {
            var list = new List<Load>();
            var mockRepo = new Mock<IRepository<Load>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Load>())).Callback(
                (Load load) => list.Add(load));

            var service = new LoadService(mockRepo.Object);

            int id = await service.CreateAsync(new Web.ViewModels.Load.CreateLoadInputModel
            {
                AxialForce = 4,
                ShearForceY = 5,
                ShearForceZ = 6,
                BendingMomentY = 7,
                BendingMomentZ = 8,
                Type = Web.ViewModels.Load.LoadType.DesigLoad,
            });
            var expectedLoad = new Web.ViewModels.Load.CreateLoadInputModel
            {
                AxialForce = 4,
                ShearForceY = 5,
                ShearForceZ = 6,
                BendingMomentY = 7,
                BendingMomentZ = 8,
                Type = Web.ViewModels.Load.LoadType.DesigLoad,
            };
            var actualLoad = list[0];

            Assert.Equal(expectedLoad.AxialForce, actualLoad.AxialForce);
            Assert.Equal(expectedLoad.ShearForceY, actualLoad.ShearForceY);
            Assert.Equal(expectedLoad.ShearForceZ, actualLoad.ShearForceZ);
            Assert.Equal(expectedLoad.BendingMomentY, actualLoad.BendingMomentY);
            Assert.Equal(expectedLoad.BendingMomentZ, actualLoad.BendingMomentZ);
        }

        [Fact]
        public async Task AreLoadsEditedCorrectly()
        {
            var list = new List<Load>();
            var mockRepo = new Mock<IRepository<Load>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Load>())).Callback(
                (Load load) => list.Add(load));

            var service = new LoadService(mockRepo.Object);

            int id = await service.CreateAsync(new Web.ViewModels.Load.CreateLoadInputModel
            {
                AxialForce = 4,
                ShearForceY = 5,
                ShearForceZ = 6,
                BendingMomentY = 7,
                BendingMomentZ = 8,
                Type = Web.ViewModels.Load.LoadType.DesigLoad,
            });

            await service.EditAsync(id, new Web.ViewModels.Load.CreateLoadInputModel
            {
                AxialForce = 41,
                ShearForceY = 51,
                ShearForceZ = 61,
                BendingMomentY = 71,
                BendingMomentZ = 81,
                Type = Web.ViewModels.Load.LoadType.DesigLoad,
            });

            var expectedLoad = new Web.ViewModels.Load.CreateLoadInputModel
            {
                AxialForce = 41,
                ShearForceY = 51,
                ShearForceZ = 61,
                BendingMomentY = 71,
                BendingMomentZ = 81,
                Type = Web.ViewModels.Load.LoadType.DesigLoad,
            };
            var actualLoad = list[0];

            Assert.Equal(expectedLoad.AxialForce, actualLoad.AxialForce);
            Assert.Equal(expectedLoad.ShearForceY, actualLoad.ShearForceY);
            Assert.Equal(expectedLoad.ShearForceZ, actualLoad.ShearForceZ);
            Assert.Equal(expectedLoad.BendingMomentY, actualLoad.BendingMomentY);
            Assert.Equal(expectedLoad.BendingMomentZ, actualLoad.BendingMomentZ);
        }
    }
}
