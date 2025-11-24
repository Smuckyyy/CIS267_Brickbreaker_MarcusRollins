using UnityEngine;

public class BallController : MonoBehaviour
{
    public float launchSpeed = 10f;
    public Transform Paddle;

    private Rigidbody2D rb;
    private bool isLaunched = false;
    private float screenBoundary;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Disable physics initially
        rb.simulated = false;

        //Screen boundary so the ball doesn't go off screen
        float halfBallWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        float halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        screenBoundary = halfScreenWidth - halfBallWidth;
    }

    void Update()
    {
        if (!isLaunched)
        {
            //Stick ball to paddle
            Vector3 paddlePos = Paddle.position;
            Vector3 newPos = new Vector3(paddlePos.x, paddlePos.y + 0.5f, paddlePos.z);

            //Clamp X to screen width
            newPos.x = Mathf.Clamp(newPos.x, -screenBoundary, screenBoundary);

            transform.position = newPos;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }
    }

    void LaunchBall()
    {
        isLaunched = true;

        //Re-enable physics
        rb.simulated = true;

        //Shoot
        rb.linearVelocity = Vector2.up * launchSpeed;
    }

    void FixedUpdate()
    {
        //Keep speed constant (FOR NOW)
        if (isLaunched)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * launchSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Paddle"))
    {
        //Calculate hit point
        float hitPoint = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;

        //Create new direction based on hit point
        Vector2 dir = new Vector2(hitPoint, 1).normalized;

        //Set the velocity back to the ball
        rb.linearVelocity = dir * launchSpeed;
    }
}
}