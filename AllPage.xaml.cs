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
    /// Interaction logic for AllPage.xaml
    /// </summary>
    public partial class AllPage : Page
    {
        private string itemCodeAll;
        private string newItem;
        private int itemCount = 1;
        private HashSet<string> addedItems = new HashSet<string>();
        private List<Button> buttonsToEnable = new List<Button>();
        private List<string> chosenItems = new List<string>();
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


        public AllPage()
        {
            InitializeComponent();
            ButtonAdd();
        }
        private void ButtonAdd()
        {
            buttonListBox.Items.Add(CreateButton("Bed Dummy"));
            buttonListBox.Items.Add(CreateButton("Candle"));
            buttonListBox.Items.Add(CreateButton("Cell Key Mold"));
            buttonListBox.Items.Add(CreateButton("Comb Blade"));
            buttonListBox.Items.Add(CreateButton("Contraband Pouch"));
            buttonListBox.Items.Add(CreateButton("Cup of Molten Chocolate"));
            buttonListBox.Items.Add(CreateButton("Cushioned Inmate Outfit"));
            buttonListBox.Items.Add(CreateButton("Cushioned POW Outfit"));
            buttonListBox.Items.Add(CreateButton("Cutting Floss"));
            buttonListBox.Items.Add(CreateButton("Durable Contraband Pouch"));
            buttonListBox.Items.Add(CreateButton("Entrance Key Mold"));
            buttonListBox.Items.Add(CreateButton("Fake Fence"));
            buttonListBox.Items.Add(CreateButton("Fake Vent Cover"));
            buttonListBox.Items.Add(CreateButton("Fake Wall Block"));
            buttonListBox.Items.Add(CreateButton("Flimsy Cutters"));
            buttonListBox.Items.Add(CreateButton("Flimsy Pickaxe"));
            buttonListBox.Items.Add(CreateButton("Flimsy Shovel"));
            buttonListBox.Items.Add(CreateButton("Glass Shank"));
            buttonListBox.Items.Add(CreateButton("Grapple Head"));
            buttonListBox.Items.Add(CreateButton("Grappling Hook"));
            buttonListBox.Items.Add(CreateButton("Guard Outfit"));
            buttonListBox.Items.Add(CreateButton("ID Papers"));
            buttonListBox.Items.Add(CreateButton("Infirmary Overalls"));
            buttonListBox.Items.Add(CreateButton("Knuckle Duster"));
            buttonListBox.Items.Add(CreateButton("Lightweight Cutters"));
            buttonListBox.Items.Add(CreateButton("Lightweight Pickaxe"));
            buttonListBox.Items.Add(CreateButton("Lightweight Shovel"));
            buttonListBox.Items.Add(CreateButton("Makeshift Raft"));
            buttonListBox.Items.Add(CreateButton("Molten Plastic"));
            buttonListBox.Items.Add(CreateButton("Multitool"));
            buttonListBox.Items.Add(CreateButton("Nunchuks"));
            buttonListBox.Items.Add(CreateButton("Padded Inmate Outfit"));
            buttonListBox.Items.Add(CreateButton("Padded POW Outfit"));
            buttonListBox.Items.Add(CreateButton("Paper Mache"));
            buttonListBox.Items.Add(CreateButton("Plastic Cell Key"));
            buttonListBox.Items.Add(CreateButton("Plastic Entrance Key"));
            buttonListBox.Items.Add(CreateButton("Plastic Staff Key"));
            buttonListBox.Items.Add(CreateButton("Plastic Utility Key"));
            buttonListBox.Items.Add(CreateButton("Plastic Work Key"));
            buttonListBox.Items.Add(CreateButton("Plated Inmate Outfit"));
            buttonListBox.Items.Add(CreateButton("Plated POW Outfit"));
            buttonListBox.Items.Add(CreateButton("Poster"));
            buttonListBox.Items.Add(CreateButton("Powered Screwdriver"));
            buttonListBox.Items.Add(CreateButton("Raft Base"));
            buttonListBox.Items.Add(CreateButton("Sail"));
            buttonListBox.Items.Add(CreateButton("Sheet Rope"));
            buttonListBox.Items.Add(CreateButton("Sock Mace"));
            buttonListBox.Items.Add(CreateButton("Spiked Bat"));
            buttonListBox.Items.Add(CreateButton("Staff Key Mold"));
            buttonListBox.Items.Add(CreateButton("Stinger Strip"));
            buttonListBox.Items.Add(CreateButton("Sturdy Cutters"));
            buttonListBox.Items.Add(CreateButton("Sturdy Pickaxe"));
            buttonListBox.Items.Add(CreateButton("Sturdy Shovel"));
            buttonListBox.Items.Add(CreateButton("Super Sock Mace"));
            buttonListBox.Items.Add(CreateButton("Timber Brace"));
            buttonListBox.Items.Add(CreateButton("Tool Handle"));
            buttonListBox.Items.Add(CreateButton("Unvarnished Chair"));
            buttonListBox.Items.Add(CreateButton("Utility Key Mold"));
            buttonListBox.Items.Add(CreateButton("Wad of Putty"));
            buttonListBox.Items.Add(CreateButton("Whip"));
            buttonListBox.Items.Add(CreateButton("Wooden Bat"));
            buttonListBox.Items.Add(CreateButton("Work Key Mold"));
            buttonListBox.Items.Add(CreateButton("Zipline Hook"));
        }
        private Button CreateButton(string itemName)
        {
            Button button = new Button();
            button.Content = itemName;
            button.Click += ItemButtonClick;
            return button;
        }
        private void AllResetClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllPage());
        }
        private void AllCreateClick(object sender, RoutedEventArgs e)
        {
            DatEncrypter();
        }
        private void AllBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GeneralPage());
        }

        private void ItemButtonClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                string itemName = clickedButton.Content.ToString();

                switch (itemName)
                {
                    case "Bed Dummy":
                        itemCodeAll = "126=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Candle":
                        itemCodeAll = "54=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Cell Key Mold":
                        itemCodeAll = "83=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Comb Blade":
                        itemCodeAll = "124=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Contraband Pouch":
                        itemCodeAll = "125=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Cup of Molten Chocolate":
                        itemCodeAll = "105=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Cushioned Inmate Outfit":
                        itemCodeAll = "128=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Cushioned POW Outfit":
                        itemCodeAll = "142=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Cutting Floss":
                        itemCodeAll = "185=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Durable Contraband Pouch":
                        itemCodeAll = "184=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Entrance Key Mold":
                        itemCodeAll = "89=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Fake Fence":
                        itemCodeAll = "174=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Fake Vent Cover":
                        itemCodeAll = "117=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Fake Wall Block":
                        itemCodeAll = "116=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Flimsy Cutters":
                        itemCodeAll = "120=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Flimsy Pickaxe":
                        itemCodeAll = "118=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Flimsy Shovel":
                        itemCodeAll = "115=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Glass Shank":
                        itemCodeAll = "19=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Grapple Head":
                        itemCodeAll = "112=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Grappling Hook":
                        itemCodeAll = "113=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Guard Outfit":
                        itemCodeAll = "3=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "ID Papers":
                        itemCodeAll = "153=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Infirmary Overalls":
                        itemCodeAll = "38=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Knuckle Duster":
                        itemCodeAll = "111=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Lightweight Cutters":
                        itemCodeAll = "121=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Lightweight Pickaxe":
                        itemCodeAll = "119=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Lightweight Shovel":
                        itemCodeAll = "114=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Makeshift Raft":
                        itemCodeAll = "188=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Molten Plastic":
                        itemCodeAll = "84=1"; newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Multitool":
                        itemCodeAll = "181=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Nunchuks":
                        itemCodeAll = "108=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Padded Inmate Outfit":
                        itemCodeAll = "129=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Padded POW Outfit":
                        itemCodeAll = "143=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Paper Mache":
                        itemCodeAll = "101=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Plastic Cell Key":
                        itemCodeAll = "87=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Plastic Entrance Key":
                        itemCodeAll = "88=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Plastic Staff Key":
                        itemCodeAll = "86=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Plastic Utility Key":
                        itemCodeAll = "85=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Plastic Work Key":
                        itemCodeAll = "58=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Plated Inmate Outfit":
                        itemCodeAll = "130=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Plated POW Outfit":
                        itemCodeAll = "144=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Poster":
                        itemCodeAll = "99=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Powered Screwdriver":
                        itemCodeAll = "186=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Raft Base":
                        itemCodeAll = "187=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Sail":
                        itemCodeAll = "57=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Sheet Rope":
                        itemCodeAll = "81=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Sock Mace":
                        itemCodeAll = "103=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Spiked Bat":
                        itemCodeAll = "183=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Staff Key Mold":
                        itemCodeAll = "71=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Stinger Strip":
                        itemCodeAll = "180=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Sturdy Cutters":
                        itemCodeAll = "61=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Sturdy Pickaxe":
                        itemCodeAll = "39=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Sturdy Shovel":
                        itemCodeAll = "5=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Super Sock Mace":
                        itemCodeAll = "104=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Timber Brace":
                        itemCodeAll = "72=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Tool Handle":
                        itemCodeAll = "122=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Unvarnished Chair":
                        itemCodeAll = "75=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Utility Key Mold":
                        itemCodeAll = "82=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Wad of Putty":
                        itemCodeAll = "53=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Whip":
                        itemCodeAll = "110=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Wooden Bat":
                        itemCodeAll = "182=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Work Key Mold":
                        itemCodeAll = "59=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                    case "Zipline Hook":
                        itemCodeAll = "189=1";
                        newItem = $"{itemCount}. {itemName}";
                        if (!addedItems.Contains(newItem))
                        {
                            ++itemCount;
                            AllListTextBox.AppendText(newItem + Environment.NewLine);
                            addedItems.Add(newItem);
                            clickedButton.IsEnabled = false;
                            buttonsToEnable.Add(clickedButton);
                            chosenItems.Add(itemCodeAll);
                        }
                        break;
                }
            }
            if (itemCount == 17)
            {
                buttonListBox.IsEnabled = false;
            }
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
