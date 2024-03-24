using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;


    namespace ZeldaGame2D{

     public interface ICharaterModel : IModel
    {
        BindableProperty<int> HP { get ; }

        BindableProperty<int> attack {get ; }

         BindableProperty<float> speed {get ; }
    }
    

}