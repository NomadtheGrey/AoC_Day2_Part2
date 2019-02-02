using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day2_Part2
{
    class Program
    {
        static List<string> BoxIDs = File.ReadAllLines(@"C:\Projects\Advent_of_Code\Day_2\AoC_Day_2\PuzzleInput.txt").ToList();
        static List<Dictionary<int,char>> BoxIDKVP= new List<Dictionary<int,char>>();
        static void Main(string[] args)
        {
            BoxIDs = BoxIDs.Select(x => x.Trim()).ToList();
            FormatLinesIntoDictionary();
            DisplayDictionary();
            IterateDictionaries();
            Console.ReadKey();
        }

        private static void IterateDictionaries()
        {
            int outerInt = 0;
            for(int curCount=0; curCount<BoxIDKVP.Count-1; curCount++)
            {
                outerInt++;
                int innerInt = 0;
                Dictionary<int,char> curLine = BoxIDKVP[curCount];
                for(int compCount=curCount+1; compCount<BoxIDKVP.Count; compCount++)
                {
                    innerInt++;
                    Dictionary<int, char> compLine = BoxIDKVP[compCount];
                    Dictionary<int,char> found = CompareDictionaries(curLine, compLine);
                    if (outerInt % 100 == 0) Console.WriteLine("Main loop: {0}", outerInt);
                    if (innerInt % 100 == 0) Console.WriteLine("Middle loop: {0}", innerInt);
                    if (found!=null)
                    {
                        Console.WriteLine("Found:");
                        foreach(var d in found)
                        {
                            Console.Write(d.Value);
                            
                        }
                        return;
                    }
                }
                Console.WriteLine("Not found.");
            }
        }

        static int compCount = 0;
        private static Dictionary<int,char> CompareDictionaries(Dictionary<int, char> curLine, Dictionary<int, char> compLine)
        {
            compCount++;
            if (compCount % 100 == 0) Console.WriteLine("CompareCount: {0}", compCount);
            Dictionary<int, char> same = curLine.Intersect(compLine).ToDictionary(x=>x.Key, x=>x.Value);
           
            if (same.Count == curLine.Count-1)
            {
                return same;
            }
            return null;
        }

        private static void DisplayDictionary()
        {
            foreach(var l in BoxIDKVP)
            {
                foreach (var d in l)
                    Console.Write("{0}", d.Value);
            }
            Console.WriteLine();
            foreach (var l in BoxIDKVP)
            {
                foreach (var d in l)
                    Console.Write("{0}", d.Key);
            }
        }

        private static void FormatLinesIntoDictionary()
        {
            foreach (string line in BoxIDs)
            {
                Dictionary<int, char> kvps = new Dictionary<int, char>();
                for (int charNO = 0; charNO < line.Count(); charNO++)
                {
                    kvps.Add(charNO, line[charNO]);
                }
                BoxIDKVP.Add(kvps);
            }
        }
    }
}
