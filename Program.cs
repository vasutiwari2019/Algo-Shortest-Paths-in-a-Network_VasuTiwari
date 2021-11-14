using System;
using System.IO;

namespace Algo_Shortest_Paths_in_a_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Shortest Path Project,please run the command as in the read me file.");

            try
            {
                var str = Console.ReadLine();

                string[] initializeFile = str.Split(" ");

                if (initializeFile[0] == "graph" && initializeFile[1]!=".txt")
                {

                    var existingFile = Directory.GetFiles("../../../", "*.txt", SearchOption.TopDirectoryOnly);

                    var fileName = initializeFile[1].Split(".");

                    System.IO.File.Move(existingFile[0], "../../../"+fileName[0]+".txt");
                }

                else
                {
                    throw new NotImplementedException();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Input not in correct order");
            }
        }
    }
}
