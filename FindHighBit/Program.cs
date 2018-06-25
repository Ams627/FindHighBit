using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHighBit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new Exception("You must have one argument.");
                }
                var filename = args[0];
                var linenumber = 1;
                foreach (var line in File.ReadAllLines(filename))
                {
                    var pos = 1;
                    foreach (var c in line)
                    {
                        if (c > 0x80)
                        {
                            Console.WriteLine($"line is {linenumber}, pos is {pos}");
                        }
                        pos++;
                    }
                    linenumber++;
                }
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
