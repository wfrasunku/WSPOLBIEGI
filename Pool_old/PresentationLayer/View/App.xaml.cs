using System;
using System.Windows;

namespace TP.ConcurrentProgramming.View
{
  public partial class App : Application
  {
    protected override void OnDeactivated(EventArgs e)
    {
      if (this.MainWindow is MainWindow window)
        window.Dispose();
      base.OnDeactivated(e);
    }
  }
}