using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            DetailsPrinter detailsPrinter = new DetailsPrinter(new List<IEmployee>() { new Employee("Ivan"), new Employee("Dragan"), new Manager("Petkan", new List<string>() { "doc1", "doc2", "doc3" }) });

            detailsPrinter.PrintDetails();
        }
    }
}
