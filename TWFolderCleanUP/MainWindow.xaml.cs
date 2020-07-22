using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;

namespace TWFolderCleanUP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string root;

        private void BtnBathTileRun_Click(object sender, RoutedEventArgs e)
        {
            OrganiseAssets();
        }

        private void tbCleanRawFolder_Click(object sender, RoutedEventArgs e)
        {
            OrganiseRAWAssets();
        }


        private void OrganiseAssets()
        {

            root = @tbTWBathroomAssetLocation.Text;

            DirectoryInfo rootdir = new DirectoryInfo(root);
            string moveto = @"\\bcluster\burrows\digital\autorender\taylorwimpey\Production\Bathroom\Assets\Final\Tiles3";


            List<string> areaType = new List<string>
            {
                "_full.",
                "_fullmirror.",
                "_half.",
                "_halfshower.",
                "_std.",
                "_stdshower."
            };

            List<string> Radcodes = new List<string>
            {
                 "__" //, "1518", "1519", "1625", "1626", "1627", "1628", "1629", "1630", "1631", "1642", "1643", "1644", "2790", "2791", "2792", "2793", "2794", "2795", "2796", "2797"
            };

            List<string> RoccaCodes = new List<string>
            {
                "1823",
                "1546",
                "1489",
                "1821",
                "2632",
                "2633",
                "3241",
                "3729",
                "3730",
                "3731",
                "3732",
                "3733",
                "3734",
                "3735",
                "3736"
            };

            List<string> GapCodes = new List<string>
            {
                "1761",
                "1752",
                "1764",
                "1822",
                "3584",
                "3585",
                "3586",
                "3587",
                "3588",
                "3589",
                "3590",
                "3591"
            };

            List<string> E100Codes = new List<string>
            {
                "1488",
                "1825",
                "1828",
                "1747",
                "2644"
            };

            List<string> E500Codes = new List<string>
            {
                "1490",
                "1820",
                "1824",
                "1768",
                "1767"
            };

            string dupe = @"\\bcluster\\burrows\\digital\autorender\\taylorwimpey\\Production\\Bathroom\\Assets\\Final\\Duplicates" + "\\";

            List<DirectoryInfo> folders = new List<DirectoryInfo>();

            folders.Add(rootdir);

            foreach (string fldinfo in Directory.GetDirectories(root, "*", SearchOption.AllDirectories))
            {
                DirectoryInfo tmpfldr = new DirectoryInfo(fldinfo);
                folders.Add(tmpfldr);
            }

            if (!Directory.Exists(moveto))
            {
                Directory.CreateDirectory(moveto);
            }

            foreach (DirectoryInfo fldr in folders)
            {
                
                FileInfo[] filelist = fldr.GetFiles();


                foreach (FileInfo f in filelist)
                {
                    foreach (string type in areaType)
                    {
                        if (f.FullName.Contains(type))
                        {

                                   foreach (string Rocca in RoccaCodes)
                                    {
                                        string movingto = moveto + "\\" + type.TrimEnd('.') + "\\" + "\\Rocca" + "\\" + Rocca;

                                        if (f.Name.Contains(Rocca))
                                        {

                                            string fpath = movingto + "\\" + f.Name;

                                            if (Directory.Exists(movingto))
                                            {
                                                if (!File.Exists(fpath))
                                                { 
                                                f.MoveTo(movingto + "\\" + f.Name);
                                                }
                                                else if (File.Exists(movingto + "\\" + f.Name))
                                                {
                                                    if (!Directory.Exists(dupe + "\\" + type.TrimEnd('.') + "\\" + "\\Rocca" + "\\" + Rocca))
                                                    {
                                                        Directory.CreateDirectory(dupe + "\\" + type.TrimEnd('.') + "\\" + "\\Rocca" + "\\" + Rocca);
                                                    }
                                                    f.MoveTo(dupe + "\\" + type.TrimEnd('.') + "\\" + "\\Rocca" + "\\" + Rocca + "\\" + f.Name);
                                                }
                                            }
                                            else if (!Directory.Exists(movingto))
                                            {

                                                Directory.CreateDirectory(movingto);
                                                f.MoveTo(movingto + "\\" + f.Name);
                                            }
                                        }
                                        
                                    }

                                    foreach (string Gap in GapCodes)
                                    {
                                        string movingto = moveto + "\\" + type.TrimEnd('.') + "\\" +  "\\Gap" + "\\" + Gap;

                                        if (f.Name.Contains(Gap))
                                        {
                                            string fpath = movingto + "\\" + f.Name;

                                            if (Directory.Exists(movingto))
                                            {
                                                if (!File.Exists(fpath))
                                                {
                                                    f.MoveTo(movingto + "\\" + f.Name);
                                                }
                                                else if (File.Exists(movingto + "\\" + f.Name))
                                                {
                                                    if (!Directory.Exists(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\Gap" + "\\" + Gap))
                                                    {
                                                        Directory.CreateDirectory(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\Gap" + "\\" + Gap);
                                                    }

                                                    f.MoveTo(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\Gap" + "\\" + Gap + "\\" + f.Name);
                                                }
                                            }
                                        else if (!Directory.Exists(movingto))
                                        {
                                            Directory.CreateDirectory(movingto);
                                            f.MoveTo(movingto + "\\" + f.Name);

                                        }

                                        }
                                    }

                                    foreach (string E100 in E100Codes)
                                    {
                                        string movingto = moveto + "\\" + type.TrimEnd('.') + "\\" +  "\\E100" + "\\" + E100;

                                        if (f.Name.Contains(E100))
                                        {
                                            string fpath = movingto + "\\" + f.Name;

                                            if (Directory.Exists(movingto))
                                            {
                                                if (!File.Exists(fpath))
                                                {
                                                    f.MoveTo(movingto + "\\" + f.Name);
                                                }
                                                else if (File.Exists(movingto + "\\" + f.Name))
                                                {
                                                    if (!Directory.Exists(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\E100" + "\\" + E100))
                                                    {
                                                        Directory.CreateDirectory(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\E100" + "\\" + E100);
                                                    }
                                                    f.MoveTo(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\E100" + "\\" + E100 + "\\" + f.Name);
                                                }
                                            }
                                            else if (!Directory.Exists(movingto))
                                            {
                                                Directory.CreateDirectory(movingto);
                                                f.MoveTo(movingto + "\\" + f.Name);

                                            }
                                        }

                                    }

                                    foreach (string E500 in E500Codes)
                                    {
                                        string movingto = moveto + "\\" + type.TrimEnd('.') + "\\" +  "\\E500" + "\\" + E500;

                                        if (f.Name.Contains(E500))
                                        {
                                            string fpath = movingto + "\\" + f.Name;

                                            if (Directory.Exists(movingto))
                                            {
                                                if (!File.Exists(fpath))
                                                {
                                                    f.MoveTo(movingto + "\\" + f.Name);
                                                }
                                                else if (File.Exists(movingto + "\\" + f.Name))
                                                {
                                                    if (!Directory.Exists(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\E500" + "\\" + E500))
                                                    {
                                                        Directory.CreateDirectory(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\E500" + "\\" + E500);
                                                    }
                                                    f.MoveTo(dupe + "\\" + type.TrimEnd('.') + "\\" +  "\\E500" + "\\" + E500 + "\\" + f.Name);
                                                }
                                            }
                                            else if (!Directory.Exists(movingto))
                                            {
                                                Directory.CreateDirectory(movingto);
                                                f.MoveTo(movingto + "\\" + f.Name);

                                            }
                                        }


                                    }

                                
                            }
                        
                    }

                }

            }
            string z = dupe.Substring(0, 102);
            DirectoryInfo dupefldr = new DirectoryInfo(z);

            if (dupefldr.Exists)
            { int dupecount = dupefldr.GetFiles("*", SearchOption.AllDirectories).Count();

                string dupescount = "Duplicates left over in folder = " + dupecount;
                System.Windows.MessageBox.Show(dupescount, "Done", MessageBoxButton.OK);

            }
            else
            {
                System.Windows.MessageBox.Show("All Done", "All Done", MessageBoxButton.OK);
            }

            

            


            

        }

        private void OrganiseRAWAssets()
        {
            root = tbRawRoot.Text;

            DirectoryInfo rootdir = new DirectoryInfo(root);
            string moveto = @"\\bcluster\burrows\digital\autorender\taylorwimpey\Production\Bathroom\Assets\TilesTemp";


            List<string> TileAreas = new List<string>()
            {
                "sbk_ws",
                "sbk",
                "half_ws",
                "_half_p",
                "full_p"

            };

            List<string> Packages = new List<string>()
            {
                "e100_pedestal",
                "e500_pedestal",
                "roca_valorped",
                "thegap_fullped"
            };


            List<DirectoryInfo> folders = new List<DirectoryInfo>();

            folders.Add(rootdir);

            foreach (string fldinfo in Directory.GetDirectories(root, "*", SearchOption.AllDirectories))
            {
                DirectoryInfo tmpfldr = new DirectoryInfo(fldinfo);
                folders.Add(tmpfldr);
            }

            if (!Directory.Exists(moveto))
            {
                Directory.CreateDirectory(moveto);
                Directory.CreateDirectory(moveto + "//" + "sbk");
                Directory.CreateDirectory(moveto + "//" + "sbk_ws");
                Directory.CreateDirectory(moveto + "//" + "half");
                Directory.CreateDirectory(moveto + "//" + "half_ws");
                Directory.CreateDirectory(moveto + "//" + "full");
            }
            else
            {
                moveto = moveto + "2";
                Directory.CreateDirectory(moveto);
                Directory.CreateDirectory(moveto + "//" + "sbk");
                Directory.CreateDirectory(moveto + "//" + "sbk_ws");
                Directory.CreateDirectory(moveto + "//" + "half");
                Directory.CreateDirectory(moveto + "//" + "half_ws");
                Directory.CreateDirectory(moveto + "//" + "full");
            }

            

            foreach (DirectoryInfo fldr in folders)
            {

                FileInfo[] filelist = fldr.GetFiles();


                
                    foreach (string t in TileAreas)
                    {
                        
                        foreach (string p in Packages) 
                        {

                        foreach (FileInfo f in filelist)
                        {

                            string areafix = null;

                            if (t == "_half_p")
                            {
                                areafix = "half";

                            }
                            if (t == "full_p")
                            {
                                areafix = "full";
                            }
                            if (t == "sbk")
                            {
                                areafix = "sbk";
                            }
                            if (t == "sbk_ws")
                            {
                                areafix = "sbk_ws";
                            }


                            if (f.Name.Contains(t) && f.Name.Contains(p))
                            {
                                string movingto;


                                if (t == "sbk" && f.Name.Contains("sbk_ws"))
                                {
                                    break;
                                }
                                if(t == "full_p" && f.Name.Contains("sbk"))
                                {
                                    break;
                                }

                                if (areafix == null)
                                {
                                     movingto = moveto + "\\" + t + "\\" + p;
                                    if (!Directory.Exists(movingto))
                                    {
                                        Directory.CreateDirectory(movingto);
                                    }

                                }
                                else
                                {
                                    movingto = moveto + "\\" + areafix + "\\" + p;
                                    if (!Directory.Exists(movingto))
                                    {
                                        Directory.CreateDirectory(movingto);
                                    }
 
                                }

                                string fpath = movingto + "\\" + f.Name;

                                FileInfo destFile = new FileInfo(fpath);


                                if (File.Exists(movingto + "\\" + f.Name))
                                {
                                    if (f.LastWriteTime > destFile.LastWriteTime)
                                    {
                                        destFile.Delete();
                                        f.MoveTo(movingto + "\\" + f.Name);
                                    }

                                }
                                else if (!File.Exists(movingto + "\\" + f.Name))
                                {
                                    try
                                    {
                                        if (f.LastWriteTime > destFile.LastWriteTime)
                                        {
                                            destFile.Delete();
                                            f.MoveTo(movingto + "\\" + f.Name);
                                        }
                                    }
                                    catch(Exception e)
                                    {
                                        if (f.LastWriteTime > destFile.LastWriteTime)
                                        {
                                            destFile.Delete();
                                            f.MoveTo(moveto + "\\" + f.Name);
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    f.MoveTo(moveto + "\\" + f.Name);
                                }

                                

                            }





                        }
                    }
                }

            }

            System.Windows.MessageBox.Show("Done", "Done", MessageBoxButton.OK);

        }

        
    }
}





