using BucketBox.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace monitorbrightness
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static void Main(string[] args)
        {
            try
            {
                int gama=0, brightes=0, contrust=0,pausesec=0;
                var handle = GetConsoleWindow();
                String appversion = Application.ProductName + " - " + Application.ProductVersion;
                Console.WriteLine(appversion);
                if (args != null && args.Length > 0 && args[0] != null)
                {
                    Monitor mon = new Monitor(handle);
                    if (args.Contains("-g") == true)
                    {
                        int i = -1;
                        for (i = 0; i < args.Length; i++)
                        {
                            if (args[i] == "-g")
                            {

                                break;

                            }
                        }
                        int j = i + 1;
                        if (j < args.Length)
                        {
                            gama = int.Parse(args[j]);
                            mon.SetGamma(gama);

                        }

                    }
                    if (args.Contains("-b") == true)
                    {
                        int i = -1;
                        for (i = 0; i < args.Length; i++)
                        {
                            if (args[i] == "-b")
                            {

                                break;

                            }
                        }
                        int j = i + 1;
                        if (j < args.Length)
                        {
                            brightes = int.Parse(args[j]);
                            mon.SetBrightness(brightes);
                        }
                    }
                    if (args.Contains("-c") == true)
                    {
                        int i = -1;
                        for (i = 0; i < args.Length; i++)
                        {
                            if (args[i] == "-c")
                            {

                                break;

                            }
                        }
                        int j = i + 1;
                        if (j < args.Length)
                        {
                            contrust = int.Parse(args[j]);
                            mon.SetContrast(contrust);
                        }
                    }
                     if (args.Contains("-a") == true)
                    {
                        int i = -1;
                        for (i = 0; i < args.Length; i++)
                        {
                            if (args[i] == "-c")
                            {

                                break;

                            }
                        }
                        int j = i + 1;
                        if (j < args.Length)
                        {
                            pausesec = int.Parse(args[j]) * 1000;

                        }
                        while (true)
                        {
                            mon.SetBrightness(brightes);
                            mon.SetGamma(gama);
                            mon.SetContrast(contrust);
                            System.Threading.Thread.Sleep(pausesec);

                        }
                    }


                     if (args.Contains("-n") == true)
                    {
                        Application.Exit();
                    }
                    if (args.Contains("-l") == true)
                    {
                        int i = -1;

                        brightes = mon.GetBrightness();
                        contrust = mon.GetContrast();

                        Console.Write("Brightness :{0}% \n Contrast:{1}% \n", brightes, contrust);
                        Console.ReadLine();


                    }
                    else
                    {
                        Console.ReadLine();


                    }

                }
               
                else
                {
                    string help;
                    help = "To Change the gamma just use -g and an integer from 1 to 255\n" +
                        "To Change the birghtness just use -b and an integer from 0 to 100\n"+
                        "To Change the contrust just use -c and an integer from 0 to 100\n"+
                        "-n to close the application after it's done\n"+
                    "-a to keep  the application runing and  continusly set the arguments every second it is given\n"+
                    "-l Show the values for brightness ,contrast  ";
                    Console.Write(help);
                    Console.ReadLine();
                }
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
