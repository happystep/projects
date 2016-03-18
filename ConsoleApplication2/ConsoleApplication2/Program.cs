using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("enter file name");
            string answer = Console.ReadLine();

            char delim = ',';

            StreamReader sr = new StreamReader(answer);
            Console.WriteLine("enter destination file name");
            string fileoutput = Console.ReadLine();
            StreamWriter sw = new StreamWriter(fileoutput);

            string[] words = new string[10000000];

            string line;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Console.WriteLine(line);
                words = line.Split(delim);



                foreach (string s in words)
                {

                    if (!s.Contains('2'))
                    {
                        sw.WriteLine(s);
                    }
                    else if (!s.Contains('@'))
                    {
                        sw.WriteLine(s);
                    }

                }
            }


                sr.Close();



                sw.Close();


                Console.ReadLine(); // so the program doesn't stop on its own


          
        }
    }
}
