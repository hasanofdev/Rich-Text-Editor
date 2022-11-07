
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Text_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string openedFile = "";
        public double[] Sizes { get; set; } = new double[] { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
        bool isUnderline { get; set; } = false;
        public MainWindow()
        {
            InitializeComponent();
            SizeCombo.ItemsSource = Sizes;
        }

        private void MenuItemNewFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Create New File");
        }

        private void MenuItemNewTextBox_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Create New TextBox");
        }

        private void ButtonBold_Click(object sender, RoutedEventArgs e)
        {
            if (!MainTxt.Selection.IsEmpty && MainTxt.Selection.GetPropertyValue(FontFamilyProperty).ToString() != "Arial Bold")
            {
                MainTxt.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, "Arial Bold");

            }
            else if (!MainTxt.Selection.IsEmpty && MainTxt.Selection.GetPropertyValue(FontFamilyProperty).ToString() == "Arial Bold")
            {
                MainTxt.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, "Arial");
            }
            else
            {
                if (MainTxt.FontFamily.ToString() == "Arial Bold")
                {
                    MainTxt.SelectAll();
                    MainTxt.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, "Arial");
                }
                else
                {

                    MainTxt.SelectAll();
                    MainTxt.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, "Arial Bold");
                }
            }

        }

        private void ButtonItalic_Click(object sender, RoutedEventArgs e)
        {

            if (!MainTxt.Selection.IsEmpty && MainTxt.Selection.GetPropertyValue(FontStyleProperty).ToString() == FontStyles.Normal.ToString())
            {
                MainTxt.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
            else if (!MainTxt.Selection.IsEmpty && MainTxt.Selection.GetPropertyValue(FontStyleProperty).ToString() == FontStyles.Italic.ToString())
            {
                MainTxt.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            }
            else
            {
                if (MainTxt.FontStyle.ToString() == FontStyles.Italic.ToString())
                {
                    MainTxt.SelectAll();
                    MainTxt.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
                }
                else
                {
                    MainTxt.SelectAll();
                    MainTxt.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
                }
            }
        }

        private void ButtonUnderline_Click(object sender, RoutedEventArgs e)
        {

            if (!MainTxt.Selection.IsEmpty && !isUnderline)
            {
                MainTxt.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                isUnderline = true;
            }
            else if (!MainTxt.Selection.IsEmpty && isUnderline)
            {
                MainTxt.Selection.ApplyPropertyValue(Underline.TextDecorationsProperty, null);
                isUnderline = false;
            }
            else
            {
                MainTxt.SelectAll();
                MainTxt.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
        }

        private void ButtonStrikeOut_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MainTxt.Selection.Start, MainTxt.Selection.End);
            var currentTextDecoration = textRange.GetPropertyValue(Inline.TextDecorationsProperty);

            TextDecorationCollection newTextDecoration;


            if (String.IsNullOrWhiteSpace(textRange.Text))
            {
                newTextDecoration = ((TextDecorationCollection)currentTextDecoration == TextDecorations.Strikethrough) ? new TextDecorationCollection() : TextDecorations.Strikethrough;
                MainTxt.SelectAll();
            }

            if (currentTextDecoration != DependencyProperty.UnsetValue)
                newTextDecoration = ((TextDecorationCollection)currentTextDecoration == TextDecorations.Strikethrough) ? new TextDecorationCollection() : TextDecorations.Strikethrough;
            else
                newTextDecoration = TextDecorations.Strikethrough;


            textRange.ApplyPropertyValue(Inline.TextDecorationsProperty, newTextDecoration);
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => MainTxt.FontSize = (double)SizeCombo.SelectedItem;

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = ".txt|*.txt";

            openFile.ShowDialog();

            if (String.IsNullOrWhiteSpace(openFile.FileName))
                return;

            openedFile = openFile.FileName;
            MainTxt.SelectAll();
            MainTxt.Selection.Text = (File.ReadAllText(openFile.FileName));
            SaveBtn.IsEnabled = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(openedFile))
            {
                MainTxt.SelectAll();
                File.WriteAllText(openedFile, MainTxt.Selection.Text);
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = ".txt | *.txt";

            saveFile.DefaultExt = "file.txt";
            saveFile.ShowDialog();
        }
    }
}
