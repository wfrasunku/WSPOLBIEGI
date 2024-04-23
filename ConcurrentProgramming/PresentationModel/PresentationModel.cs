using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using static System.Net.Mime.MediaTypeNames;
using TP.ConcurrentProgramming.PresentationModel;

namespace TP.ConcurrentProgramming.PresentationModel
{
    internal class PresentationModel : ModelAbstractApi
    {
        public PresentationModel()
        {
            eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
        }

        #region ModelAbstractApi

        public override void Dispose()
        {
            foreach (ModelBall item in Balls2Dispose)
                item.Dispose();
        }

        public override IDisposable Subscribe(IObserver<IBall> observer)
        {
            return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
        }

        public override void Start(int ballNumber)
        {
            Random random = new Random();
            int currentNumber = Balls2Dispose.Count;
            for (int i = 0; i < currentNumber; i++)
            {
                RemoveBall();
            }
            for (int i = 0; i < ballNumber; i++)
            {
                ModelBall newBall = new ModelBall(random.Next(100, 400 - 100), random.Next(100, 800 - 100)) { Diameter = 20 };
                Balls2Dispose.Add(newBall);
                BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = newBall });
            }
        }

        public override void AddBall()
        {
            Random random = new Random();
            ModelBall newBall = new ModelBall(random.Next(100, 400 - 100), random.Next(100, 800 - 100)) { Diameter = 20 };
            Balls2Dispose.Add(newBall);
            BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = newBall });
        }

        public override void RemoveBall()
        {
            if (Balls2Dispose.Count > 0)
            {
                var ballToRemove = Balls2Dispose[Balls2Dispose.Count - 1];
                Balls2Dispose.Remove(ballToRemove);
                ballToRemove.Dispose();
                BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = (IBall)ballToRemove });
            }
        }



        #endregion ModelAbstractApi

        #region API

        public event EventHandler<BallChaneEventArgs> BallChanged;

        #endregion API

        #region private

        private IObservable<EventPattern<BallChaneEventArgs>> eventObservable = null;
        private List<IDisposable> Balls2Dispose = new List<IDisposable>();

        #endregion private
    }
}