using Microsoft.AspNetCore.Mvc;
using Moq;
using VirtualWaiter.Service.Controllers;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Test
{
    [TestFixture]
    internal class EateryTableTest
    {
        private Mock<IEaterytable> _mockEateryTableService;
        private EaterytableController _controller;
        [SetUp]
        public void Setup()
        {
            _mockEateryTableService = new Mock<IEaterytable>();
            _controller = new EaterytableController(_mockEateryTableService.Object);
        }
        [Test]
        public async Task Get_ReturnsListOfEaterytable()
        {
            var eateryTables = new List<Eaterytable>
            {
                new Eaterytable { Id = 1, Number = 1, Capacity = 4 },
                new Eaterytable { Id = 2, Number = 2, Capacity = 10 },
                new Eaterytable { Id = 3, Number = 2, Capacity = 15 },
                new Eaterytable { Id = 4, Number = 2, Capacity = 20 }
            };

            _mockEateryTableService.Setup(x => x.GetActive()).ReturnsAsync(eateryTables);

            var result = await _controller.Get();// as IEnumerable<Eaterytable>;

            Assert.IsNotNull(result);
            Assert.AreEqual(eateryTables.Count, result?.Count());

        }

        [Test]
        public async Task Save_CreatesEaterytable_ReturnsTrue()
        {
            var newEaterytable = new Eaterytable { Id = 5, Number = 3, Capacity = 6 };
            _mockEateryTableService.Setup(x => x.Save(It.IsAny<Eaterytable>())).ReturnsAsync(true);

            var result = await _controller.Save(newEaterytable);

            Assert.IsTrue(result);
            _mockEateryTableService.Verify(x => x.Save(It.IsAny<Eaterytable>()), Times.Once);
        }

        [Test]
        public async Task Update_UpdatesEaterytable_ReturnsTrue()
        {
            var updatedEaterytable = new Eaterytable { Id = 1, Number = 1, Capacity = 5 };
            _mockEateryTableService.Setup(x => x.Update(It.IsAny<Eaterytable>())).ReturnsAsync(true);

            var result = await _controller.Update(updatedEaterytable);

            Assert.IsTrue(result);
            _mockEateryTableService.Verify(x => x.Update(It.IsAny<Eaterytable>()), Times.Once);
        }

        [Test]
        public async Task Delete_InactivatesEaterytable_ReturnsTrue()
        {
            var idToDelete = 1;
            _mockEateryTableService.Setup(x => x.Delete(idToDelete)).ReturnsAsync(true);

            var result = await _controller.Delete(idToDelete);

            Assert.IsTrue(result);
            _mockEateryTableService.Verify(x => x.Delete(idToDelete), Times.Once);
        }
    }
}
    

