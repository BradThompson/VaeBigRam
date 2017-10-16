using System;
using System.IO;
using System.Collections.Generic;

namespace VAE
{
    public class BigRam
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VAE Evaluation test with BigRam");
            Console.WriteLine();
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Specify a filename for testing from the command line.");
                    Console.WriteLine();
                    Console.WriteLine("Using the default string");
                    BruteForceBigRam("this is a test is a test");
                    Console.WriteLine();
                    BruteForceBigRam("the quick brown fox and the quick blue hare");
                    return;
                }
                BigRamUsingFile(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured during processing. Error: {0}", e.Message);
                return;
            }
        }

        public static SortedDictionary<string, int> BigRamUsingFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("File does not exist");
            }
            return BruteForceBigRam(File.ReadAllText(fileName));
        }

        public static SortedDictionary<string, int> BruteForceBigRam(string input)
        {
            string[] words = input.Split(' ');
            if (words.Length <= 1)
            {
                throw new Exception("Invalid input");
            }

            SortedDictionary<string, int> dl = new SortedDictionary<string, int>();
            for (int i = 0; i < words.Length - 1; i++)
            {
                string thePair = words[i] + " " + words[i + 1];
                if (dl.ContainsKey(thePair))
                {
                    dl[thePair]++;
                    continue;
                }
                dl.Add(thePair, 1);
            }
            foreach (var item in dl)
            {
                Console.WriteLine("{0}, {1}", item.Key, item.Value);
            }
            return dl;
        }
    }
}
