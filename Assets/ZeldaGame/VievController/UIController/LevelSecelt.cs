using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ZeldaGame2D{

public class LevelSecelt : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        transform.Find("VerticalOrangeButton").GetComponent<Button>().onClick
        .AddListener(() =>
        {
            if(GameManager.instance.UnLocked[0])
            {
                SceneManager.LoadScene("Level_0");
                SoundManager.instance.MianTheme();
                GameManager.instance.PlayRecover();
                uiManager.instance.Restart();
            }

        });
        transform.Find("VerticalRedButton").GetComponent<Button>().onClick
        .AddListener(() =>
        {
            if(GameManager.instance.UnLocked[1])
            {
                SceneManager.LoadScene("Level1");
                SoundManager.instance.MianTheme();
                 GameManager.instance.PlayRecover();
                 uiManager.instance.Restart();
            }
            else {audioSource.Play();}

        });
        transform.Find("VerticalGreenButton").GetComponent<Button>().onClick
        .AddListener(() =>
        {
            if(GameManager.instance.UnLocked[2])
            {
                SceneManager.LoadScene("Level_2");
                SoundManager.instance.MianTheme();
                GameManager.instance.PlayRecover();
                uiManager.instance.Restart();
            }
            else {audioSource.Play();}

        });
        transform.Find("VerticalBlackButton").GetComponent<Button>().onClick
        .AddListener(() =>
        {
            if(GameManager.instance.UnLocked[3])
            {
                SceneManager.LoadScene("Level_3");
                SoundManager.instance.MianTheme();
                GameManager.instance.PlayRecover();
                uiManager.instance.Restart();
            }
            else {audioSource.Play();}

        });
        transform.Find("VerticalBlueButton").GetComponent<Button>().onClick
        .AddListener(() =>
        {
            if(GameManager.instance.UnLocked[4])
            {
                SceneManager.LoadScene("Entrance_1");
                SoundManager.instance.MianTheme();
                GameManager.instance.PlayRecover();
                uiManager.instance.Restart();
            }
            else {audioSource.Play();}

        });
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

}