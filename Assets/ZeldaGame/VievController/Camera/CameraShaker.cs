using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class CameraShaker : ZeldaGameController
    {
        public IEnumerator CameraShakeCo(float _maxTime, float _amount)
        {
            Vector3 originalPos = transform.localPosition;
            float shakeTime = 0.0f;

            while (shakeTime < _maxTime)
            {
                float x = Random.Range(-1f, 1f) * _amount;
                float y = Random.Range(-1f, 1f) * _amount;

                transform.localPosition = new Vector3(x, y, originalPos.z);
                shakeTime += Time.deltaTime;

                yield return new WaitForSeconds(0f);
            }
        }
    }

}