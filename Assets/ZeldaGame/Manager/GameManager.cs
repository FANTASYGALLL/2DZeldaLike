using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using PixelCrushers.DialogueSystem;

namespace ZeldaGame2D{



    public class GameManager : ZeldaGameController
    {
        [Header("Key&Door")]
        public static GameManager instance;
        bool [] DoorState  = new bool[100] ;
        bool [] KeyState  = new bool[100] ;

        public GameState gameState;

        public bool [] Skill  = new bool[4];

        [Header("Level")]
        public bool[] UnLocked = new bool[5];

        

        private void Awake()
        {
            if(instance == null){instance = this;}
                else
                {
                    if(instance !=this ){Destroy(gameObject);}
                }

                DontDestroyOnLoad(gameObject);
                UnLocked[0] = true;

            DialogueLua.SetVariable("CanDialogue", true);
            DialogueLua.SetVariable("BossIsDie", false);
        }

        public void saveDoorOpen(int Id)
        {
            DoorState[Id] = true;
        }
        public bool LoadDoorOpen(int Id)
        {
            return DoorState[Id];
        }
        public void saveKeyOpen(int Id)
        {
            KeyState[Id] = true;
        }
        public bool LoadKeyOpen(int Id)
        {
            return KeyState[Id] ;
        }

        public void LockLevel(int index)
        {
            UnLocked[index] = true;
        }

        public void PlayRecover()
        {
            this.GetModel<IPlayerModel>().HP.Value= 3;
            this.GetModel<IPlayerModel>().BoobCount.Value = 3 ;       
        }

        public void RecoverBomb()
        {
            this.GetModel<IPlayerModel>().BoobCount.Value = 3;
        }

        public void QuitGame()
        {
            #if UNITY_EDITOR //编辑器中退出游戏
	                UnityEditor.EditorApplication.isPlaying = false;
                #else //应用程序中退出游戏
	                UnityEngine.Application.Quit();
                #endif         
        }


        public void GetSkill(int LockSkillindex)
        {
            Skill[LockSkillindex] = true;
        }

       
    }

   



}