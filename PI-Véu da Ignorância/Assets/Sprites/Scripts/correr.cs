using UnityEngine;

public class correr : MonoBehaviour
{
    private float horizontal;
    public float runSpeed = 9f;
    public float speed;
    public GameObject bullet;
    [SerializeField] private Rigidbody2D body;
   
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Shift pressionado");
        }
      
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);

        Debug.Log($"Velocidade atual: {speed}");

    }
}