using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    private GameObject player;
    public float speed = 5f;
    public bool flip;
    void Start()
    {
        player = GameObject.Find("Hero");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        player.transform.position, speed * Time.deltaTime);
        //transform.position = transform.position.MoveTowards(transform.position, player.transform.position, 5);

        Vector3 scale = transform.localScale;
        if (player.transform.position.x > transform.position.x) // makes enemy face player
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);

        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
        transform.localScale = scale;
    }
    void OnCollisionEnter2D(Collision2D col){
        // Different enemies will deal different damage
        if(col.gameObject.name == "Hero"){
            PlayerMovement.playerHealth -= 0.5f;
        }
    }

}
