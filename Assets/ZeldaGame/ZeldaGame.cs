using QFramework;

namespace ZeldaGame2D{
    public class ZeldaGame : Architecture<ZeldaGame>
    {
        protected override void Init()
        {
            this.RegisterModel<IPlayerModel>(new PlayerModel());
            this.RegisterModel<IEnemiesModel>(new EnemiesModel());
            this.RegisterSystem<ITimeSystem>(new TimeSystem());
        }
    }

}