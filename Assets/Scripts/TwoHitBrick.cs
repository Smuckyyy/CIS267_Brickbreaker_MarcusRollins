using UnityEngine;

public class TwoHitBrick : MonoBehaviour
{
    private int hitCount = 0;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }

        hitCount++;

        //Make the hit count higher because these bricks will take two hits
        if(hitCount >= 2)
        {
            GetComponent<PowerUpSpawner>()?.DropPowerUp();
            
            GameManager.Instance.AddScore(200);
            
            BrickSpawner.remainingBricks--;

            if(BrickSpawner.remainingBricks <= 0)
            {
                GameManager.Instance.GameWon();
            }
            
            Destroy(this.gameObject);
        }

        
    }
}
