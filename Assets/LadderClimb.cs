using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 5f;
    private Rigidbody2D rb;
    private bool isClimbing = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClimbing)
        {
            float climbInput = Input.GetAxisRaw("Vertical");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, climbInput * climbSpeed);
            rb.gravityScale = 0; 
        }
        else
        {
            rb.gravityScale = 1; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }
}
