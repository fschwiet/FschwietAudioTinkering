using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Audio.Formats;
using ManyConsole;

namespace Faudio
{
    public class FrameEnergy : ConsoleCommand
    {
        public string File;

        public FrameEnergy()
        {
            this.IsCommand("frame-energy");
            this.HasAdditionalArguments(1, "Input file");
        }

        public override int? OverrideAfterHandlingArgumentsBeforeRun(string[] remainingArguments)
        {
            var result = base.OverrideAfterHandlingArgumentsBeforeRun(remainingArguments);

            File = remainingArguments.Single();

            if (!System.IO.File.Exists(File))
                throw new ConsoleHelpAsException("Could not find file " + File);

            return result;
        }

        public override int Run(string[] remainingArguments)
        {
            var decoder = new WaveDecoder(File);

            var sampleRate = decoder.SampleRate;

            Console.WriteLine("Sample rate is {0}, duration is {1}",  sampleRate, TimeSpan.FromMilliseconds(decoder.Duration));

            int count = 1;
            while (decoder.Position < decoder.Samples)
            {
                var signl = decoder.Decode(sampleRate * 60);
                Console.WriteLine(count++ + " frame has energy: " + signl.GetEnergy());
            }

            return 0;
        }
    }
}
