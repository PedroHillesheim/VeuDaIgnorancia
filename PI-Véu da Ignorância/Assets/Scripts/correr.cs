using UnityEngine;

public class correr: MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    private Rigidbody2D Body;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        if (Body == null)
            Debug.LogError("Rigidbody2D não encontrado!");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        Body.linearVelocity = new Vector2(horizontal * speed, Body.linearVelocity.y);
    }
}