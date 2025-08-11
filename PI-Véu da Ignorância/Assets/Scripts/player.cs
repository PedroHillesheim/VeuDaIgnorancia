using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
   
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
        

        body.linearVelocity = new Vector2 (horizontal * speed, body.linearVelocity.y);


    }
}
