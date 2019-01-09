using StreamBED.Backend.Helper;
using StreamBED.Backend.Models;
using StreamBED.Backend.Models.ProtocolModels;
using StreamBED.Frontend.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StreamBED.Frontend.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeatureSelectionPage : Page
    {
        private static EpifaunalSubstrateModel EpifaunalSubstrateModel = new EpifaunalSubstrateModel();

        private static BankStabilityModel BankStabilityModel = new BankStabilityModel();

        internal static Dictionary<Keyword, FeatureDataModel> epifaunalSubstrateFeatures = new Dictionary<Keyword, FeatureDataModel>();

        internal static Dictionary<Keyword, FeatureDataModel> bankStabilityFeatures = new Dictionary<Keyword, FeatureDataModel>();

        internal static FeatureDataModel SelectedFeature;

        private ProtocolModel SelectedModel;

        public FeatureSelectionPage()
        {
            this.InitializeComponent();
        }

        private void PivotRoot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pivotRoot.SelectedIndex == 1)
            {
                nextButton.Content = "Get Started";
                nextButton.Width = 310;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (pivotRoot.SelectedIndex < 1)
            {
                pivotRoot.SelectedIndex = ++pivotRoot.SelectedIndex;
            }
            else
            {
                ++layoutPivot.SelectedIndex;

                InitializeProtocol(BankStabilityModel.GetKeywords(), BankStabilityModel);
                InitializeProtocol(EpifaunalSubstrateModel.GetKeywords(), EpifaunalSubstrateModel);
            }
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            protocolTitle.Text = "BANK STABILITY";
            SelectedModel = BankStabilityModel;

            listViewRoot.Items.Clear();

            foreach (FeatureDataModel feature in bankStabilityFeatures.Values)
            {
                listViewRoot.Items.Add(feature);
            }

            ++layoutPivot.SelectedIndex;
        }

        private void StackPanel_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            protocolTitle.Text = "EPIFAUNAL SUBSTRATE";
            SelectedModel = EpifaunalSubstrateModel;

            listViewRoot.Items.Clear();

            foreach (FeatureDataModel feature in epifaunalSubstrateFeatures.Values)
            {
                listViewRoot.Items.Add(feature);
            }

            ++layoutPivot.SelectedIndex;
        }

        private void InitializeProtocol(Keyword[] keywords, ProtocolModel model) 
        {
            foreach (Keyword keyword in keywords)
            {
                foreach (ImageDataModel image in FeaturePage.SelectedItems)
                {
                    if (image.Image.Keywords.Contains(keyword))
                    {
                        if (model is EpifaunalSubstrateModel)
                        {
                            if (!epifaunalSubstrateFeatures.ContainsKey(keyword))
                            {
                                epifaunalSubstrateFeatures.Add(keyword, new FeatureDataModel(keyword));
                            }

                            if (!epifaunalSubstrateFeatures.GetValueOrDefault(keyword).ImageList.Contains(image))
                            {
                                epifaunalSubstrateFeatures.GetValueOrDefault(keyword).ImageList.Add(image);
                            }
                        }
                        else if (model is BankStabilityModel)
                        {
                            if (!bankStabilityFeatures.ContainsKey(keyword))
                            {
                                bankStabilityFeatures.Add(keyword, new FeatureDataModel(keyword));
                            }

                            if (!bankStabilityFeatures.GetValueOrDefault(keyword).ImageList.Contains(image))
                            {
                                bankStabilityFeatures.GetValueOrDefault(keyword).ImageList.Add(image);
                            }
                        }
                    }
                }
            }
        }

        private void LayoutPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = layoutPivot.SelectedIndex;

            if (index == 0)
            {
                navBar.Visibility = Visibility.Collapsed;
                protocolBlock.Visibility = Visibility.Collapsed;
                featureBlock.Visibility = Visibility.Collapsed;
                nextImageButton.Visibility = Visibility.Collapsed;
            }
            else if (index == 1)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Collapsed;
                featureBlock.Visibility = Visibility.Collapsed;
                nextImageButton.Visibility = Visibility.Collapsed;
            }
            else if (index == 2)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Visible;
                featureBlock.Visibility = Visibility.Collapsed;
                nextImageButton.Visibility = Visibility.Collapsed;
            }
            else if (index == 3)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Visible;
                featureBlock.Visibility = Visibility.Visible;
                nextImageButton.Visibility = Visibility.Visible;
            }
        }

        private void EvalTitle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (layoutPivot.SelectedIndex > 1)
            {
                layoutPivot.SelectedIndex = 1;
            }
        }

        private void ProtocolTitle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (layoutPivot.SelectedIndex > 2)
            {
                layoutPivot.SelectedIndex = 2;
            }
        }

        private void GlanceCloseButton_Click(object sender, RoutedEventArgs e)
        {
            glanceProtocol.Visibility = Visibility.Collapsed;
        }

        private void TemplateRoot_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SelectedFeature = (sender as StackPanel).DataContext as FeatureDataModel;

            featureTitle.Text = SelectedFeature.Keyword.Content.ToUpper();

            if (SelectedModel is EpifaunalSubstrateModel)
            {
                assessmentFrame.Navigate(typeof(EpifaunalAssessmentPage));
            }
            else if (SelectedModel is BankStabilityModel)
            {
                assessmentFrame.Navigate(typeof(BankAssessmentPage));
            }

            ++layoutPivot.SelectedIndex;
        }

        private void NextImageButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (SelectedModel is EpifaunalSubstrateModel)
            {
                var page = assessmentFrame.Content as EpifaunalAssessmentPage;

                if (page.NextImage() == -1)
                {
                    
                }
            }
            else if (SelectedModel is BankStabilityModel)
            {
                var page = assessmentFrame.Content as BankAssessmentPage;

                if (page.NextImage() == -1)
                {

                }
            }
        }
    }
}
