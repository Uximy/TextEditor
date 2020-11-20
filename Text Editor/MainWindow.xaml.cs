using System;
using Microsoft.Win32;
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
using System.Threading;
using System.Globalization;

namespace Text_Editor
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      InitializeComponent();
      cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
      cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
      //Thread.CurrentThread.CurrentCulture = new CultureInfo("ru");
      //MenuOpen.Header = Strings.MenuOpen;
      //MenuSave.Header = Strings.MenuSave;
    }
    private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
    {
      object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);

      btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
      temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
      btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
      temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
      cmbFontFamily.SelectedItem = temp;
      temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
      cmbFontSize.Text = temp.ToString();
    }


    private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (cmbFontFamily.SelectedItem != null)
        rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
      rtbEditor.Focus();
    }

    private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
    {
      rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
      rtbEditor.Focus();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFile = new OpenFileDialog();
      openFile.Filter = "Rich Text Format| *.rtf";
      if (openFile.ShowDialog() == true)
      {
        FileStream filestream = new FileStream(openFile.FileName, FileMode.Open);
        TextRange textrg = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
        textrg.Load(filestream, DataFormats.Rtf);
      }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      SaveFileDialog saveFile = new SaveFileDialog();
      saveFile.Filter = "Rich Text Format| *.rtf";
      if (saveFile.ShowDialog() == true)
      {
        FileStream filestream = new FileStream(saveFile.FileName, FileMode.Create);
        TextRange textrgsave = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
        textrgsave.Save(filestream, DataFormats.Rtf);
      }
    }

    private void RusButton_Click(object sender, RoutedEventArgs e)
    {
      //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      CultureInfo newCulture = CultureInfo.CreateSpecificCulture("ru");
      Thread.CurrentThread.CurrentUICulture = newCulture;
      MenuCreate.Header = Strings.MenuCreate;
      MenuOpen.Header = Strings.MenuOpen;
      MenuSave.Header = Strings.MenuSave;
      MenuSaveAs.Header = Strings.MenuSaveAs;
      MenuOptions.Header = Strings.MenuOptions;
      MenuPrinting.Header = Strings.MenuPrinting;
      MenuExit.Header = Strings.MenuExit;


      MenuCancel.Header = Strings.MenuCancel;
      MenuTocut.Header = Strings.MenuTocut;
      MenuCopy.Header = Strings.MenuCopy;
      MenuPaste.Header = Strings.MenuPaste;
      MenuDelete.Header = Strings.MenuDelete;
      MenuSelectAll.Header = Strings.MenuSelectAll;


      MenuFonts.Header = Strings.MenuFonts;
      MenuWordWrap.Header = Strings.MenuWordWrap;


      MenuFile.Header = Strings.MenuFile;
      MenuEdit.Header = Strings.MenuEdit;
      MenuFormat.Header = Strings.MenuFormat;


      LbColumn.Content = Strings.LbColumn;
      LbRow.Content = Strings.LbRow;
    }

    private void EngButton_Click(object sender, RoutedEventArgs e)
    {
      //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      CultureInfo newCulture = CultureInfo.CreateSpecificCulture("en-US");
      Thread.CurrentThread.CurrentUICulture = newCulture;
      MenuCreate.Header = Strings.MenuCreate;
      MenuOpen.Header = Strings.MenuOpen;
      MenuSave.Header = Strings.MenuSave;
      MenuSaveAs.Header = Strings.MenuSaveAs;
      MenuOptions.Header = Strings.MenuOptions;
      MenuPrinting.Header = Strings.MenuPrinting;
      MenuExit.Header = Strings.MenuExit;


      MenuCancel.Header = Strings.MenuCancel;
      MenuTocut.Header = Strings.MenuTocut;
      MenuCopy.Header = Strings.MenuCopy;
      MenuPaste.Header = Strings.MenuPaste;
      MenuDelete.Header = Strings.MenuDelete;
      MenuSelectAll.Header = Strings.MenuSelectAll;


      MenuFonts.Header = Strings.MenuFonts;
      MenuWordWrap.Header = Strings.MenuWordWrap;

      MenuFile.Header = Strings.MenuFile;
      MenuEdit.Header = Strings.MenuEdit;
      MenuFormat.Header = Strings.MenuFormat;


      LbColumn.Content = Strings.LbColumn;
      LbRow.Content = Strings.LbRow;
    }
  }
}
