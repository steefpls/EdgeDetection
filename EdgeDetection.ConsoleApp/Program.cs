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

        public Program()
        {
            operatorFactory = new OperatorFactory();
            imageProcessor = new ImageProcessor(operatorFactory);
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run(args);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public void Run(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    System.Console.WriteLine("Usage: EdgeDetection <input-image> <output-image>");
                    return;
                }

                var operatorType = ProcessUserInput();
                var inputPath = args[0];
                var outputPath = args[1];

                System.Console.WriteLine($"Processing image using {operatorType} operator...");
                imageProcessor.SetOperator(operatorType);
                
                var processedImage = imageProcessor.ProcessImage(inputPath);                
                imageProcessor.SaveImage(processedImage, outputPath);
                System.Console.WriteLine("Processing complete!");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        // Reads User input for selection of edge detection operator
        private OperatorType ProcessUserInput()
        {
            while (true)
            {
                System.Console.WriteLine("Select edge detection operator:");
                System.Console.WriteLine("1. Sobel");
                System.Console.WriteLine("2. Prewitt");
                
                var key = System.Console.ReadKey(true);
                System.Console.WriteLine();

                switch (key.KeyChar)
                {
                    case '1': return OperatorType.Sobel;
                    case '2': return OperatorType.Prewitt;
                    default:
                        System.Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }
    }
}
