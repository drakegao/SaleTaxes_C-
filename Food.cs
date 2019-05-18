

namespace Sales_Taxes
{
    public class Food: Item
    {
        public Food(string name, double price, bool isImported) {
            Name = name;
            Price = price;
            ShouldExampt = !IsImported;
            IsImported = isImported;
        }

        public Food() {
            Name = "";
            Price = 0;
            ShouldExampt = true;
            IsImported = false;
        }
    }
}

// 1 Imported box of chocolates at 10.00
// 1 Imported bottle of perfume at 47.50
// INPUT 3
// 1 Imported bottle of perfume at 27.99
// 1 Bottle of perfume at 18.99
// 1 Packet of headache pills at 9.75
// 1 Imported box of chocolates at 11.25
// 1 Imported box of chocolates at 11.25
// OUTPUT 2
// Imported box of chocolates: 10.50
// Imported bottle of perfume: 54.65
// Sales Taxes: 7.65
// Total: 65.15
// OUTPUT 3
// Imported bottle of perfume: 32.19
// Bottle of perfume: 20.89
// Packet of headache pills: 9.75
// Imported box of chocolates: 23.70 (2 @ 11.85)
// Sales Taxes: 7.30
// Total: 86.53
// INPUT 1
// 1