using ChocolateLib.Models;

namespace MST_EasterEgg
{
    [TestClass]
    public class RepoMST
    {

        private EasterEggRepository _eggRepo;

        [TestInitialize]
        public void Initialize()
        {
            _eggRepo = new EasterEggRepository();

            //_eggList = new()
            //{
            //    new EasterEgg(8011, "Mørk", 28, 5012),
            //    new EasterEgg(8012, "Mørk", 32, 3420),
            //    new EasterEgg(8022, "Lys", 31, 2870),
            //    new EasterEgg(8023, "Hvid", 41, 1067),
            //};
        }


        [TestMethod()]
        public void GetTEST()
        {
            IEnumerable<EasterEgg> eggs = _eggRepo.Get();
            Assert.AreEqual(4, eggs.Count());
            Assert.AreNotEqual(5, eggs.Count());
        }

        [TestMethod()]
        public void GetByProductNoTEST()
        {
            EasterEgg? eggProdNo8022 = _eggRepo.GetByProductNo(8022);
            Assert.IsNotNull(eggProdNo8022);
            Assert.AreNotEqual("Mørk", eggProdNo8022.ChocolateType);
            Assert.AreEqual("Lys", eggProdNo8022.ChocolateType);
;
            // Test for et produkt nummer, der ikke findes
            Assert.ThrowsException<ArgumentNullException>(() => _eggRepo.GetByProductNo(8000));
        }

        [TestMethod()]
        public void GetLowStockTest()
        {
            int stock = 2000;

            IEnumerable<EasterEgg> eggs = _eggRepo.GetLowStock(stock);
            Assert.AreEqual(1, eggs.Count());
            Assert.AreNotEqual(2, eggs.Count());
        }
    }
}