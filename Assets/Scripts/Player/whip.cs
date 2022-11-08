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

    [SerializeField] int whipDamage = 1;
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
            }
            else
            {
                leftWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            }
        }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Enemy1"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }

    
}
