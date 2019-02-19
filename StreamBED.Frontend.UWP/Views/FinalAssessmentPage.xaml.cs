using StreamBED.Backend.Helper;
using StreamBED.Backend.Models;
using StreamBED.Backend.Models.ProtocolModels;
using StreamBED.Frontend.UWP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class FinalAssessmentPage : Page
    {
        private ProtocolModel SelectedModel;

        private XElement icons;

        private bool epifaunalLoaded = false, bankLoaded = false;

        private EpifaunalSubstrateModel EpifaunalSubstrateModel = new EpifaunalSubstrateModel();

        private BankStabilityModel BankStabilityModel = new BankStabilityModel();

        private string resultEntry = "<participant id=\"" + LandingPage.ParticipantNumber + "\" official=\"" + LandingPage.IsOfficial + "\">\n"
                + "<ratings>\n";

        public FinalAssessmentPage()
        {
            this.InitializeComponent();
        }

        private void BankStability_Tapped(object sender, TappedRoutedEventArgs e)
        {
            protocolTitle.Text = "BANK STABILITY";
            SelectedModel = FeatureEvalPage.BankStabilityModel;

            if (!bankLoaded)
            {
                foreach (KeyValuePair<Keyword, FeatureDataModel> elem in FeatureEvalPage.bankStabilityFeatures)
                {
                    foreach (ImageDataModel image in elem.Value.ImageList)
                    {                  
                        Border border = new Border()
                        {
                            Width = 50,
                            Height = 50,
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(4),
                            Margin = new Thickness(0, 2.5, 0, 2.5)
                        };

                        Image icon = new Image()
                        {
                            Height = 45,
                            Width = 45,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Source = GetFeatureIcon(elem.Key)
                        };

                        border.Child = icon;

                        resultEntry += "<rating areaName=\"" + image.Image.Location + "\" keyword=\"" + elem.Key.FriendlyName + "\" score=\"" + image.Image.BankStabilityScore + "\" bias=\"false\" />\n";

                        if (image.Image.BankStabilityScore % 2 == 0)
                        {
                            foreach (StackPanel stack in bankStackTop.Children)
                            {
                                if (stack.Tag.Equals(image.Image.BankStabilityScore.ToString()))
                                {
                                    AddElement(stack, border);
                                }
                            }
                        }
                        else
                        {
                            foreach (StackPanel stack in bankStackBottom.Children)
                            {
                                if (stack.Tag.Equals(image.Image.BankStabilityScore.ToString()))
                                {
                                    AddElement(stack, border);
                                }
                            }
                        }
                    }
                }

                foreach (KeyValuePair<Keyword, List<ImageDataModel>> elem in FeaturePage.biasDict)
                {
                    if (BankStabilityModel.GetKeywords().Contains(elem.Key))
                    {
                        foreach (ImageDataModel image in elem.Value)
                        {
                            Border border = new Border()
                            {
                                Width = 50,
                                Height = 50,
                                BorderBrush = new SolidColorBrush(Colors.Black),
                                BorderThickness = new Thickness(4),
                                Margin = new Thickness(0, 2.5, 0, 2.5)
                            };

                            Image icon = new Image()
                            {
                                Height = 45,
                                Width = 45,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Source = GetFeatureIcon(elem.Key)
                            };

                            border.Child = icon;

                            resultEntry += "<rating areaName=\"" + image.Image.Location + "\" keyword=\"" + elem.Key.FriendlyName + "\" score=\"" + image.Image.BankStabilityScore + "\" bias=\"true\" />\n";

                            if (image.Image.BankStabilityScore % 2 == 0)
                            {
                                foreach (StackPanel stack in bankStackTop.Children)
                                {
                                    if (stack.Tag.Equals(image.Image.BankStabilityScore.ToString()))
                                    {
                                        AddElement(stack, border);
                                    }
                                }
                            }
                            else
                            {
                                foreach (StackPanel stack in bankStackBottom.Children)
                                {
                                    if (stack.Tag.Equals(image.Image.BankStabilityScore.ToString()))
                                    {
                                        AddElement(stack, border);
                                    }
                                }
                            }
                        }
                    }
                }

                bankLoaded = true;
            }

            layoutPivot.SelectedIndex = 4;
        }

        private void EpifaunalSubstrate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            protocolTitle.Text = "EPIFAUNAL SUBSTRATE";
            SelectedModel = FeatureEvalPage.EpifaunalSubstrateModel;

            if (!epifaunalLoaded)
            {
                foreach (KeyValuePair<Keyword, FeatureDataModel> elem in FeatureEvalPage.epifaunalSubstrateFeatures)
                {
                    foreach (ImageDataModel image in elem.Value.ImageList)
                    {
                        Border border = new Border()
                        {
                            Width = 50,
                            Height = 50,
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(4),
                            Margin = new Thickness(0, 2.5, 0, 2.5)
                        };

                        Image icon = new Image()
                        {
                            Height = 45,
                            Width = 45,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Source = GetFeatureIcon(elem.Key)
                        };

                        border.Child = icon;

                        resultEntry += "<rating areaName=\"" + image.Image.Location + "\" keyword=\"" + elem.Key.FriendlyName + "\" score=\"" + image.Image.EpifaunalSubstrateScore + "\" bias=\"false\" />\n";

                        if (image.Image.EpifaunalSubstrateScore % 2 == 0)
                        {
                            foreach (StackPanel stack in epifaunalStackTop.Children)
                            {
                                if (stack.Tag.Equals(image.Image.EpifaunalSubstrateScore.ToString()))
                                {
                                    AddElement(stack, border);
                                }
                            }
                        }
                        else
                        {
                            foreach (StackPanel stack in epifaunalStackBottom.Children)
                            {
                                if (stack.Tag.Equals(image.Image.EpifaunalSubstrateScore.ToString()))
                                {
                                    AddElement(stack, border);
                                }
                            }
                        }
                    }
                }

                foreach (KeyValuePair<Keyword, List<ImageDataModel>> elem in FeaturePage.biasDict)
                {
                    if (EpifaunalSubstrateModel.GetKeywords().Contains(elem.Key))
                    {
                        foreach (ImageDataModel image in elem.Value)
                        {
                            Border border = new Border()
                            {
                                Width = 50,
                                Height = 50,
                                BorderBrush = new SolidColorBrush(Colors.Black),
                                BorderThickness = new Thickness(4),
                                Margin = new Thickness(0, 2.5, 0, 2.5)
                            };

                            Image icon = new Image()
                            {
                                Height = 45,
                                Width = 45,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Source = GetFeatureIcon(elem.Key)
                            };

                            border.Child = icon;

                            resultEntry += "<rating areaName=\"" + image.Image.Location + "\" keyword=\"" + elem.Key.FriendlyName + "\" score=\"" + image.Image.EpifaunalSubstrateScore + "\" bias=\"true\" />\n";

                            if (image.Image.EpifaunalSubstrateScore % 2 == 0)
                            {
                                foreach (StackPanel stack in epifaunalStackTop.Children)
                                {
                                    if (stack.Tag.Equals(image.Image.EpifaunalSubstrateScore.ToString()))
                                    {
                                        AddElement(stack, border);
                                    }
                                }
                            }
                            else
                            {
                                foreach (StackPanel stack in epifaunalStackBottom.Children)
                                {
                                    if (stack.Tag.Equals(image.Image.EpifaunalSubstrateScore.ToString()))
                                    {
                                        AddElement(stack, border);
                                    }
                                }
                            }
                        }
                    }
                }

                epifaunalLoaded = true;
            }

            layoutPivot.SelectedIndex = 2;
        }

        private void AddElement(StackPanel stack, Border border)
        {
            if (stack.Children.Count < 4)
            {
                stack.Children.Add(border);
            }
            else
            {
                if (stack.Children.Count != 5)
                {
                    TextBlock text = new TextBlock()
                    {
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    border.Child = text;
                    stack.Children.Add(border);
                }

                TextBlock textBlock = ((stack.Children[4] as Border).Child as TextBlock);

                if (textBlock.Text.Equals(""))
                {
                    textBlock.Text = "+1";
                }
                else
                {
                    textBlock.Text = "+" + (Convert.ToInt32(textBlock.Text.Substring(1)) + 1);
                }
            }
        }

        private void LayoutPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = layoutPivot.SelectedIndex;

            if (index == 0 || index == 3 || index == 5 || index == 6)
            {
                navBar.Visibility = Visibility.Collapsed;
                protocolBlock.Visibility = Visibility.Collapsed;
            }
            else if (index == 1)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Collapsed;
            }
            else if (index >= 2 && index < 6)
            {         
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Visible;
            }
            else
            {
                navBar.Visibility = Visibility.Collapsed;
                protocolBlock.Visibility = Visibility.Collapsed;
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
            if (SelectedModel is BankStabilityModel && layoutPivot.SelectedIndex > 4)
            {
                layoutPivot.SelectedIndex = 4;
            }
            else if (SelectedModel is EpifaunalSubstrateModel && layoutPivot.SelectedIndex > 2)
            {
                layoutPivot.SelectedIndex = 2;
            }
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            using (Stream stream = await(await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/FeatureIcons.xml"))).OpenStreamForReadAsync())
            {
                icons = XDocument.Load(stream).Root;
            }
            ++layoutPivot.SelectedIndex;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int expertScore = 0;
            if (SelectedModel is BankStabilityModel)
            {
                layoutPivot.SelectedIndex = 5;

                bankRun.Text = Convert.ToInt32(bankSlider.Value).ToString();
                BankStabilityModel.Score = bankSlider.Value;
                progressBar.Value++;

                if (LandingPage.StreamNameCode == 'P')
                {
                    expertScore = 9;
                }
                else if (LandingPage.StreamNameCode == 'M')
                {
                    expertScore = 5;
                }

                bankExpert.Text = expertScore.ToString();

                if (expertScore > 0)
                {
                    double index = bankSlider.Value / expertScore;

                    if (index == 1)
                    {
                        bankFeedback.Text = "Great job, you scored exactly like the expert!";
                    }
                    else if (index < 1 && index >= 0.85)
                    {
                        bankFeedback.Text = "Great job, you scored close to the expert!";
                    }
                    else if (index < 0.85 && index >= 0.75)
                    {
                        bankFeedback.Text = "Good job, you kind of scored close to the expert!";
                    }
                    else
                    {
                        bankFeedback.Text = "Good attempt, try again next time!";
                    }
                }
            }
            else if (SelectedModel is EpifaunalSubstrateModel)
            {
                layoutPivot.SelectedIndex = 3;

                epifaunalRun.Text = Convert.ToInt32(epifaunalSlider.Value).ToString();
                EpifaunalSubstrateModel.Score = epifaunalSlider.Value;
                progressBar.Value++;

                if (LandingPage.StreamNameCode == 'P')
                {
                    expertScore = 16;
                }
                else if (LandingPage.StreamNameCode == 'M')
                {
                    expertScore = 9;
                }

                epifaunalExpert.Text = expertScore.ToString();

                if (expertScore > 0)
                {
                    double index = epifaunalSlider.Value / expertScore;

                    if (index == 1)
                    {
                        epifaunalFeedback.Text = "Great job, you scored exactly like the expert!";
                    }
                    else if (index < 1 && index >= 0.85)
                    {
                        epifaunalFeedback.Text = "Great job, you scored close to the expert!";
                    }
                    else if (index < 0.85 && index >= 0.75)
                    {
                        epifaunalFeedback.Text = "Good job, you kind of scored close to the expert!";
                    }
                    else
                    {
                        epifaunalFeedback.Text = "Good attempt, try again next time!";
                    }
                }
            }
        }

        private void EpifaunalSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (e.NewValue == 0)
            {
                epifaunalSubmitButton.IsEnabled = false;
            }
            else
            {
                epifaunalSubmitButton.IsEnabled = true;
            }

            foreach (TextBlock block in epifaunalValueStack.Children)
            {
                if (block.Text.Equals(epifaunalSlider.Value.ToString()))
                {
                    block.Opacity = 1;
                }
                else
                {
                    if (!block.Text.Equals("20") && !block.Text.Equals("15") && !block.Text.Equals("10") && !block.Text.Equals("5") && !block.Text.Equals("0"))
                    {
                        if (block.Opacity == 1)
                        {
                            block.Opacity = 0;
                        }
                    }
                }
            }
        }

        private void NextProtocolButton_Click(object sender, RoutedEventArgs e)
        {
            if (progressBar.Value != 2)
            {
                if (SelectedModel is BankStabilityModel)
                {
                    EpifaunalSubstrate_Tapped(null, null);
                }
                else if (SelectedModel is EpifaunalSubstrateModel)
                {
                    BankStability_Tapped(null, null);
                }
            }
            else
            {
                WriteResults();
                layoutPivot.SelectedIndex = 6;
            }
        }

        private void BankSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (e.NewValue == 0)
            {
                bankSubmitButton.IsEnabled = false;
            }
            else
            {
                bankSubmitButton.IsEnabled = true;
            }

            foreach (TextBlock block in bankValueStack.Children)
            {
                if (block.Text.Equals(bankSlider.Value.ToString()))
                {
                    block.Opacity = 1;
                }
                else
                {
                    if (!block.Text.Equals("10") && !block.Text.Equals("6") && !block.Text.Equals("4") && !block.Text.Equals("0"))
                    {
                        if (block.Opacity == 1)
                        {
                            block.Opacity = 0;
                        }
                    }
                }
            }
        }

        private void GlanceCloseButton_Click(object sender, RoutedEventArgs e)
        {
            glanceProtocol.Visibility = Visibility.Collapsed;
        }

        private void GlanceOpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModel is BankStabilityModel)
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/ProtocolAssets/Bank.png"));
            }
            else if (SelectedModel is EpifaunalSubstrateModel)
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/ProtocolAssets/Epifaunal.png"));
            }

            glanceProtocol.Visibility = Visibility.Visible;
        }

        private void LegendButton_Click(object sender, RoutedEventArgs e)
        {
            glanceLegend.Visibility = Visibility.Visible;
        }

        private void LegendCloseButton_Click(object sender, RoutedEventArgs e)
        {
            glanceLegend.Visibility = Visibility.Collapsed;
        }

        private BitmapImage GetFeatureIcon(Keyword keyword)
        {
            return new BitmapImage(new Uri(icons.Elements().Where(i => i.Attribute("name").Value.Equals(keyword.FriendlyName)).First().Attribute("src").Value));
        }

        private async void WriteResults()
        {
            resultEntry += "</ratings>\n\n"
                + "<protocol type=\"EpifaunalSubstrateModel\" score=\"" + EpifaunalSubstrateModel.Score + "\" />\n"
                + "<protocol type=\"BankStabilityModel\" score=\"" + BankStabilityModel.Score + "\" />\n"
                + "</participant>\n\n";

            StorageFile data = await ApplicationData.Current.LocalFolder.GetFileAsync("Results.xml");

            await FileIO.AppendTextAsync(data, resultEntry);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private async void ExtractButton_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker p = new FileSavePicker();
            p.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            p.FileTypeChoices.Add("XML", new List<string>() { ".xml" });
            p.SuggestedFileName = "Results";

            StorageFile file = await p.PickSaveFileAsync();

            if (file != null)
            {
                CachedFileManager.DeferUpdates(file);

                StorageFile data = await ApplicationData.Current.LocalFolder.GetFileAsync("Results.xml");

                string xml = await FileIO.ReadTextAsync(data) + "\n</root>";

                try
                {
                    XDocument doc = XDocument.Parse(xml);
                    xml = doc.ToString();
                }
                catch (Exception)
                {

                }

                await FileIO.WriteTextAsync(file, xml);
            }
        }
    }
}
