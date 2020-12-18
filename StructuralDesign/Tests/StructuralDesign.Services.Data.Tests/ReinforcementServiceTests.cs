namespace StructuralDesign.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using Xunit;

    public class ReinforcementServiceTests
    {
        [Fact]
        public void AddSteel()
        {
            var list = new List<MaterialRebar>();
            var mockRepo = new Mock<IDeletableEntityRepository<MaterialRebar>>();
            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<MaterialRebar>()));
            var service = new ReinforcementService(mockRepo.Object);

            var rebar = new MaterialRebar
            {
                Id = 1,
                Name = "B500B",
            };

            list.Add(rebar);
            var actual = service.GetAllElementsAsKeyValue();
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("1", "B500B"),
            };
            Assert.Equal(expected, actual);
        }
    }
}
