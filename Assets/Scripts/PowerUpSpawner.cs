using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Power Up Settings")]
    [Range(0f, 1f)]
    public float dropChance = 0.2f; //This is a 20% chance of a brick dropping a power-up

    public GameObject[] powerUpPrefabs; //Assign the collectables/powerups

    public void DropPowerUp()
    {
        if(Random.value <= dropChance)
        {
            int idx = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[idx], transform.position, Quaternion.identity);
        }
    }
}
