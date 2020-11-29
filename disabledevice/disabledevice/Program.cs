using BucketBox.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace disabledevice
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {


                String appversion = Application.ProductName + " - " + Application.ProductVersion;
                Console.WriteLine(appversion);

                if (args != null && args.Length > 0 && args[0] != null)
                {
                    {
                        DisableHardware.DisableDevice(x => x.Contains(args[0]));
                    }
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

                Console.ReadLine();
                //MessageBox.Show(ex.ToString());
                // Scrabler.ScrablerCore.ErrorLogScript(ex);
            }
        }
    }
}
