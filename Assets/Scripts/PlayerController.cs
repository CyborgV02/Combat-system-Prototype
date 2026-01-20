using UnityEngine;

public class PlayerController : MonoBehaviour
{

   [SerializeField] private float movementSpeed = 5.0f;
   [SerializeField] private float jumpForce = 7.0f;
   private Rigidbody2D rb;
   public Animator anim;
   public bool isGrounded;
   public Transform attackPoint;
   public float attackRange = 0.5f;
   public int damage = 35;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       jump();

       if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }
       
    }
    void FixedUpdate()
    {
        move();
    }

    private void jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("Grounded", false);
        }
    }

    private void move()
    {
        isGrounded = Physics2D.CircleCast(transform.position, 0.1f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        anim.SetBool("Grounded", isGrounded);
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocityX = moveX * movementSpeed;
         if (moveX > 0)
        transform.localScale = new Vector2(1, 1);
        else if (moveX < 0)
        transform.localScale = new Vector2(-1, 1);
        anim.SetFloat("Speed", Mathf.Abs(moveX));
    }

   private void Attack()
{
    anim.SetTrigger("Attack");
    Invoke(nameof(ApplyDamage), 0.05f);
}

private void ApplyDamage()
{
    Collider2D[] enemies = Physics2D.OverlapCircleAll(
        attackPoint.position,
        attackRange,
        LayerMask.GetMask("Enemy")
    );

    foreach (Collider2D enemy in enemies)
    {
        enemy.GetComponent<Enemy>().takeDamage(damage);
    }
}

     
    

}
