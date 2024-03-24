using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.UI;

namespace ZeldaGame2D{

    public class BlackPlayButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => 
            {
                SoundManager.instance.LevelMusic();
            });
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}