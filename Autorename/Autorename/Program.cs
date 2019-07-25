using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autorename
{
    class Program
    {
       static Core core = new Core();
        static void Main(string[] args)
        {
            try
            {
                core.PrintAppInfoOnConsole();
            
                if ( args !=null && args.Length==1 && args[0] !=null)
                {
                    Console.WriteLine("Folder  it's working under : \n{0}", args[0]);
                    core.Rename(args[0]);
                }
                else
                {
                    Console.WriteLine("Use it {0} +  folder Path from command line \n ",Application.ExecutablePath);
                }
                Console.WriteLine("Finishded at: "+DateTime.Now.ToLongDateString() +"\n"+ DateTime.Now.ToLongTimeString()+"\n Press Enter to Exit\n");
                Console.ReadLine();
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                RenameLogger.errorhandling(ex);
                Console.ReadLine();
                //MessageBox.Show(ex.ToString());
                // Scrabler.ScrablerCore.ErrorLogScript(ex);
            }
        }
    }
}
