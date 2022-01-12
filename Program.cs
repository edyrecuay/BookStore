using BookStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Program
    {
        public static List<Book> BookStorage = new List<Book>();
        public static void Main(string[] args)
        {
            //Adding some sqmpleData
            BookStorage  = new List<Book>(){ new Book() { Title = "Lord Of the Rings", stock = 10 },
                new Book() { Title = "Harry Potter", stock = 10 },
                new Book() { Title = "Hunger Games", stock = 50},
                new Book() { Title = "The Martian", stock = 20 }};


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
