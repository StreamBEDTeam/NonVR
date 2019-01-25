using StreamBED.Backend.Helper;
using StreamBED.Backend.Models;
using StreamBED.Backend.Models.ProtocolModels;
using StreamBED.Frontend.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class FinalAssessmentPage : Page
    {
        private ProtocolModel SelectedModel;

        public FinalAssessmentPage()
        {
            this.InitializeComponent();
        }

        private void BankStability_Tapped(object sender, TappedRoutedEventArgs e)
        {
            protocolTitle.Text = "BANK STABILITY";
            SelectedModel = FeatureEvalPage.BankStabilityModel;

            foreach (StackPanel stack in bankStackTop.Children)
            {
                stack.Children.Clear();
            }

            foreach (StackPanel stack in bankStackBottom.Children)
            {
                stack.Children.Clear();
            }

            foreach (KeyValuePair<Keyword, FeatureDataModel> elem in FeatureEvalPage.bankStabilityFeatures)
            {
                foreach (ImageDataModel image in elem.Value.ImageList)
                {
                    SolidColorBrush brush = AreaPage.AreaList.Where(i => i.Name.Equals(image.Image.Location)).First().ItemColorBrush;

                    Border border = new Border()
                    {
                        Width = 63,
                        Height = 63,
                        BorderBrush = brush,
                        BorderThickness = new Thickness(4),
                        Margin = new Thickness(0, 2.5, 0, 2.5)
                    };

                    Regex initial = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");

                    TextBlock t = new TextBlock()
                    {
                        Text = initial.Replace(elem.Key.Content, "$1"),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                    };

                    border.Child = t;

                    if (image.Image.BankStabilityScore % 2 == 0)
                    {
                        foreach (StackPanel stack in bankStackTop.Children)
                        {
                            if (stack.Tag.Equals(image.Image.BankStabilityScore.ToString()))
                            {
                                stack.Children.Add(border);
                            }
                        }
                    }
                    else
                    {
                        foreach (StackPanel stack in bankStackBottom.Children)
                        {
                            if (stack.Tag.Equals(image.Image.BankStabilityScore.ToString()))
                            {
                                stack.Children.Add(border);
                            }
                        }
                    }
                }
            }

            layoutPivot.SelectedIndex = 4;
        }

        private void EpifaunalSubstrate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            protocolTitle.Text = "EPIFAUNAL SUBSTRATE";
            SelectedModel = FeatureEvalPage.EpifaunalSubstrateModel;

            foreach (StackPanel stack in epifaunalStackTop.Children)
            {
                stack.Children.Clear();
            }

            foreach (StackPanel stack in epifaunalStackBottom.Children)
            {
                stack.Children.Clear();
            }

            foreach (KeyValuePair<Keyword, FeatureDataModel> elem in FeatureEvalPage.epifaunalSubstrateFeatures)
            {
                foreach (ImageDataModel image in elem.Value.ImageList)
                {
                    SolidColorBrush brush = AreaPage.AreaList.Where(i => i.Name.Equals(image.Image.Location)).First().ItemColorBrush;

                    Border border = new Border()
                    {
                        Width = 63,
                        Height = 63,
                        BorderBrush = brush,
                        BorderThickness = new Thickness(4),
                        Margin = new Thickness(0, 2.5, 0, 2.5)
                    };

                    Regex initial = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");

                    TextBlock t = new TextBlock()
                    {
                        Text = initial.Replace(elem.Key.Content, "$1"),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Foreground = new SolidColorBrush(Colors.Black),
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                    };

                    border.Child = t;

                    if (image.Image.EpifaunalSubstrateScore % 2 == 0)
                    {
                        foreach (StackPanel stack in epifaunalStackTop.Children)
                        {
                            if (stack.Tag.Equals(image.Image.EpifaunalSubstrateScore.ToString()))
                            {
                                stack.Children.Add(border);
                            }
                        }
                    }
                    else
                    {
                        foreach (StackPanel stack in epifaunalStackBottom.Children)
                        {
                            if (stack.Tag.Equals(image.Image.EpifaunalSubstrateScore.ToString()))
                            {
                                stack.Children.Add(border);
                            }
                        }
                    }
                }
            }

            layoutPivot.SelectedIndex = 2;
        }

        private void LayoutPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = layoutPivot.SelectedIndex;

            if (index == 0)
            {
                navBar.Visibility = Visibility.Collapsed;
                protocolBlock.Visibility = Visibility.Collapsed;
            }
            else if (index == 1)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Collapsed;
            }
            else if (index >= 2)
            {
                navBar.Visibility = Visibility.Visible;
                protocolBlock.Visibility = Visibility.Visible;
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

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ++layoutPivot.SelectedIndex;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModel is BankStabilityModel)
            {
                layoutPivot.SelectedIndex = 4;
            }
            else if (SelectedModel is EpifaunalSubstrateModel)
            {
                layoutPivot.SelectedIndex = 2;
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
            
        }

        private void BankSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
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
    }
}
