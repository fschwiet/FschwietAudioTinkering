using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faudio
{
    class Program
    {
        static int Main(string[] args)
        {
            var programs = ManyConsole.ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof (Program));

            try
            {
                return ManyConsole.ConsoleCommandDispatcher.DispatchCommand(programs, args, Console.Out);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e);
            }

            return 0;
        }
    }
}
