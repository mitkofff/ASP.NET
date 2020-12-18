namespace StructuralDesign.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using Xunit;

    public class SteelServiceTests
    {
        [Fact]
        public void AddSteel()
        {
            var list = new List<MaterialSteel>();
            var mockRepo = new Mock<IDeletableEntityRepository<MaterialSteel>>();
            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<MaterialSteel>()));
            var service = new SteelService(mockRepo.Object);

            var steel = new MaterialSteel
            {
                Id = 1,
                Name = "S235",
                YieldStrength = 23.5,
                UltimateTensile = 30,
                VolumeWeight = 78.5,
            };

            list.Add(steel);
            var actual = service.GetAllAsKeyValuePairs();
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("1", "S235"),
            };
            Assert.Equal(expected, actual);
        }
    }
}
