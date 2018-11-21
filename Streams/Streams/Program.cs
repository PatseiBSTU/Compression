using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipName = @"CodeFiles.zip";
            string zipFoulder = @"..\..\obj";
            string fileUnzipFullPath = @"newOOP";
            if (!File.Exists(zipName))
            ZipFile.CreateFromDirectory(zipFoulder, zipName);


            //Открыть  zip и прочитать
            using (ZipArchive archive = ZipFile.OpenRead(zipName))
            {
                //цикл для каждого файла
                foreach (ZipArchiveEntry file in archive.Entries)
                {
                    //вывод ино
                    Console.WriteLine("File Name: {0}", file.Name);
                    Console.WriteLine("File Size: {0} bytes", file.Length);
                    Console.WriteLine("Compression Ratio: {0}", ((double)file.CompressedLength / file.Length).ToString("0.0%"));


                    //создать путь для ивлечения файла
                    Directory.CreateDirectory(fileUnzipFullPath);

                    //Extracts the file to (potentially new) path
                    file.ExtractToFile(@"one",true);
                }

            }
              
        }
    }
}
