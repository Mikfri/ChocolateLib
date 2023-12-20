using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateLib.Models
{
    public class EasterEggRepository
    {
        private List<EasterEgg> _eggList;

        public EasterEggRepository()
        {
            _eggList = new()
            {
                new EasterEgg(8011, "Mørk", 28, 5012),
                new EasterEgg(8012, "Mørk", 32, 3420),
                new EasterEgg(8022, "Lys", 31, 2870),
                new EasterEgg(8023, "Hvid", 41, 1067),
            };

            //// ELLER nedestående. NB: KRÆVER ADD() metoden
            //_eggList.Add(new() { ProductNo = 8011, ChocolateType = "Mørk", Price = 28, InStock = 5012 });
            //_eggList.Add(new() { ProductNo = 8022, ChocolateType = "Lys", Price = 31, InStock = 2870 });
            //// ... osv
        }

        public IEnumerable<EasterEgg> Get()
        {
            IEnumerable<EasterEgg> allEggs = new List<EasterEgg>(_eggList);
            return allEggs;
        }

        public EasterEgg GetByProductNo(int productNo)
        {
            var egg = _eggList.FirstOrDefault(egg => egg.ProductNo == productNo);

            if (egg != null)
            {
                return egg;
            }
            else
            {
                throw new ArgumentNullException("Product number not found");
            }
        }

        public IEnumerable<EasterEgg> GetLowStock(int stockLevel) //IEnumerable fordi der kan returnes flere
        {
            return _eggList.Where(egg => egg.InStock <  stockLevel);
        }

        public EasterEgg Update(EasterEgg updatedEgg)
        {
            EasterEgg eggToUpdate = _eggList.FirstOrDefault(egg => egg.ProductNo == updatedEgg.ProductNo);

            if (eggToUpdate != null)
            {
                eggToUpdate.ChocolateType = updatedEgg.ChocolateType;
                eggToUpdate.Price = updatedEgg.Price;
                eggToUpdate.InStock = updatedEgg.InStock;

                return eggToUpdate;
            }
            else
            {
                throw new ArgumentNullException("Product number not found");
            }
        }

    }
}
