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
                                //Process.Start(commandtorun);
                                buld.AppendLine(commandtorun);
                            }
                            batchfilecont = buld.ToString();
                            File.WriteAllText(args[1] + ".bat", batchfilecont,Encoding.UTF8);
                            
                        }
                    }
                    
                }

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
