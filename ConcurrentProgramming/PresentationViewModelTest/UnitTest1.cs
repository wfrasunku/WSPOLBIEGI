using System;
using TP.ConcurrentProgramming.PresentationViewModel;

namespace PresentationViewModelTest;

public class UnitTest1
{
    [Test]
    public void ConstructorTest()
    {
        MainWindowViewModel window = new MainWindowViewModel();
        Assert.IsNotNull(window.Balls);
    }

    [Test]
    public void AddBallsTest()
    {
        MainWindowViewModel window = new MainWindowViewModel();
        window.AddBallCommand.Execute(null);
        window.AddBallCommand.Execute(null);
        Assert.AreEqual(2, window.Balls.Count);
    }

    [Test]
    public void RemoveBallsTest()
    {
        MainWindowViewModel window = new MainWindowViewModel();
        window.AddBallCommand.Execute(null);
        window.AddBallCommand.Execute(null);
        Assert.AreEqual(2, window.Balls.Count);
        window.RemoveBallCommand.Execute(null);
        Assert.AreEqual(1, window.Balls.Count);
    }

}