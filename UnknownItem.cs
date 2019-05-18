namespace Sales_Taxes
{
    public class UnknownItem: Item
    {
        public UnknownItem() {
            Name = "UnkownItem";
            Price = 0;
            ShouldExampt = true;
            IsImported = false;
        }
    }
}