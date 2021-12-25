using System;
using System.Windows;
using Pra.Safari.Core.Interfaces;
using Pra.Safari.Core.Services;
using System.Media;

namespace Pra.Safari.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SafariAdventure safariAdventure = new SafariAdventure();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddBear_Click(object sender, RoutedEventArgs e)
        {
            safariAdventure.AddBear();
            lstPredators.ItemsSource = safariAdventure.Predators;
            lstPredators.Items.Refresh();
            UpdateBtnHuntState();
            btnAddBear.IsEnabled = false;
        }


        private void BtnAddFox_Click(object sender, RoutedEventArgs e)
        {
            safariAdventure.AddFox();
            lstPredators.ItemsSource = safariAdventure.Predators;
            lstPredators.Items.Refresh();
            UpdateBtnHuntState();
        }

        private void BtnAddRabbit_Click(object sender, RoutedEventArgs e)
        {
            safariAdventure.AddRabbit();
            lstPreys.ItemsSource = safariAdventure.Prey;
            lstPreys.Items.Refresh();
            UpdateBtnHuntState();
            UpdateBtnBreedState();
        }

        private void BtnAddMouse_Click(object sender, RoutedEventArgs e)
        {
            safariAdventure.AddMouse();
            lstPreys.ItemsSource = safariAdventure.Prey;
            lstPreys.Items.Refresh();
            UpdateBtnHuntState();
            UpdateBtnBreedState();
        }

        private void BtnHunt_Click(object sender, RoutedEventArgs e)
        {
            safariAdventure.Hunt();
            lstPreys.Items.Refresh();
            lstPredators.Items.Refresh();
            UpdateBtnHuntState();
            UpdateBtnBreedState();
        }


        private void BtnBreed_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var parent1 = (IPrey)lstPreys.SelectedItems[0];
                var parent2 = (IPrey)lstPreys.SelectedItems[1];
                
                safariAdventure.Breed(parent1, parent2);
                lstPreys.UnselectAll();
                lstPreys.Items.Refresh();

            }
            catch(ArgumentOutOfRangeException)
            {

                MessageBox.Show("Gelieve meer dan 1 dier te kiezen");
            }

            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       private void UpdateBtnHuntState()
        {
            if (safariAdventure.Prey.Count > 0 && safariAdventure.Predators.Count > 0)
            {
                btnHunt.IsEnabled = true;
            }
            else
            {
                btnHunt.IsEnabled = false;
            }
        }

        private void UpdateBtnBreedState()
        {
            if (safariAdventure.Prey.Count > 1)
            {
                btnBreed.IsEnabled = true;
            }
            else
            {
                btnBreed.IsEnabled = false;
            }
        }

        private void LstPreys_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstPreys.SelectedItems.Count > 2)
            {
                lstPreys.SelectedItems.Clear();
            }
        }
       
    }
}
