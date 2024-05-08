using System;
using System.Collections.ObjectModel;
using NUnit.Framework;
using DataLayer;
using TP.ConcurrentProgramming.Model;
using TP.ConcurrentProgramming.ViewModel.MVVMLight;
using TP.ConcurrentProgramming.ViewModel;
using LogicLayer;

namespace TestProject1
{
    public class MaindWindowViewModelTest
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void ConstructorTest()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            Assert.IsNotNull(viewModel.Balls);
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
            //Assert.AreEqual(2, window.Balls.Count);
            window.RemoveBallCommand.Execute(null);
            Assert.AreEqual(1, window.Balls.Count);
        }
    }
}

