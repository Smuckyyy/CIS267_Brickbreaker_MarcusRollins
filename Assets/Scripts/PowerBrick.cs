using UnityEngine;

public class PowerBrick : MonoBehaviour
{
    public GameObject powerUpPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;

        //Spawn the power-up at the brick's position and let it fall down
        if (powerUpPrefab != null)
        {
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }
    
        Destroy(gameObject);
    }
}
