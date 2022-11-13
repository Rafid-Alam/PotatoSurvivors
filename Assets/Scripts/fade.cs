using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    float fadeTime = 0.8f;
    float timer;
    // Start is called before the first frame update
    private void OnEnable()
    {
        timer = fadeTime;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
