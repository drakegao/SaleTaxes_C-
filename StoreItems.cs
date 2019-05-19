using System;
using System.Collections.Generic;
namespace Sales_Taxes
{
    public class StoreItems
    {
        public static Dictionary<string, List<string>> ExemptItem = new Dictionary<string, List<string>> {
            { "Food", new List<string> { "chocolate bar", "box of chocolates" } },
            { "Medical", new List<string> { "packet of headache pills" } },
            { "Other Items", new List<string> { "bottle of perfume", "music cd" } },
            { "Imported Items", new List<string> { "imported bottle of perfume", "imported box of chocolates" } }
        };
    }
}