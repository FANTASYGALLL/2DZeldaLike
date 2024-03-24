using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ZeldaGame2D{



    public class PauseController : ZeldaGameController
    {
        // Start is called before the first frame update
        void Start()
        {
           

            transform.Find("PauseUIWindow/SmallBlackPlayButton").gameObject.GetComponent<Button>().
            onClick.AddListener(()=>
            {
                if(uiManager.instance.gameState == GameState.pause)
                {
                    Time.timeScale = 1;
                    gameObject.SetActive(false);
                    uiManager.instance.gameState = GameState.Playing;
                } 

            });
            transform.Find("PauseUIWindow/SmallBlackHomeButton").gameObject.GetComponent<Button>().onClick.AddListener(()=>
            {
               SceneManager.LoadScene("GameStart");
            });
           
            transform.Find("PauseUIWindow/SmallBlackSoundButton").gameObject.GetComponent<Button>().
            onClick.AddListener(() =>{
                if(SoundManager.instance.soundSate ==SoundSate.Play)
                {
                    AudioListener.pause = false;
                    SoundManager.instance.soundSate =SoundSate.Mote;
                } else if(SoundManager.instance.soundSate ==SoundSate.Mote)
                {
                    AudioListener.pause = true;
                    SoundManager.instance.soundSate =SoundSate.Play;
                }

            });
        }

        // Update is called once per frame
        void Update()
        {
            if(uiManager.instance.gameState == GameState.pause)
                gameObject.SetActive(true);
        }


    }

}