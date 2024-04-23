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
}