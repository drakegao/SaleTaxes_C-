using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
namespace Sales_Taxes
{
    public class TestClass {
        // testing valid input
        [Theory]
        [InlineData("1 Book at 12")]
        [InlineData("1 Imported Book at 12")]
        [InlineData("1 Music CD at 12")]
        public void TheoryPassingValidCommand(string command) {
            Store store = new Store();
            Assert.True(store.ValidateCommand(command));
        }

        // testing invalid input
        [Theory]
        [InlineData("Book at 12")]
        [InlineData("1 Imported Book 12")]
        [InlineData("1 Imported Book")]
        public void TheoryFailingValidCommand(string command) {
            Store store = new Store();
            Assert.False(store.ValidateCommand(command));
        }

        [Fact]
        public void PassingAddCommand() {
            Store store = new Store();
            int size = store.AddCommand("1 Book at 12");
            Assert.Equal(1, size);

            int size2 = store.AddCommand("2 Perfume at 24");
            Assert.Equal(3, size2);
        }

        [Fact]
        public void PassingTotalPrice() {
            Store store = new Store();
            int count = store.AddCommand("1 Book at 12.49");
            count = store.AddCommand("1 Book at 12.49");
            count = store.AddCommand("1 Music CD at 14.99");
            count = store.AddCommand("1 Chocolate bar at 0.85");
            Assert.Equal(4, count);

            store.AddCommandItemsToItemMap();
            store.PrintReciept();
            
            double total = store.Total;
            Assert.Equal(42.32, total);
        }
    }
}