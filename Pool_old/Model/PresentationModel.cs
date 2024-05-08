using LogicLayer;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;

namespace TP.ConcurrentProgramming.Model
{
    internal class PresentationModel : ModelAbstractApi
    {
        private IObservable<EventPattern<BallChaneEventArgs>> eventObservable = null;
        private List<IDisposable> Balls2Dispose = new List<IDisposable>();

        public event EventHandler<BallChaneEventArgs> BallChanged;

        public PresentationModel()
        {
            eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
        }

        public override void Dispose()
        {
            foreach (ModelBall item in Balls2Dispose)
                item.Dispose();
        }

        public override IDisposable Subscribe(IObserver<DataLayer.IBall> observer)
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
                BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = (DataLayer.IBall)ballToRemove });
            }
        }
    }
}