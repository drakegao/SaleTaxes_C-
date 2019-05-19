using System;
using System.Linq;
using System.Collections.Generic;
namespace Sales_Taxes
{
    public class Store
    {
        public Store() {
            this.ItemsMap = new Dictionary<string, List<Item>>();
            this.CommandListItem = new List<Item>();
        }

        public int AddCommand(string command) {

            // valid command
            if(ValidateCommand(command)) {
                string[] commandInfo = command.Split(" ").ToArray();
                var quatity = Convert.ToInt32(commandInfo[0]);
                string priceString = commandInfo[commandInfo.Length - 1];
                bool isImported = (commandInfo[1].ToLower() == "imported") ? true : false;
                string name = "";

                // check item is imported or not,   1 Book at 12
                if(isImported) {
                    for(int i = 2; i < commandInfo.Length - 2; i++) {
                        name += commandInfo[i] + " ";
                    }
                    name = name.TrimEnd(' ');
                } else {
                    for(int i = 1; i < commandInfo.Length - 2; i++) {
                        name += commandInfo[i] + " ";
                    }
                    name = name.TrimEnd(' ');
                }

                // invalid input
                name = name.ToLower();

                for(int i = 0; i < quatity; i++) {
                    // check different type item
                    double price = Convert.ToDouble(priceString);
                    double importTax = 0;
                    if(isImported) {
                        double tax = price * 0.05;
                        //double tax = Math.Round(price * 0.05, 2); //Math.Ceiling((price * 0.05) * 20) / 20;
                        importTax += tax;
                    }

                    if(name == "book") {
                        var tempPrice = price + importTax;
                        var item = new Book {
                            Name = name,
                            Price = (Math.Ceiling(tempPrice) - tempPrice == 0.50) ? tempPrice : Math.Round(tempPrice, 2),
                            IsImported = isImported,
                            ShouldExampt = !isImported,
                            Type = "book"
                        };
                        CommandListItem.Add(item);

                    } else if(StoreItems.ExemptItem["Food"].Contains(name)) {
                        // is a food
                        var tempPrice = price + importTax;
                        var item = new Food {
                            Name = name,
                            Price = (Math.Ceiling(tempPrice) - tempPrice == 0.50) ? tempPrice : Math.Round(tempPrice, 2),
                            IsImported = isImported,
                            ShouldExampt = !isImported,
                            Type = "food"
                        };
                        CommandListItem.Add(item);

                    } else if(StoreItems.ExemptItem["Medical"].Contains(name)) {
                        // find medical items
                        var tempPrice = price + importTax;
                        var item = new Medical {
                            Name = name,
                            Price = (Math.Ceiling(tempPrice) - tempPrice == 0.50) ? tempPrice : Math.Round(tempPrice, 2),
                            IsImported = isImported,
                            ShouldExampt = !isImported,
                            Type = "medical"
                        };
                        CommandListItem.Add(item);

                    } else {
                        // regular items
                        //if(!isImported) {
                        // 10% tax for regular item
                        double saleTax = price * 0.1;

                        double taxSum = saleTax + importTax;
                        // Math.Ceiling((price * 0.1) * 20) / 20;
                        double tempPrice = price + taxSum;
                        //}
                        var item = new OtherItem {
                            Name = name,
                            Price = (Math.Ceiling(tempPrice) - tempPrice == 0.50) ? tempPrice : Math.Round(tempPrice, 2),
                            IsImported = isImported,
                            ShouldExampt = false,
                            Type = "general"
                        };
                        CommandListItem.Add(item);

                    }
                }
                return CommandListItem.Count;
            } else {
                return -1;
            }
        }

        public bool ValidateCommand(string command) {
            bool validInput = true;
            command.TrimEnd(' ');
            string[] commandInfo = command.Split(" ").ToArray();
            int quatity = 0;
            string priceString = commandInfo[commandInfo.Length - 1];
            double price = 0;

            if(commandInfo.Length < 4) {
                Console.WriteLine("Error on adding command, please check the input format\nNo item is added");
                validInput = false;
            }

            // first input string in command must be number string for quantity
            try {
                quatity = Convert.ToInt32(commandInfo[0]);
            } catch(Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Error on adding command, please check the input format\nNo item is added");
                validInput = false;
            }

            // last input string must be number string, for price
            // invalid price input 
            try {
                price = Convert.ToDouble(priceString);
            } catch(Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Error on adding command, please check the input format\nNo item is added");
                validInput = false;
            }

            if(commandInfo[commandInfo.Length - 2].ToLower() != "at") {
                Console.WriteLine("Error on adding command, please check the input format\nNo item is added");
                validInput = false;
            }

            return validInput;
        }

        // print for receipt
        public string PrintReciept() {
           string finalMessege = "";
           Console.WriteLine();
           Console.WriteLine("----Reciept------");
           foreach(KeyValuePair<string, List<Item>> entry in ItemsMap)
            {
                finalMessege += AddFormatStringForPrint(entry) + '\n';
            }
            Console.WriteLine(finalMessege);
            return finalMessege;
        }

        //Adding all commands to itemMap for print receipt use
        public int AddCommandItemsToItemMap() {
            foreach(var item in this.CommandListItem) {
                this.AddToItemMap(item);
            }

            return this.ItemsMap.Count;
        }

        public void CheckStoreCarItems() {
            Console.WriteLine("You have: ");
            foreach(var item in this.CommandListItem) {
                Console.WriteLine(item.Name + " @ " + item.Price);
            }
        }

        private void AddToItemMap(Item item) {
            if(item.GetType() == typeof(Book)) {
                if(ItemsMap.ContainsKey("Book")) {
                    ItemsMap["Book"].Add(item);
                } else {
                    ItemsMap.Add("Book", new List<Item>() { item });
                }
            } else if(item.GetType() == typeof(Food)) {
                if(ItemsMap.ContainsKey("Food")) {
                    ItemsMap["Food"].Add(item);
                } else {
                    ItemsMap.Add("Food", new List<Item>() { item });
                }
            } else if(item.GetType() == typeof(Medical)) {
                if(ItemsMap.ContainsKey("Medical")) {
                    ItemsMap["Medical"].Add(item);
                } else {
                    ItemsMap.Add("Medical", new List<Item>() { item });
                }
            } else if(item.GetType() == typeof(OtherItem)) {
                if(ItemsMap.ContainsKey(item.Name)) {
                    ItemsMap[item.Name].Add(item);
                } else {
                    ItemsMap.Add(item.Name, new List<Item>() { item });
                }
            }
        }

        // parising each item in the itemMap, format the each receipt message
        private string AddFormatStringForPrint(KeyValuePair<string, List<Item>> entry)
        {
            Item singleItem = entry.Value[0];
            int itemCount = entry.Value.Count;
            double finalPrice = 0;

            foreach (Item item in entry.Value)
            {
                finalPrice += item.Price;
            }

            string itemName = (singleItem.IsImported) ? "Imported " + singleItem.Name : singleItem.Name;
            string endingMessege = (itemCount > 1) ? "(" + itemCount.ToString() + " @ " + singleItem.Price.ToString() + " )" : "";

            string formatMsg = "{0}: {1}{2}";

            string stringFormat = String.Format(formatMsg, itemName, finalPrice.ToString(), endingMessege);
            return stringFormat;
        }


        public  List<Item> CommandListItem { get; set; } 
        public  Dictionary<string, List<Item>> ItemsMap { get; set; }
        public double SaleTax { get; set; }

    }
}