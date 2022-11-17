using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whip : MonoBehaviour
{
    
    [SerializeField] float timeToAttack = 4f;
    float timer;
    // Start is called before the first frame update

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMovement playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);

    [SerializeField] float damage = 50f;
    void Awake()
    {

        playerMove = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Attack();

        }
    }

    private void Attack()
    {
        Debug.Log ("Attack");
        timer = timeToAttack;

            if (playerMove.lastHorizontalVector > 0)
            {
                rightWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
                ApplyDamage(colliders);
            }
            else
            {
                leftWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
            }
        }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i =0; i < colliders.Length; i++)
        {
            EnemyStats e = colliders[i].GetComponent<EnemyStats>();
            if (e!= null)
            {
                colliders[i].GetComponent<EnemyStats>().damage(damage);
            }
        }
    }


}
