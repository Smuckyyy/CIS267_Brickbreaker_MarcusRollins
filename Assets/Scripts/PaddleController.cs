using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 12f;

    private Rigidbody2D rb;
    private float horizontalLimit;
    private float moveX; //Horizontal input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float halfCameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float halfPaddleWidth = GetComponent<SpriteRenderer>().bounds.extents.x;

        horizontalLimit = halfCameraWidth - halfPaddleWidth;
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * moveSpeed, 0f);

        float clampedX = Mathf.Clamp(transform.position.x, -horizontalLimit, horizontalLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}