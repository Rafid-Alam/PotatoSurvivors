using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{

    public static float timeToAttack;
    [SerializeField] GameObject Bomb;
    float timer;
    PlayerMovement playerMove;
    public static int bombLevel;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
        bombLevel = 0;
        timeToAttack = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(bombLevel != 0){
            if(timer < timeToAttack){
                timer += Time.deltaTime;
                return;
            }
            timer = 0;
            Spawn();
        }
        
    }

    private void Spawn(){
        GameObject placedBomb = Instantiate(Bomb);
        placedBomb.transform.position = transform.position;
    }
}
