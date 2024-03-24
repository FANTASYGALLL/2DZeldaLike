using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework ; 

namespace ZeldaGame2D{

    public class KeyCountCommand : AbstractCommand
    {
        private int keystate;
        public KeyCountCommand(int state)
        {
            keystate = state;
        }
        protected override void OnExecute()
        {
            var playermodel = this.GetModel<IPlayerModel>();
            if(keystate ==1 ){
                playermodel.KeyCount.Value ++;}
            else if(keystate == 0 & playermodel.KeyCount.Value !=0)
            {
                playermodel.KeyCount.Value --;
                this.SendEvent<OpenDoorEvent>();
            }

            UnityEngine.Debug.Log("钥匙数量为" + playermodel.KeyCount.Value);
                
        }
    }

}