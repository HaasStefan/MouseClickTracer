using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClickTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\ProgramData\Hermes-Software\MouseClickTracing\";
            string file = "GlobalTracer.log";
            string path = directory + file;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            Hook.GlobalEvents().MouseDown += async (sender, e) =>
            {

                string dt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

                string message = "Mouse clicked at " + dt + " X: " + e.X + " Y: " + e.Y;

                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(message);
                }

                Console.WriteLine(message);
            };

            Application.Run(new ApplicationContext());
        }
    }
}
