using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class GameStartPanel : ZeldaGameController
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.Find("BlackPlayButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
               Invoke("OnGameStart" , 0.5f);
              
            } );

            transform.Find("BlackQuitButton").GetComponent<Button>().onClick.AddListener(()=>
            {
               Invoke("OnGameQuit",0.5f);

            });
        }

        void OnGameStart()
        {
             SceneManager.LoadScene("Entrance_0");
                var model = this.GetModel<IPlayerModel>();
                //更新数据
                model.HP.Value = 3;
                model.KeyCount.Value = 0;
                model.BoobCount.Value = 3; 

        }

        void OnGameQuit()
        {
             #if UNITY_EDITOR //编辑器中退出游戏
	                UnityEditor.EditorApplication.isPlaying = false;
                #else //应用程序中退出游戏
	                UnityEngine.Application.Quit();
                #endif
        }
    }

}

