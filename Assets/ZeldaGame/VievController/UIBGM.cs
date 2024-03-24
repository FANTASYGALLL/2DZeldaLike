using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{
    public class UIBGM : ZeldaGameController
    {
        // Start is called before the first frame update
        void Start()
        {
            SoundManager.instance.TitleMusic();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}