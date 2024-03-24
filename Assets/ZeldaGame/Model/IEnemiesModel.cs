using QFramework;
using UnityEngine;

namespace ZeldaGame2D{

    public interface IEnemiesModel :  ICharaterModel
    {

    }

   

    public class EnemiesModel :  AbstractModel , IEnemiesModel 
    {
         public BindableProperty<int> HP {get ; }  = new BindableProperty<int>(3);

        public BindableProperty<int> attack {get ; } =new BindableProperty<int>(1);

        public    BindableProperty<float> speed {get ; } =new BindableProperty<float>(2);

        protected override void OnInit()
        {
            
        }
    }

}