using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ZeldaGame2D;

[CreateAssetMenu(fileName = "PlayerDialogueTriggerScript")]
public class PlayerDialogueTriggerScript : ScriptableObject
{
    //level4-0里的对话
    public void DialogueOver()
    {
        DialogueLua.SetVariable("CanDialogue", false);
    }

    public void RecoverBomb()
    {
        GameManager.instance.RecoverBomb();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameStart");
    }
    

}
