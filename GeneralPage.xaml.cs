using Microsoft.Win32;
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

namespace The_Escapists_Global_Editor
{
    /// <summary>
    /// Interaction logic for GeneralPage.xaml
    /// </summary>
    public partial class GeneralPage : Page
    {
        public GeneralPage()
        {
            InitializeComponent();
        }

        private List<string> chosenItems = new List<string>();
        private List<Button> buttonsToEnable = new List<Button>();
        private HashSet<string> addedItems = new HashSet<string>();
        private int itemCount = 1;
        private string newItem;
        private string itemCode;
        private List<string> items = new List<string>()
        {
            "126=1", "54=1", "83=1", "124=1", "125=1", "105=1", "128=1", "142=1", "185=1", "184=1", "89=1", "174=1", "117=1", "116=1", "120=1",
            "188=1", "115=1", "19=1", "112=1", "113=1", "3=1", "153=1", "38=1", "111=1", "121=1", "119=1", "114=1", "188=1", "84=1", "181=1", 
            "108=1", "129=1", "143=1", "101=1", "87=1", "88=1", "86=1", "85=1", "58=1", "130=1", "144=1", "99=1", "186=1", "187=1", "57=1",
            "81=1", "103=1", "183=1", "71=1", "180=1", "61=1", "39=1", "5=1", "104=1", "72=1", "122=1", "75=1", "82=1", "53=1", "110=1",
            "182=1", "59=1", "189=1"
        };
        private List<string> usedItems = new List<string>();
        private List<string> unusedItems = new List<string>();
        private List<string> baseDat = new List<string>
        {
            "[Prisons]", "tutorial=1", "perks=1", "stalagflucht=1", "shanktonstatepen=1", "jungle=1", "sanpancho=1", "irongate=1", "[CraftNotes]"
        };
        private string[][] fullDat = new string[74][];
        private void RedClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Plastic Staff Key";

            if (!addedItems.Contains(newItem))
            {
                ++itemCount;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);

                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "86=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void OrangeClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Plastic Utility Key";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "85=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void PurpleClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Plastic Enterance Key";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "88=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void GreenClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Plastic Work Key";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "58=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void MultitoolClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Multitool";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "181=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void CuttersClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Sturdy Cutters";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "61=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void RopeClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Sheet Rope";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "81=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void GrappleClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Grappling Hook";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "113=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void PosterClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Poster";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "99=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void FenceClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Fake Fence";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "174=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void VentClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Fake Vent Cover";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "117=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void BraceClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Timber Brace";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "72=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void CupClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Cup of Molten Chocolate";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "105=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void OutfitClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Plated Inmate Outfit";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "130=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void GuardClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Guard Outfit";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "3=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void ContrabandClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Durable Contraband Pouch";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "184=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void PapersClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. ID Papers";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "153=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void RaftClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Makeshift Raft";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "188=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void ScrewdriverClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Powered Screwdriver";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "186=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void ZipClick(object sender, RoutedEventArgs e)
        {
            newItem = $"{itemCount}. Zipline Hook";

            if (!addedItems.Contains(newItem))
            {
                itemCount++;
                GeneralListTextBox.AppendText(newItem + Environment.NewLine);

                addedItems.Add(newItem);
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                buttonsToEnable.Add(clickedButton);
                itemCode = "189=1";
                chosenItems.Add(itemCode);
                ButtonReset();
            }
        }
        private void GeneralResetClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GeneralPage());
        }
        private void GeneralCreateClick(object sender, RoutedEventArgs e)
        {
            DatEncrypter();
        }
        private void GeneralItemsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllPage());
        }
        public void ListDeclaration()
        {
            usedItems = chosenItems;
            unusedItems = items.Except(usedItems).ToList();
        }
        public void DatMaker()
        {
            int numberOfIterations = Math.Min(usedItems.Count, unusedItems.Count / 3);
            
            for (int i = 0; i <= 15; i++)
            {
                ListDeclaration();
                if (i == 15 && i < usedItems.Count)
                {
                    baseDat.Add(usedItems[i]);
                }
                else if (i < usedItems.Count)
                {
                    baseDat.Add(unusedItems[i * 3]);
                    baseDat.Add(unusedItems[i * 3 + 1]);
                    baseDat.Add(unusedItems[i * 3 + 2]);
                    baseDat.Add(usedItems[i]);
                }
            }
        }
        public void ButtonReset()
        {
            if (itemCount == 17)
            {
                RedButton.IsEnabled = false;
                OrangeButton.IsEnabled = false;
                PurpleButton.IsEnabled = false;
                GreenButton.IsEnabled = false;
                MultitoolButton.IsEnabled = false;
                CuttersButton.IsEnabled = false;
                RopeButton.IsEnabled = false;
                GrappleButton.IsEnabled = false;
                PosterButton.IsEnabled = false;
                FenceButton.IsEnabled = false;
                VentButton.IsEnabled = false;
                BraceButton.IsEnabled = false;
                CupButton.IsEnabled = false;
                OutfitButton.IsEnabled = false;
                GuardButton.IsEnabled = false;
                ContrabandButton.IsEnabled = false;
                PapersButton.IsEnabled = false;
                RaftButton.IsEnabled = false;
                ScrewdriverButton.IsEnabled = false;
                ZipButton.IsEnabled = false;
            } else
            {
                return;
            }
        }
        public void DatEncrypter()
        {
            DatMaker();
            byte[] inputBytes;
            string key = "mothking";
            byte[] encryptedData;

            string baseDatString = string.Join(Environment.NewLine, baseDat);

            inputBytes = Encoding.UTF8.GetBytes(baseDatString);
            BlowfishCompat encryptionBlowfish = new BlowfishCompat(key);
            encryptedData = encryptionBlowfish.Encrypt(inputBytes);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Dat Files (*.dat)|*.dat";
            saveFileDialog.Title = "Select the location you want the result to be.";
            saveFileDialog.FileName = "global.dat";

            if (saveFileDialog.ShowDialog() == true)
            {
                string selectedResultLocation = saveFileDialog.FileName;
                System.IO.File.WriteAllBytes(selectedResultLocation, encryptedData);
            }
        }
    }
}
