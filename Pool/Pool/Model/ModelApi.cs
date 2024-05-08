using System.Collections.ObjectModel;
using Logic;

namespace Model
{
    public abstract class AbstractModelApi
    {
        public static AbstractModelApi API(AbstractLogicApi abstractLogicApi = null) => new ModelApi();

        public abstract void Start(int amountOfBalls);
        public abstract void AddBall();
        public abstract void RemoveBall();
        public abstract ObservableCollection<BallModel> GetBalls();


        public class ModelApi : AbstractModelApi
        {
            private ObservableCollection<BallModel> balls = new();
            private AbstractLogicApi logicApi = AbstractLogicApi.API(null);

            public ModelApi(AbstractLogicApi abstractLogicApi = null)
            {
                if (abstractLogicApi == null)
                {
                    this.logicApi = AbstractLogicApi.API();
                }
                else
                {
                    this.logicApi = abstractLogicApi;
                }
            }

            public ObservableCollection<BallModel> Balls
            {
                get { return balls; }
                set { balls = value; }
            }

            public override void Start(int amountOfBalls) => logicApi.StartUpdating(amountOfBalls);

            public override ObservableCollection<BallModel> GetBalls()
            {
                List<BallLogic> logicBalls = logicApi.GetBalls();
                Balls.Clear();
                foreach (BallLogic ball in logicBalls)
                {
                    Balls.Add(new BallModel(ball));
                }
                return Balls;
            }

            public override void AddBall() => logicApi.AddBall();

            public override void RemoveBall() => logicApi.RemoveBall();
        }
    }
}
