using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Stats
    public float lastHorizontalVector;
    public float lastVerticalVector;
    public Animator animator;
    public Rigidbody2D rb;
    Vector2 movement;

    public KeyCode jumpKey;
    public float speed = 20f;
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x != 0 && movement.y != 0){
            lastHorizontalVector = movement.x;
            lastVerticalVector = movement.y;
        }
        if(movement.x != 0)
        {
            lastHorizontalVector = movement.x;
            lastVerticalVector = movement.y;
        }
        if (movement.y != 0)
        {
            lastHorizontalVector = movement.x;
            lastVerticalVector = movement.y;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }    
}
