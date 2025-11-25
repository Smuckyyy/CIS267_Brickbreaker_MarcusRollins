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

        //If the ball came into contact with the brick then destroy
        if(hitCount >= 1)
        {
            GetComponent<PowerUpSpawner>()?.DropPowerUp();
            Destroy(this.gameObject);
        }
    }
}
