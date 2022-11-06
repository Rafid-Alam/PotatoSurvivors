using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Stats
    public static float playerHealth = 10;
    public static float playerXP = 0;

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

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }


    // commented this script out for now, because I wrote a different movement script to make Animations work - Huy
    /*void Update()
    {
        if(playerHealth <= 0){
            // Game over screen
        }

        WASD_Movement();

        
    }

    private void WASD_Movement(){
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;

        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;

        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;

        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;

        }
        transform.position = pos;
    }
    */
}
