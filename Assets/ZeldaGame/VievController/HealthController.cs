using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D {

    public class HealthController : ZeldaGameController
    {
        private IPlayerModel mplayermode;

        // Start is called before the first frame update
        void Start()
        {
            mplayermode = this.GetModel<IPlayerModel>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}