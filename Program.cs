using System;

namespace Sales_Taxes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Store store = new Store();

            int count = store.AddCommand("1 Imported bottle of perfume at 27.99");
            count = store.AddCommand("1 Bottle of perfume at 18.99");
            count = store.AddCommand("1 Packet of headache pills at 9.75");
            count = store.AddCommand("1 Imported box of chocolates at 11.25");
            count = store.AddCommand("1 Imported box of chocolates at 11.25");

            Console.WriteLine(count);

            store.CheckStoreCarItems();

            store.AddCommandItemsToItemMap();
            store.PrintReciept();
        }
    }
}
