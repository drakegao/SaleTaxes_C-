using System.Runtime.CompilerServices;

namespace Sales_Taxes
{
    public class Book: Item
    {
        public Book(string name, double price, bool isImported) {
            ShouldExampt = !isImported;
            Name = name;
            Price = price;
            IsImported = isImported;
        }
        public Book() {
            ShouldExampt = true;
            Name = "";
            Price = 0;
            IsImported = false;
        }
    }
}