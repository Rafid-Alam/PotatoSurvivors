using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    public float speed = 100f;
    Rigidbody2D rb;
    Vector3 moveDirection;
    //GameObject target = null;
    public static float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 50f;
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.tag.Equals("Enemy1")){
            EnemyStats enemy = col.transform.GetComponent<EnemyStats>();
            if(enemy != null){
                enemy.damage(damage);
                Destroy(this.gameObject);
            }
        }
    }

    public void SetDirection(float x, float y){
        if(x!=0 || y!=0){
            moveDirection = new Vector3(x,y);
        }else{
            moveDirection = new Vector3(1f,y);
        }
        if(x < 0){
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            if(y != 0){
                Vector3 newRotation = new Vector3(0,0,-45*y);
                transform.eulerAngles = newRotation;
            }
        }
        else if(x > 0 && y!= 0){
            Vector3 newRotation = new Vector3(0,0,45*y);
                transform.eulerAngles = newRotation;
        }
        else if(y != 0){
            Vector3 newRotation = new Vector3(0,0,90*y);
            transform.eulerAngles = newRotation;
        }
    }

    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}
