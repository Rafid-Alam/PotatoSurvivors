using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Stats
    public static float playerXP = 0;
    public float lastHorizontalVector;
    public float lastVerticalVector;
    public Animator animator;
    public Rigidbody2D rb;
    Vector2 movement;

    public KeyCode jumpKey;
    public float speed = 10f;
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x != 0)
        {
            lastHorizontalVector = movement.x;
        }
        if (movement.y != 0)
        {
            lastVerticalVector = movement.y;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
