using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutoProjectile : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float fireRate;
    public float nextFire = 0f;
    //public static int projectiles; add to shoot multiple projectiles

    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFire){
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
