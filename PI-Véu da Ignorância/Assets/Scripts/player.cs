using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    public float crouchSpeed = 2f;
    public float crouchHeightMultiplier = 0.5f;

    private float horizontal;
    private float speed;

    private Rigidbody2D body;
    private Animator animator;
    private Vector3 originalScale;

    void Start()
    {
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
            speed = crouchSpeed;
            transform.localScale = new Vector3(originalScale.x, originalScale.y * crouchHeightMultiplier, originalScale.z);
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
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), transform.localScale.y, transform.localScale.z);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), transform.localScale.y, transform.localScale.z);

        // Interação
        if (Input.GetMouseButtonDown(0))
        {
            RaycastForInteraction();
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
