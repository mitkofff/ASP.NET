namespace StructuralDesign.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using Xunit;

    public class ConcreteServiceTests
    {
        [Fact]
        public void AddBolt()
        {
            var list = new List<MaterialConcrete>();
            var mockRepo = new Mock<IDeletableEntityRepository<MaterialConcrete>>();
            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<MaterialConcrete>()));
            var service = new ConcreteService(mockRepo.Object);

            var steel = new MaterialConcrete
            {
                Id = 1,
                Name = "C12/15",
                DesignCompressiveStrength = 1.2,
            };

            list.Add(steel);
            var actual = service.GetAllAsKeyValuePairs();
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("1", "C12/15"),
            };
            Assert.Equal(expected, actual);
        }
    }
}
