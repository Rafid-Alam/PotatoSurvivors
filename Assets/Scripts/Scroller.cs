using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public float horizontal_speed = 0.2f;
    public float vertical_speed = 0.2f;

    private Renderer re;
    void Start()
    {
        re = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2(Time.time * horizontal_speed, Time.time * vertical_speed);
        re.material.mainTextureOffset = offset; 
    }
}