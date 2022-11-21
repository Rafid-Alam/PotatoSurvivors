using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoProjectileAim : MonoBehaviour
{
    public float speed = 15f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    GameObject target = null;
    public static float damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        damage = 50f;
        rb = GetComponent<Rigidbody2D> ();
        target = FindClosestEnemy();
        if(target != null){
            moveDirection = (target.transform.position - transform.position).normalized * speed;
            rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        }else{
            Destroy (this.gameObject);
        }

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

    //Copied from Unity Documentation for GameObject. Will find the closest enemy
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy1");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
