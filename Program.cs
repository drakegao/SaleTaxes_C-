using System;

namespace Sales_Taxes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Store store = new Store();

            int count = store.AddCommand("1 Book at 12.49");
            count = store.AddCommand("1 Book at 12.49");
            count = store.AddCommand("1 Music CD at 14.99");
            count = store.AddCommand("1 Imported bottle of perfume at 47.50");
            Console.WriteLine(count);

            store.CheckStoreCarItems();

            store.AddCommandItemsToItemMap();
            store.PrintReciept();
        }
    }
}
