using System;
using System.Windows;
using TP.ConcurrentProgramming.ViewModel;

namespace TP.ConcurrentProgramming.View
{
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