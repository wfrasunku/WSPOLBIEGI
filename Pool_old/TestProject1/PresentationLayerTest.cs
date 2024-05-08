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
        //[SetUp]
        //public void Setup()
        //{
        //}
        
        [Test]
        public void Constructor_Test()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            Assert.IsNotNull(viewModel.Balls);
        }

        [Test]
        public void AddBalls_Test()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.AddBallCommand.Execute(null);
            viewModel.AddBallCommand.Execute(null);

            Assert.AreEqual(2, viewModel.Balls.Count);
            Assert.AreNotEqual(viewModel.Balls[0], viewModel.Balls[1]);
        }

        [Test]
        public void RemoveBalls_Test()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.AddBallCommand.Execute(null);
            viewModel.AddBallCommand.Execute(null);
            //Assert.AreEqual(2, window.Balls.Count);

            viewModel.RemoveBallCommand.Execute(null);
            Assert.AreEqual(1, viewModel.Balls.Count);
        }
    }
}

