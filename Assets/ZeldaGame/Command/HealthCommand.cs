using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class HealthCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var model = this.GetModel<IPlayerModel>();
            if(model.HP.Value < 3)
                model.HP.Value ++;
            UnityEngine.Debug.Log("Hp = " + model.HP.Value);
        }
    }

}