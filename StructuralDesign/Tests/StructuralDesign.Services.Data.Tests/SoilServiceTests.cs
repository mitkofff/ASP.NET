namespace StructuralDesign.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using Xunit;

    public class SoilServiceTests
    {
        [Fact]
        public void AddSoil()
        {
            var list = new List<MaterialSoil>();
            var mockRepo = new Mock<IDeletableEntityRepository<MaterialSoil>>();
            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<MaterialSoil>()));
            var service = new SoilService(mockRepo.Object);

            var soil = new MaterialSoil
            {
                Id = 1,
                Name = "Gravel",
                DesignPressure = 300,
                VolumeWeight = 20,
            };

            list.Add(soil);
            var actual = service.GetAllAsKeyValuePairs();
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("1", "Gravel - 300kPa"),
            };
            Assert.Equal(expected, actual);
        }
    }
}
