using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public partial class ProcessImage
    {
        public ProcessImage(){}

        public ProcessImage(string inputFile) {
            System.Diagnostics.Process cmdprocess = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
            startinfo.FileName = GetBatchPath();
            startinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startinfo.CreateNoWindow = true;
            startinfo.RedirectStandardInput = true;
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            ////paths of where the source and output files go
            startinfo.Arguments = String.Format("{0} {1}", inputFile, "C:\\Users\\Jesus\\Desktop\\test1.txt");
            cmdprocess.StartInfo = startinfo;
            cmdprocess.Start();
        }
        private string GetBatchPath()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(System.IO.Directory.GetParent(path).ToString());
            UriBuilder uri2 = new UriBuilder(directoryInfo.ToString());
            return System.IO.Path.GetDirectoryName(Uri.UnescapeDataString(uri2.Path + "/CPP/CppCheck.bat/"));
        }
    }
}
