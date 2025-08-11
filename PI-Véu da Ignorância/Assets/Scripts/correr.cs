using UnityEngine;

public class correr : MonoBehaviour
{
    private float horizontal;
    public float runSpeed = 9f;
    public float speed;
    public GameObject bullet;
    [SerializeField] private Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Shift pressionado");
        }
        else
        {
            Debug.Log("Shift n�o pressionado");
        }

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        // Atualiza o campo speed com base no Shift
        speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;

        // Agora usa o campo speed atualizado
        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);

        Debug.Log($"Velocidade atual: {speed}");

    }
}