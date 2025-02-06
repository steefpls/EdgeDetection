using EdgeDetection.Core.Enums;
using EdgeDetection.Core.Interfaces;
using EdgeDetection.Core.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EdgeDetection.ConsoleApp
{
    class Program
    {
        private readonly IImageProcessor imageProcessor;
        private readonly OperatorFactory operatorFactory;

        static void Main(string[] args)
        {
            // Main application logic
            Console.WriteLine("Edge Detection Application");
            Console.ReadLine();
        }
        
    }
}
