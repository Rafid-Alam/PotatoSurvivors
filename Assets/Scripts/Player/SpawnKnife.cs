using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnife : MonoBehaviour
{

    [SerializeField] float timeToAttack = 1;
    [SerializeField] GameObject Knife;
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
        //
        GameObject thrownKnife = Instantiate(Knife);
        thrownKnife.transform.position = transform.position;
        thrownKnife.GetComponent<KnifeProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
    }
}
