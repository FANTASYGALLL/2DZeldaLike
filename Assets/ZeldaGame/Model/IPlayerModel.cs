using QFramework;

namespace ZeldaGame2D{

    public interface IPlayerModel :IModel
    {
        
        BindableProperty<int> HP { get ; }

        BindableProperty<int> attack {get ; }

         BindableProperty<float> speed {get ; }

         BindableProperty<int> BoobCount {get ; }

         BindableProperty<int> KeyCount {get; }

         BindableProperty<bool> CanHurted {get;}
    }


    public class PlayerModel : AbstractModel, IPlayerModel
    {
        public BindableProperty<int> HP {get ; }  = new BindableProperty<int>(3);

        public BindableProperty<int> attack {get ; } =new BindableProperty<int>(1);

        public    BindableProperty<float> speed {get ; } =new BindableProperty<float>(2);

        public  BindableProperty<int> BoobCount {get ; } = new BindableProperty<int>(3);

        public BindableProperty<int> KeyCount {get; } = new BindableProperty<int>(0);

        public  BindableProperty<bool> CanHurted {get;} = new BindableProperty<bool>(true);

        protected override void OnInit()
        {
            
        }
    }
}