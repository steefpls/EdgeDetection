---

# **Edge Detection Project**  

## **Overview**  
This project is a C# implementation of edge detection using the **Sobel, Prewitt, and Roberts operators**.  

## **Requirements**  
Before you begin, ensure you have the following installed on your system:  
- **.NET 8.0** (or higher)  
  - [Download .NET Framework 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- **Windows OS** (Required for .NET Framework-based builds)  

## **Installation & Setup**  

1. **Clone the repository:**  
   ```sh
   git clone https://github.com/steefpls/EdgeDetection.git
   cd EdgeDetection
   ```

2. **Build the application:**  
   ```sh
   dotnet build
   ```

3. **Prepare your images:**  
   - Place the image file you want to process inside this folder (`EdgeDetection.ConsoleApp\bin\Debug\net8.0`).  

4. **Run the application with arguments:**  
   ```sh
   EdgeDetection.ConsoleApp.exe <input_image> <output_image>
   ```  
   Example:  
   ```sh
   EdgeDetection.ConsoleApp.exe input.jpg output.png
   ```  

5. **View the processed image:**  
   - The output image will be saved in the same folder.  

## **UML Diagram**  
[![UML Diagram](docs/UML_Diagram.png)](docs/UML_Diagram.png)  

---

