namespace Sales_Taxes
{
    public class Medical: Item
    {
        public Medical(string name, float price, bool isImported) {
            ShouldExampt = !isImported;
            Name = name;
            Price = price;
            IsImported = isImported;

        }
        public Medical() {
            ShouldExampt = true;
            Name = "";
            Price = 0.0;
            IsImported = false;

        }
    }
}