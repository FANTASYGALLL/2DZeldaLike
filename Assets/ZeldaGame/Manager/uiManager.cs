using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.UI;

namespace ZeldaGame2D{

        public enum GameState
    {
        Playing,
        pause
    }
    public class uiManager : ZeldaGameController
    {
        public static uiManager instance;
        public GameObject UI;

        private IPlayerModel mplayermodel;

        
        public GameState gameState;
        

         private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

      //  UI.Instantiate();
    }
        // Start is called before the first frame update
        void Start()
        {
            gameState = GameState.Playing;
            mplayermodel = this.GetModel<IPlayerModel>();
           /* UI.transform.Find("Canvas/PauseBlackButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                UI.transform.Find("Canvas/PauseUI").gameObject.SetActive(true);
                Time.timeScale = 0;
            });

            UI.transform.Find("Canvas/PauseUI/PauseUIWindow/SmallBlackPlayButton").GetComponent<Button>()
            .onClick.AddListener(() => 
            {
                Time.timeScale = 1;
                UI.transform.Find("Canvas/PauseUI").gameObject.SetActive(false);
            }); */




        }

        // Update is called once per frame
        void Update()
        {
          /*  if(Input.GetKeyDown(KeyCode.Escape))
            {
                
                Time.timeScale = 0;
                gameState = GameState.pause;
            } */
        }

        public void Pause()
        {
             Time.timeScale = 0;
                gameState = GameState.pause;
        }

        public void Restart()
        {
             Time.timeScale = 1;
                gameState = GameState.Playing;
        }

    }

}