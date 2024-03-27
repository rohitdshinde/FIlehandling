
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Assignmemt05
{
    class Program
    {
        static void WriteFile(string path, string content)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                // ( Writing to file )

                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(content);
                    Console.WriteLine("Written SuccessFully !");
                }
            }
        }

        static void ReadFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                // ( Reading from file )

                using (StreamReader reader = new StreamReader(fs))
                {
                    string filedata = reader.ReadLine();
                    Console.WriteLine("Readed successfully !");
                    Console.WriteLine(filedata);
                }
            }
        }

        static void AppendFile(string path, string content)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                // ( Appending to file )

                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("Hello I did these with C# FileHandling, and i appended the text");
                    Console.WriteLine("Appended SuccessFully !");
                }
            }
        }
        static void WriteBinaryFile(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(1.250F);
                    writer.Write(@"Z:\Temp");
                    writer.Write(10);
                    writer.Write(true);
                    Console.WriteLine("Written Succesfully in Binary File !");
                }
            }
        }
        static void ReadBinaryFile(string filePath)
        {
            float aspectRatio;
            string tempDirectory;
            int autoSaveTime;
            bool showStatusBar;
            // Read binary data from the file
            using (var stream = File.Open(filePath, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    Console.WriteLine("Readed Succesfully in Binary File !");
                    aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();
                }
            }

            Console.WriteLine("Aspect ratio set to: " + aspectRatio);
            Console.WriteLine("Temp directory is: " + tempDirectory);
            Console.WriteLine("Auto save time set to: " + autoSaveTime);
            Console.WriteLine("Show status bar: " + showStatusBar);
        }

        static void DirectoryAndFileInfo(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            Console.WriteLine("Directory Information:");
            Console.WriteLine($"Name: {directoryInfo.Name}");
            Console.WriteLine($"Full Name: {directoryInfo.FullName}");
            Console.WriteLine($"Parent Directory: {directoryInfo.Parent}");
            Console.WriteLine($"Creation Time: {directoryInfo.CreationTime}");
            Console.WriteLine($"Last Access Time: {directoryInfo.LastAccessTime}");
            Console.WriteLine($"Last Write Time: {directoryInfo.LastWriteTime}");
            Console.WriteLine();

            Console.WriteLine("Files in the Directory:");
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine($"Name: {file.Name}");
                Console.WriteLine($"Full Name: {file.FullName}");
                Console.WriteLine($"Extension: {file.Extension}");
                Console.WriteLine($"Size (in bytes): {file.Length}");
                Console.WriteLine($"Creation Time: {file.CreationTime}");
                Console.WriteLine($"Last Access Time: {file.LastAccessTime}");
                Console.WriteLine($"Last Write Time: {file.LastWriteTime}");
                Console.WriteLine();
            }


        }

        static void Main(string[] args)
        {
            string path = @"Z:\Textfiles\new.txt";
            string pathForBinary = @"Z:\Textfiles\new.bin";
            string pathForDirectory = @"Z:\Textfiles";
            try
            {
                // Question - 01

                // ( Writing to file )
                Program.WriteFile(path, "Hello I have written this file with the help of C#");
                Console.WriteLine("--------------------------------");

                // ( Reading from file )
                Program.ReadFile(path);
                Console.WriteLine("--------------------------------");

                // ( Appending to file )
                Program.AppendFile(path, "I Appended it using C#");
                Console.WriteLine("--------------------------------");

                // Question - 02

                // ( Writing To Binary File )
                Program.WriteBinaryFile(pathForBinary);
                Console.WriteLine("--------------------------------");

                // ( Reading from Binary File)
                Program.ReadBinaryFile(pathForBinary);
                Console.WriteLine("--------------------------------");

                // Question - 03 
                Program.DirectoryAndFileInfo(pathForDirectory);
                Console.WriteLine("--------------------------------");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }


        }
    }
}
                                               