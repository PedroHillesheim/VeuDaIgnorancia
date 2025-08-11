using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5f; 
    public float runSpeed = 9f;
    private float horizontal;
    public float speed;

    public GameObject bullet;
    [SerializeField]private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (body == null)
        {
            Debug.LogError("Rigidbody2D não encontrado!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        body.linearVelocity = new Vector2 (horizontal * speed, body.linearVelocity.y);


    }
}
