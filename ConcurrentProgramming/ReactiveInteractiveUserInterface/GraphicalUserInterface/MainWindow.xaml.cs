﻿using System;
using System.Windows;
using TP.ConcurrentProgramming.PresentationViewModel;

namespace TP.ConcurrentProgramming.PresentationView
{
  /// <summary>
  /// View implementation
  /// </summary>
  public partial class MainWindow : Window, IDisposable
  {
    public MainWindow()
    {
            InitializeComponent();
    }

    public void Dispose()
    {
      if (this.DataContext is MainWindowViewModel viewModel)
        viewModel.Dispose();
    }
  }
}