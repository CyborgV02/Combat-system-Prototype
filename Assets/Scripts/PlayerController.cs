using UnityEngine;

public class PlayerController : MonoBehaviour
{

   [SerializeField] private float movementSpeed = 5.0f;
   [SerializeField] private float jumpForce = 7.0f;
   private Rigidbody2D rb;
   public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocityX = moveX * movementSpeed;

         if (moveX > 0)
        transform.localScale = new Vector2(-1, 1);
    else if (moveX < 0)
        transform.localScale = new Vector2(1, 1);

        anim.SetFloat("Speed", Mathf.Abs(moveX));
    }
}
