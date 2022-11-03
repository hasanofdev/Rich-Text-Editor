
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Text_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[] Sizes { get; set; } = new int[] { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
        bool isBold { get; set; } = false;


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
                    MainTxt.FontFamily = new FontFamily("Arial");
                else
                    MainTxt.FontFamily = new FontFamily("Arial Bold");
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
                    MainTxt.FontStyle = FontStyles.Normal;
                else
                    MainTxt.FontStyle = FontStyles.Italic;
            }
        }

        private void ButtonUnderline_Click(object sender, RoutedEventArgs e)
        {

           if (!MainTxt.Selection.IsEmpty && MainTxt.Selection.GetPropertyValue(Underline.TextDecorationsProperty).Equals(TextDecorations.Underline))
           {
               MainTxt.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty,TextDecorations.Baseline);
           }
           else if (!MainTxt.Selection.IsEmpty && MainTxt.Selection.GetPropertyValue(Underline.TextDecorationsProperty).Equals(TextDecorations.Underline))
           {
               MainTxt.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
           }
           else
           {
                RichTextBox rtb = new RichTextBox();

                
                MessageBox.Show("ss ");
                MainTxt.SelectAll();
           }
        }
    }
}
