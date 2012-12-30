using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.DirectSound;
using ManyConsole;

namespace Faudio
{
    public class ListDevicesCommand : ConsoleCommand
    {
        public ListDevicesCommand()
        {
            this.IsCommand("list-devices");
        }

        public override int Run(string[] remainingArguments)
        {
            Console.WriteLine("Inputs:");

            foreach (var device in new AudioDeviceCollection(AudioDeviceCategory.Capture))
            {
                Console.WriteLine("    {0} - {1}", device.Guid, device.Description);
            }

            Console.WriteLine("Outputs:");
            foreach (var device in new AudioDeviceCollection(AudioDeviceCategory.Output))
            {
                Console.WriteLine("    {0} - {1}", device.Guid, device.Description);
            }

            return 0;
        }
    }
}
