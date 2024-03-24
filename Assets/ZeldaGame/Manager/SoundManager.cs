using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZeldaGame2D{

public enum SoundSate 
{
    Play,
    Mote
}

public class SoundManager : MonoBehaviour
{
  
    public SoundSate soundSate;
    public static SoundManager instance;
    public AudioSource audioSource;

    [Header("BGM")]
    public AudioClip LevelSelcet , Title, Hyrule , zelda;

    private bool isMainTheme = false;

    [Header("音效")]


    string Path;
   
    private void Awake()
    {
         if(instance == null){instance = this;}
            else
            {
                if(instance !=this ){Destroy(gameObject);}
            }

            DontDestroyOnLoad(gameObject);  
    }

    public void PlaySound(AudioClip playing)
    {
        if(soundSate == SoundSate.Play)
        audioSource.clip = playing;
        audioSource.Play();
    }

    private void Start()
    {
        soundSate = SoundSate.Play;
        PlaySound(Title);
        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(soundSate == SoundSate.Mote)
        {
            
        }
        Path=  SceneManager.GetActiveScene().name;
            if(Path != "GameStart")
            {
                
            }
    }

    

    

    public void TitleMusic()
    {
        
       instance.audioSource.clip = Title;
        instance.audioSource.Play();
    }
       public void LevelMusic()
    {
        instance.audioSource.clip = LevelSelcet;
        instance.audioSource.Play();
    }

    public void MianTheme()
    {
        instance.audioSource.clip = Hyrule;
        instance.audioSource.Play();
    }

    public void Zelda()
    {
        instance.audioSource.clip = zelda;
        instance.audioSource.Play();
    }

     
        /// <summary>
        /// OnGUI is called for rendering and handling GUI events.
        /// This function can be called multiple times per frame (one call per event).
        /// </summary>
        private void OnGUI()
        {
                
        }
            
    }
    
    
}


