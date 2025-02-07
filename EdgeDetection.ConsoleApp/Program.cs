using EdgeDetection.CoreLibrary.Enums;
using EdgeDetection.CoreLibrary.Interfaces;
using EdgeDetection.CoreLibrary.Processing;
using System;
using System.Runtime.Versioning;
namespace EdgeDetection.ConsoleApp
{
    [SupportedOSPlatform("windows")]
    class Program
    {
        private readonly IImageProcessor imageProcessor;
        private readonly OperatorFactory operatorFactory;

        public Program()
        {
            operatorFactory = new OperatorFactory();
            imageProcessor = new ImageProcessor(operatorFactory);
        }

        // Application Entry Point
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run(args);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Application Logic and User Interface
        public void Run(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: EdgeDetection <input-image> <output-image>");
                    return;
                }

                var operatorType = ProcessUserInput();
                var inputPath = args[0];
                var outputPath = args[1];
                Console.WriteLine($"Processing image using {operatorType} operator...");
                imageProcessor.SetOperator(operatorType);

                var processedImage = imageProcessor.ProcessImage(inputPath);
                imageProcessor.SaveImage(processedImage, outputPath);
                Console.WriteLine("Processing complete!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Reads User input for selection of edge detection operator
        private OperatorType ProcessUserInput()
        {
            while (true)
            {
                Console.WriteLine("Select edge detection operator:");
                Console.WriteLine("1. Sobel");
                Console.WriteLine("2. Prewitt");
                Console.WriteLine("3. Roberts");

                var key = Console.ReadKey(true);
                Console.WriteLine();

                switch (key.KeyChar)
                {
                    case '1': return OperatorType.Sobel;
                    case '2': return OperatorType.Prewitt;
                    case '3': return OperatorType.Roberts;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }
    }
}
