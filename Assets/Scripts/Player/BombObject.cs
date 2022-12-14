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
    public static float range = 25;
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
            var enemies = GameObject.FindGameObjectsWithTag("Enemy1");
            Debug.Log("Enemies found: " + enemies.Length);
            if(enemy != null){
                //Debug.Log("Enemie Collision");
                //enemy.damage(damage);
                foreach(GameObject obj in enemies){
                    //do damage in range
                    Vector3 positions = obj.transform.position;
                    //Debug.Log("Enemies Detected");
                    if(Vector3.Distance(positions, this.transform.position) < range){
                        EnemyStats obj2 = obj.transform.GetComponent<EnemyStats>();
                        if(obj2 != null){
                            obj2.damage(damage);
                            Debug.Log("Damaged: " + obj2.name + "at:" + obj2.transform.position.x);
                        }else{
                            Debug.Log("enemy is null");
                        }
                    }
                }
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
