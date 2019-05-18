

namespace Sales_Taxes
{
    public class OtherItem: Item
    {
         public OtherItem(string name, double price, bool isImported) {
            ShouldExampt = false;
            Name = name;
            Price = price;
            IsImported = isImported;
        }
        public OtherItem() {
            ShouldExampt = false;
            Name = "";
            Price = 0;
            IsImported = true;
        }
    }
}