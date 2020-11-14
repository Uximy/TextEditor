﻿using System;
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
    }
    private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
    {
      object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
      temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);

      temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
      cmbFontFamily.SelectedItem = temp;
      temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
      cmbFontSize.Text = temp.ToString();
    }


    private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (cmbFontFamily.SelectedItem != null)
        rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
    }

    private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
    {
      rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
    }
  }
}
