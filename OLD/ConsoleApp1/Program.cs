using SapSqlLib.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SapSqlDbContext sqlDbContex = new SapSqlDbContext();
            sqlDbContex.OCRD.Where(c => c.CardName != null).ToList().ForEach(c => Console.WriteLine(c.CardCode));
        }
    }
}
