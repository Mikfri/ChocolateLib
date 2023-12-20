namespace ChocolateLib.Models
{
    //IKKE FLUEBEN i create project in same folder as soloution!!
    public class EasterEgg
    {
        public int ProductNo { get; set; }
        public string ChocolateType {  get; set; }
        public int Price { get; set; }
        public int InStock { get; set; }

        public EasterEgg(int productNo, string chocolateType, int price, int inStock)
        {
            ProductNo = productNo;
            ChocolateType = chocolateType;
            Price = price;
            InStock = inStock;
        }

        public EasterEgg() { }
    }
}
