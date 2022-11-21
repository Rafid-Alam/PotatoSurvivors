using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{
    
    //public float speed = 100f;
    Rigidbody2D rb;
    //Vector3 moveDirection;
    //GameObject target = null;
    public static float damage = 200;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        //damage = 50f;
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.tag.Equals("Enemy1")){
            //Destroy (col.gameObject);
            //col.GetComponent<EnemyStats>.damage(damage);
            EnemyStats enemy = col.transform.GetComponent<EnemyStats>();
            if(enemy != null){
                enemy.damage(damage);
                //if(!piercing)
                Destroy(this.gameObject);
            }else{
                //Destroy (col.gameObject);
            }
        }
    }

    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}
