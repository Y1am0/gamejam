using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private Animator anim;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Horizontal Movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //Flip the player sprite based on the direction of movement
        if (moveInput > 0.01f)
        {
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
        else if (moveInput < -0.01f)
        {
            transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);
        }   

        //Jumping Logic
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
        }

        anim.SetBool("run", moveInput != 0);

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            jumpCount = 0;
        }
    }

    
}
