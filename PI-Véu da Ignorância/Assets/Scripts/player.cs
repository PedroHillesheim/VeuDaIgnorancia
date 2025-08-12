using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5f; 
    public float runSpeed = 9f;
    public float crouchSpeed = 2f;
    private float horizontal;
    public float speed;
    public float interactionMessage;


    public GameObject bullet;
    [SerializeField]private Rigidbody2D body;

    private Vector3 originalScale;
    public float crouchHeightMultiplier = 0.5f;
    public class Interactable : MonoBehaviour
    {
        public string interactionMessage = "Você interagiu com o objeto!";

        public virtual void Interact()
        {
            Debug.Log(interactionMessage);
            // Aqui você pode colocar a lógica: abrir porta, pegar item, ativar algo, etc.
        }
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (body == null)
        {
            Debug.LogError("Rigidbody2D não encontrado!");
        }
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        body.linearVelocity = new Vector2 (horizontal * speed, body.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            speed = crouchSpeed;
            transform.localScale = new Vector3(originalScale.x, originalScale.y * crouchHeightMultiplier, originalScale.z);
        }
        else
        {
            // Corre ou anda normalmente
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            transform.localScale = originalScale;
        }

        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);
        if (Input.GetMouseButtonDown(0)) // 0 = botão esquerdo
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




