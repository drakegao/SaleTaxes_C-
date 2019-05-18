using System;
using System.Linq;
using System.Collections.Generic;
namespace Sales_Taxes
{
    public class Store
    {
        public Store() {
            this.Items = new List<Item>();
        }

        public void AddCommand(string command) {
            string[] commandInfo = command.Split(" ").ToArray();
            Item item = null;

            var quatity = Convert.ToChar(commandInfo[0]);
            string priceString = commandInfo[commandInfo.Length - 1];
            double price = 0;
            bool isImported = (commandInfo[1].ToLower() == "imported") ? true : false;
            string name = "";
            if(isImported) {
                for(int i = 2; i < commandInfo.Length - 3; i++) {
                    name += commandInfo[i] + " ";
                }
                name.TrimEnd(' ');
            } else {
                for(int i = 1; i < commandInfo.Length - 3; i++) {
                    name += commandInfo[i] + " ";
                }
                name.TrimEnd(' ');
            }

            // if input is invalid, just add unknown item;
            // invalid price input 
            try {
                price = Convert.ToDouble(priceString);
            } catch(Exception e) {
                item = new UnknownItem();
            }

            // invalid input
            if(!char.IsDigit(quatity)) {
                item = new UnknownItem();

            } else {
                if(name.ToLower() == "book") {
                    item = new Book {
                        Name = name,
                        Price = Convert.ToDouble(price),
                        IsImported = isImported,
                        ShouldExampt = !isImported
                    };
                } else if(StoreItems.ExemptItem["Food"].Contains(name)) {
                    // is a food
                    item = new Food {
                        Name = name,
                        Price = Convert.ToDouble(price),
                        IsImported = isImported,
                        ShouldExampt = !isImported
                    };
                } else if(StoreItems.ExemptItem["Medical"].Contains(name)) {
                    // find medical items
                    item = new Medical {
                        Name = name,
                        Price = Convert.ToDouble(price),
                        IsImported = isImported,
                        ShouldExampt = !isImported
                    };
                } else {
                    // regular items
                    item = new OtherItem {
                        Name = name,
                        Price = Convert.ToDouble(price),
                        IsImported = isImported,
                        ShouldExampt = false
                    };
                }
            }

            this.Items.Add(item); 
        }

        public void PrintReciept() {
            foreach (var item in this.Items) {
                switch(item.GetType()) {
                    case typeof(Book):
                        if(item.IsImported) {
                            
                        }
                        break;
                    case typeof(Food):
                        break;
                    case typeof(Medical):
                        break;
                    case typeof(OtherItem):
                        break;
                    default:
                        // unknown item
                        break;
                }

                if(item.GetType() == typeof(Book))
            }
            
        }

        private List<Item> Items;


    }


    public static class StoreCommand {
        
    }
}