using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;

namespace FrameExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Process Started");

         
            using (var engine = new Engine())
            {
                var mp4 = new MediaFile { Filename = @"inputFile" };

                engine.GetMetadata(mp4);

                // get frame after every 10seconds
                var i = 10;
                while (i < mp4.Metadata.Duration.TotalSeconds)
                {
                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(i) };
                    var outputFile = new MediaFile { Filename = string.Format("{0}\\image-{1}.jpeg", @"outputfile", i) };
                    engine.GetThumbnail(mp4, outputFile, options);
                    i += 10;
                }

            }
        }
    }
}
