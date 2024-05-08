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

    public class LogicLayerTest
    {

        [Test]
        public void Constructor_Test()
        {
            double expectedTop = 100;
            double expectedLeft = 200;

            var ball = new LogicLayer.ModelBall(expectedTop, expectedLeft);
            ball.Dispose();

            Assert.AreEqual(expectedTop, ball.Top);
            Assert.AreEqual(expectedLeft, ball.Left);
        }

        [Test]
        public void Move_auto_Test()
        {
            var ball = new LogicLayer.ModelBall(100, 200);
            double initialTop = ball.Top;
            double initialLeft = ball.Left;

            Thread.Sleep(100); // Czekamy przez krótki czas, aby dać kuli czas na ruch

            Assert.AreNotEqual(initialTop, ball.Top);
            Assert.AreNotEqual(initialLeft, ball.Left);
        }

        [Test]
        public void Move_manual_Test()
        {
            var ball = new LogicLayer.ModelBall(100, 200);
            double initialTop = ball.Top;
            double initialLeft = ball.Left;
            ball.Dispose();
            ball.Move(null);

            Assert.AreNotEqual(initialTop, ball.Top);
            Assert.AreNotEqual(initialLeft, ball.Left);
        }

    }
}
