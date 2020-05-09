using NUnit.Framework;
using OCranes.Models;
using OCranes.Services;

namespace OCranes.Tests
{
    [TestFixture()]
    public class Test
    {
        private CranesDataStore store;

        [OneTimeSetUp] public void InitTests()
        {
            this.store = new CranesDataStore();
        }

        [Test] public void TestGetCranes()
        {
            var cranes = this.store.GetItemsAsync(true);
            Assert.NotNull(cranes);
        }

        [Test] public async void TestAddCranes()
        {
            var crane = new Crane("Nuova crane", 10);
            Assert.IsNotNull(crane);

            var result = await this.store.AddItemAsync(crane);
            Assert.IsTrue(result);
        }
    }
}
