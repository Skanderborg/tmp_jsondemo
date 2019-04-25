using Lib_kalenda.Service;
using System;

namespace App_console
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonService js = new JsonService("");
            js.SaveJsonToDisk();
            Console.WriteLine("succes");
            Console.ReadKey();
        }
    }
}
