using System;

namespace Sales_Taxes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Store store = new Store();

            // int count = store.AddCommand("1 Imported bottle of perfume at 27.99");
            // count = store.AddCommand("1 Bottle of perfume at 18.99");
            // count = store.AddCommand("1 Packet of headache pills at 9.75");
            // count = store.AddCommand("1 Imported box of chocolates at 11.25");
            // count = store.AddCommand("1 Imported box of chocolates at 11.25");

            // Console.WriteLine(count);

            // store.CheckStoreCarItems();

            // store.AddCommandItemsToItemMap();
            // store.PrintReciept();


            Store store = new Store();
            Console.WriteLine("Welcome to store");
            string item1 = "1 Book at 12.49";
            string item2 = "1 Music CD at 14.99";
            string item3 = "1 Chocolate bar at 0.85";
            string item4 = "1 Packet of headache pills at 9.75";
            string item5 = "1 Bottle of perfume at 18.99";
            string item6 = "1 Imported box of chocolates at 11.25";
            string item7 = "1 Imported bottle of perfume at 27.99";
            string custom = "Custom Item";
            string check = "Check items in the cart";
            string exit = "Checkout & Quit";

            string format = String.Format("a: {0}\nb: {1}\nc: {2}\nd: {3}\ne: {4}\nf: {5}\ng: {6}\ncustom: {7}\nview cart: {8}\nexit: {9}\n",
                                            item1, item2, item3, item4, item5, item6, item7, custom, check, exit);
            while(true) {
                Console.WriteLine(format);
                string testString = Console.ReadLine();
                switch(testString) {
                    case "a":
                        store.AddCommand("1 Book at 12.49");
                        Console.WriteLine("Item was added\n");
                        break;
                    case "b":
                        store.AddCommand("1 Music CD at 14.99");
                        Console.WriteLine("Item was added\n");
                        break;
                    case "c":
                        store.AddCommand("1 Chocolate bar at 0.85");
                        Console.WriteLine("Item was added\n");
                        break;
                    case "d":
                        store.AddCommand("1 Packet of headache pills at 9.75");
                        Console.WriteLine("Item was added\n");
                        break;
                    case "e":
                        store.AddCommand("1 Bottle of perfume at 18.99");
                        Console.WriteLine("Item was added\n");
                        break;
                    case "f":
                        store.AddCommand("1 Imported box of chocolates at 11.25");
                        Console.WriteLine("Item was added\n");
                        break;
                    case "g":
                        store.AddCommand("1 Imported bottle of perfume at 27.99");
                        Console.WriteLine("Item was added\n");
                        break;
                    case "custom":
                        Console.WriteLine("item template:\nquantity {Imported?} Product Name at price");
                        string customItem = Console.ReadLine();
                        if(store.ValidateCommand(customItem)) {
                            store.AddCommand(customItem);
                            Console.WriteLine("Item was added\n");
                            break;
                        } else {
                            continue;
                        }
                    case "view cart":
                        store.CheckStoreCarItems();
                        break;
                    case "exit":
                        store.AddCommandItemsToItemMap();
                        store.PrintReciept();
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
