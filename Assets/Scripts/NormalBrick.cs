using UnityEngine;

public class NormalBrick : MonoBehaviour
{
    private int hitCount = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }

        hitCount++;

        //All blocks have the chance to spawn a powerup, then if the ball came into contact with the brick then destroy
        if(hitCount >= 1)
        {
            GetComponent<PowerUpSpawner>()?.DropPowerUp();
            
            GameManager.Instance.AddScore(100);

            BrickSpawner.remainingBricks--;

            if(BrickSpawner.remainingBricks <= 0)
            {
                GameManager.Instance.GameWon();
            }

            Destroy(this.gameObject);
        }
    }
}
