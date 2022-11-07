using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public float currentTime = 0f;
    public float startTime = 5f;
    [SerializeField] Text timer;
    public Vector2 screenPosition = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timer.text = currentTime.ToString("0");
        Vector3 tempScreenPosition = screenPosition;
         tempScreenPosition.z = -Camera.main.transform.position.z;
         
         Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
         //worldPosition.x -= 0; //tempScreenPosition.x / Screen.width;
         //worldPosition.y += Screen.height; //(1 - tempScreenPosition.y / Screen.height);
         transform.position = worldPosition;
    }
}
