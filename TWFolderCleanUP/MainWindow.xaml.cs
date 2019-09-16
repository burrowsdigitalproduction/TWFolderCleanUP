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
                 "__", "1518", "1519", "1625", "1626", "1627", "1628", "1629", "1630", "1631", "1642", "1643", "1644", "2790", "2791", "2792", "2793", "2794", "2795", "2796", "2797"
            };

            List<string> RoccaCodes = new List<string>
            {
                "1823",
                "1546",
                "1489",
                "1821",
                "2632",
                "2633"
            };

            List<string> GapCodes = new List<string>
            {
                "1761",
                "1764",
                "1822",
                "3241"
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

                            foreach (string rad in Radcodes)
                            {
                                if (f.FullName.Contains(rad))
                                {
                                    foreach (string Rocca in RoccaCodes)
                                    {
                                        string movingto = moveto + "\\" + type.TrimEnd('.') + "\\" + rad + "\\Rocca" + "\\" + Rocca;

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
                                                    if (!Directory.Exists(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\Rocca" + "\\" + Rocca))
                                                    {
                                                        Directory.CreateDirectory(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\Rocca" + "\\" + Rocca);
                                                    }
                                                    f.MoveTo(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\Rocca" + "\\" + Rocca + "\\" + f.Name);
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
                                        string movingto = moveto + "\\" + type.TrimEnd('.') + "\\" + rad + "\\Gap" + "\\" + Gap;

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
                                                    if (!Directory.Exists(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\Gap" + "\\" + Gap))
                                                    {
                                                        Directory.CreateDirectory(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\Gap" + "\\" + Gap);
                                                    }

                                                    f.MoveTo(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\Gap" + "\\" + Gap + "\\" + f.Name);
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
                                        string movingto = moveto + "\\" + type.TrimEnd('.') + "\\" + rad + "\\E100" + "\\" + E100;

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
                                                    if (!Directory.Exists(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\E100" + "\\" + E100))
                                                    {
                                                        Directory.CreateDirectory(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\E100" + "\\" + E100);
                                                    }
                                                    f.MoveTo(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\E100" + "\\" + E100 + "\\" + f.Name);
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
                                        string movingto = moveto + "\\" + type.TrimEnd('.') + "\\" + rad + "\\E500" + "\\" + E500;

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
                                                    if (!Directory.Exists(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\E500" + "\\" + E500))
                                                    {
                                                        Directory.CreateDirectory(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\E500" + "\\" + E500);
                                                    }
                                                    f.MoveTo(dupe + "\\" + type.TrimEnd('.') + "\\" + rad + "\\E500" + "\\" + E500 + "\\" + f.Name);
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
    }
}





