namespace StructuralDesign.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using Xunit;

    public class BoltServiceTests
    {
        [Fact]
        public void AddBolt()
        {
            var list = new List<ElementBolt>();
            var mockRepo = new Mock<IRepository<ElementBolt>>();
            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ElementBolt>()));
            var service = new BoltService(mockRepo.Object);

            var steel = new ElementBolt
            {
                Id = 1,
                Name = "M12",
                NominalDiameter = 12,
            };

            list.Add(steel);
            var actual = service.GetAllAsKeyValuePairs();
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("1", "M12"),
            };
            Assert.Equal(expected, actual);
        }
    }
}
