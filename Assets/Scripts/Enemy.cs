using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isGrounded;
    [SerializeField] private Animator enemyAnim;
    private Rigidbody2D enemyRb;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();  
        currentHealth = maxHealth; 
    }

    void Update()
    {
         enemyAnim.SetBool("Grounded", isGrounded);
         isGrounded = Physics2D.CircleCast(transform.position, 0.1f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }

  public void takeDamage(int damage)
    {
        currentHealth -= damage;

        enemyAnim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            die();
        }
    }


    private void die()
    {
        enemyAnim.SetTrigger("Death");
        enemyRb.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
        Collider2D enemyCollider = GetComponent<Collider2D>();
        enemyCollider.enabled = false;
    }
}
