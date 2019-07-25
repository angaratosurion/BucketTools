using System;
using System.Collections.Generic;
using Delimon.Win32.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autorename
{
    public class Core
    {
        const string diroffolderthatfilesexit = "alreadyexistedfiles";
        public  void Rename(string path)
        {
            try
            {
                if (path != null)
                {
                    string filesdidnotcopied="";
                    foreach (string s in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
                    {
                        string t = Path.GetFileName(s);
                        if (t.StartsWith("."))
                        {
                            int i;
                            string d = t.Substring(1);
                            string e = Path.GetDirectoryName(s);
                            File.Move(s, Path.Combine(e, d));
                        }
                        if (t.Contains(" ") == true || t.Contains("image") == true || t.Contains("image ") == true)
                        {
                            StringBuilder sBuilder = new StringBuilder();
                            using (var md5 = MD5.Create())
                            {
                                using (var stream = File.OpenRead(s))
                                {
                                    var data = md5.ComputeHash(stream);
                                    for (int i = 0; i < data.Length; i++)
                                    {
                                        sBuilder.Append(data[i].ToString("x2"));
                                        // sBuilder.Append(data[i].ToString());
                                    }
                                    Console.WriteLine("Renaming the file : {0}",t);
                                    string filename = sBuilder.ToString();
                                    string ext = Path.GetExtension(s);
                                    string e = Path.GetDirectoryName(s);
                                    this.CheckIfDirecotryExistOrCreateit(Path.Combine(e,diroffolderthatfilesexit));
                                    string newfilename = Path.Combine(e, filename) + ext;
                                    stream.Close();
                                    if (this.CheckIfFileExists(newfilename) == false)
                                    {
                                        File.Move(s, newfilename);
                                        string msg = "File  renamed succesfully  From " + s + " To " + newfilename;
                                       RenameLogger.LogMessage(msg);
                                    }
                                    else
                                    {
                                        filesdidnotcopied += "\n" + s;
                                        string msg = "File " + s + " already exists in  " + path + " so it is moved to "
                                            + Path.Combine(e, diroffolderthatfilesexit) +"\\"+ Path.GetFileName(s);
                                        File.Move(s, Path.Combine(e, diroffolderthatfilesexit) + "\\" + Path.GetFileName(s));
                                        RenameLogger.LogMessage(msg);
                                    }
                                  
                                   
                                }

                            }


                        }
                    }
                }
            }
            catch (Exception ex )
            {

                Console.WriteLine(ex.ToString());
                RenameLogger.errorhandling(ex);
            }
        }
        public   void CheckIfDirecotryExistOrCreateit(string directory)
        {
            try
            {
                bool ap = false;

                if ( Directory.Exists(directory)==false)
                {
                    Directory.CreateDirectory(directory);
                }

               
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                RenameLogger.errorhandling(ex);
              
            }
        }
        public  Boolean CheckIfFileExists(string filename)
        {
            try
            {
                Boolean ap = false;




                return File.Exists(filename);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                RenameLogger.errorhandling(ex);
                return false;

            }
        }
        public void PrintAppInfoOnConsole()
        {
            try
            {
                String AppInfo,desc;
                desc = "A small console utility which renames files with their md5 hash as their name";
                AppInfo = String.Format("{0}  {1} \n {2} \n {3} \n",Application.ProductName,Application.ProductVersion,Application.CompanyName,desc );

                Console.WriteLine(AppInfo);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                RenameLogger.errorhandling(ex);
              

            }
        }
    }
}
