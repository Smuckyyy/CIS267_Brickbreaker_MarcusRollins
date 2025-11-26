using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.LoseLife();

            //Reset ball position
            collision.GetComponent<BallController>().ResetBall();
            //collision.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
}
