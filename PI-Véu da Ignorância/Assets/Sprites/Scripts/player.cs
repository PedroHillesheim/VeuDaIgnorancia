using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 7f;
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    private float horizontal;
    private float speed;
    private Rigidbody2D rb;
    private Rigidbody2D body;
    private Animator animator;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        body = GetComponent<Rigidbody2D>();
        if (body == null)
            Debug.LogError("Rigidbody2D não encontrado!");

        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("Animator não encontrado!");

        originalScale = transform.localScale;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        // Define velocidade e altura conforme o estado
        if (Input.GetKey(KeyCode.Space))
        {
            //Só existe para não quebrar o codigo
        }
        else
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            transform.localScale = originalScale;
        }

        // Movimento
        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);

        // Animação
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Direção do personagem
        if (horizontal > 0) 
        { 
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontal < 0) 
        { 
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastForInteraction();
        }
        bool isGrounded = Mathf.Abs(rb.linearVelocity.y) < 0.01f;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void RaycastForInteraction()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
