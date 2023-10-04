﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.IO;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            
            var repo = new DapperProductRepository(conn);

            var product = repo.GetAllProducts();

            foreach (var prod in product)
            {
                Console.WriteLine($"{prod.CategoryID} {prod.Name} {prod.Price}{prod.StockLevel}{prod.OnSale} {prod.ProductID}");
            }
        }
    }
}
