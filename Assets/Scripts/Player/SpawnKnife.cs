using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnife : MonoBehaviour
{

    public static float timeToAttack;
    public static int knifeLevel;
    [SerializeField] GameObject Knife;
    float timer;
    PlayerMovement playerMove;
    // Start is called before the first frame update
    void Start()
    {
        knifeLevel = 0;
        timeToAttack = 0.8f;
        playerMove = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(knifeLevel != 0){
            if(timer < timeToAttack){
                timer += Time.deltaTime;
                return;
            }

            timer = 0;
            Spawn();
        }
    }

    private void Spawn(){
        //
        GameObject thrownKnife = Instantiate(Knife);
        thrownKnife.transform.position = transform.position;
        thrownKnife.GetComponent<KnifeProjectile>().SetDirection(playerMove.lastHorizontalVector, playerMove.lastVerticalVector);
    }
}
