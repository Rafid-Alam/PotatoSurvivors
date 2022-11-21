using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{

    [SerializeField] float timeToAttack = 4;
    [SerializeField] GameObject Bomb;
    float timer;
    PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < timeToAttack){
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        Spawn();
    }

    private void Spawn(){
        GameObject placedBomb = Instantiate(Bomb);
        placedBomb.transform.position = transform.position;
    }
}
