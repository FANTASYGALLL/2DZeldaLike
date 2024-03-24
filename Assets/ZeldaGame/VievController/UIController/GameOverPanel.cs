using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class GameOverPanel : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.Find("BlackContinueButton").GetComponent<Button>()
            .onClick.AddListener(()=>
            {
                Invoke("GameReStart",0.5f);
            });

            transform.Find("BlackQuitButton").GetComponent<Button>().onClick.AddListener(()=>
            {
               Invoke("GameQuit",0.5f);

            });


        }
        

        void GameReStart()
        {
            SceneManager.LoadScene("GameStart");
        }

        void GameQuit()
        {
             #if UNITY_EDITOR //编辑器中退出游戏
	                UnityEditor.EditorApplication.isPlaying = false;
                #else //应用程序中退出游戏
	                UnityEngine.Application.Quit();
                #endif
        }
      
    }

}