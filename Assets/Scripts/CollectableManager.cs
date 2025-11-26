using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        ExpandPaddle,
        SpeedBall,
        ExtraPoints
    }

    [Header("Type of Collectible")]
    public CollectibleType type;

    [Header("Fall Settings")]
    public float fallSpeed = 3f;

    private void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        //Get the bottom of the screen so once it passes that threshold it deletes itself
        float bottomY = Camera.main.transform.position.y - Camera.main.orthographicSize;

        if (transform.position.y < bottomY)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Only collect when the paddle is hit
        if (collision.CompareTag("Paddle"))
        {
            Collect(collision.gameObject);

            Debug.Log("Collected: " + type.ToString());
        }
    }

    private void Collect(GameObject paddleObj)
    {
        PaddleController paddle = paddleObj.GetComponent<PaddleController>();
        BallController ball = FindAnyObjectByType<BallController>();

        switch (type)
        {
            case CollectibleType.ExpandPaddle:
                ExpandPaddle(paddle);
                break;

            case CollectibleType.SpeedBall:
                SpeedUpBall(ball);
                break;

            case CollectibleType.ExtraPoints:
                GameManager.Instance.AddScore(100);
                break;
        }

        Destroy(gameObject);
    }

    private void ExpandPaddle(PaddleController paddle)
    {
        Vector3 scale = paddle.transform.localScale;

        if(scale.x <= 1f)
        {
            scale.x *= 1.5f;
            paddle.transform.localScale = scale;
        }
        
    }

    private void SpeedUpBall(BallController ball)
    {
        if (ball != null)
        {
            // If ball has speed, stack it
            ball.launchSpeed *= 1.2f;
        }
    }
}