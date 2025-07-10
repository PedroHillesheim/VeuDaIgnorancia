using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed;
    public GameObject bullet;
    [SerializeField]private Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        body.linearVelocity = new Vector2(horizontal, vertical) * speed;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

    }
}
