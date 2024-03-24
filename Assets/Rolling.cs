using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ZeldaGame2D{
    public class Rolling : MonoBehaviour
    {

        private Slider slider;
        // Start is called before the first frame update
        void Start()
        {
            slider = GetComponentInChildren<Slider>();
            slider.value = SoundManager.instance.audioSource.volume;
        }



        public void UpdateVolume()
        {
            SoundManager.instance.audioSource.volume = slider.value;
        }
    }

}