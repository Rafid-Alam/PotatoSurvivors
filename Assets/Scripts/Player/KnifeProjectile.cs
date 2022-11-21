using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    public float speed = 50f;
    Rigidbody2D rb;
    Vector3 moveDirection;
    //GameObject target = null;
    public static float damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        //damage = 50f;
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
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

    public void SetDirection(float x, float y){
        if(x!=0){
            moveDirection = new Vector3(x,y);
        }else{
            moveDirection = new Vector3(1f,y);
        }
        if(x < 0){
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}
