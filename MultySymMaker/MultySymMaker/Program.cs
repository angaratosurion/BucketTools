using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultySymMaker
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string[] files=null;
                    const string mklinkappname = "mklink";
                string commandtorun;
                Console.WriteLine("{0} + Version {1} \n Copyright : {2}", Application.ProductName, Application.ProductVersion,
                    Application.CompanyName);
                if(args.Length<3)
                {
                    Console.WriteLine("No  arguments (0)", args.Length);
                    Console.WriteLine("Correct way /d , /j or /h  +linktextfile +linktargetpath \n" +
                        "linktextfile A text file with  the oaths that contaisn the filess or " +
                        "folders you want to make to simlinks ." +
                        " They must be in Unicode \n"+
                        "linktargetpath: the directory they will be created\n");



                }
                else if  (args.Length==3)
                {
                     if ( File.Exists(args[1]) && Directory.Exists(args[2]) && args[0] !=null )
                    {
                        String filecont = File.ReadAllText(args[1]),batchfilecont;
                        StringBuilder buld = new StringBuilder();
                         if (filecont!=String.Empty)
                        {
                            files = filecont.Split('\n');
                        }
                         for (int i=0; i<files.Length;i++)
                        {
                            files[i]=files[i].Replace("\r","");
                        }
                         if (args[0]=="/d".ToLower()|| args[0] == "/j".ToLower()
                            || args[0] == "/h".ToLower())                            
                        {
                            buld.AppendLine("@chcp 65001");
                            foreach (var file in files)
                            {
                                string linkname = "\"" + args[2] + "\\" + file.Substring(file.LastIndexOf("\\") + 1)+ "\"";
                                commandtorun = mklinkappname + " " + args[0] + " " + linkname + " \""+file +"\"";
                               
                                buld.AppendLine(commandtorun);
                            }
                            batchfilecont = buld.ToString();
                            File.WriteAllText(args[1] + ".bat", batchfilecont,Encoding.UTF8);
                            Process.Start(args[1] + ".bat");

                        }
                    }
                    
                }
                Console.WriteLine("Press Enter to Exit..");
                Console.ReadLine();

            }
            catch   (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                     Console.ReadLine();
            }
        }
    }
}
