using UnityEngine;

public class PlayerController : MonoBehaviour
{

   [SerializeField] private float movementSpeed = 5.0f;
   [SerializeField] private float jumpForce = 7.0f;
   private Rigidbody2D rb;
   public Animator anim;
   public bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       jump();
    }
    void FixedUpdate()
    {

       isGrounded = Physics2D.CircleCast(transform.position, 0.1f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        anim.SetBool("Grounded", isGrounded);
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocityX = moveX * movementSpeed;

         if (moveX > 0)
        transform.localScale = new Vector2(-1, 1);
    else if (moveX < 0)
        transform.localScale = new Vector2(1, 1);

        anim.SetFloat("Speed", Mathf.Abs(moveX));
    }

    private void jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("Grounded", false);
        }
    }

}
