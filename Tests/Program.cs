using EfApplication.DataAccess;
using EfApplication.EfCommands;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Program
    {
        static void Main(string[] args)
        {
			TestGetAllProductsFromJson();

		}

        [Fact]
        private static void TestGetAllProductsFromDatabase()
        {
            var context = new WMContext();
            var response = new EfGetProductsCommand(context).Execute();

            response.Should().NotBeEmpty();
        }

		[Fact]
		private static void TestGetAllProductsFromJson()
		{
			var context = new WMContext();
			//var response = new EfGetProductsCommand(context).ReadFromJson();

			//response.Should().NotBeEmpty();
		}
	}
}
