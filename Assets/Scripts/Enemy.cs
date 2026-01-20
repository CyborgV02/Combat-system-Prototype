using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private Animator enemyAnim;
    private Rigidbody2D enemyRb;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();   
    }

    void Update()
    {
         enemyAnim.SetBool("Grounded", isGrounded);
         isGrounded = Physics2D.CircleCast(transform.position, 0.1f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }
}
