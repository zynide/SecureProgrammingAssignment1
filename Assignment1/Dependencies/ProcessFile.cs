using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProcessFile
    {
        public ProcessFile() { }

        public ProcessFile(string cppPath, string extension)
        {
            System.Diagnostics.Process cmdprocess = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
            startinfo.FileName = Path.Combine(cppPath, Filetypes.batFile);
            startinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startinfo.CreateNoWindow = true;
            startinfo.RedirectStandardInput = true;
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            startinfo.Arguments = String.Format("{0} {1} {2}", cppPath,
                                                Path.Combine(cppPath, String.Format("{0}{1}", Filetypes.inputFile, extension)),
                                                Path.Combine(cppPath, Filetypes.outputFile));

            cmdprocess.StartInfo = startinfo;
            cmdprocess.Start();
        }

    }
}
