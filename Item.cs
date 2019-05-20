using System;
namespace Sales_Taxes
{
    public abstract class Item
    {
        public string Name { get;set; }
        public double Price { get; set; }
        public bool IsImported { get;set; }
        public bool ShouldExampt { get; set; }
        public string Type { get; set; }

    }
}