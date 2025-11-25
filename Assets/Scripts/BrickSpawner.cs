using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [Header("Brick Prefabs")]
    public GameObject[] brickPrefabs;

    [Header("Grid Settings")]
    public int rows = 5;
    public int columns = 7;
    public Vector2 startPos = new Vector2(-6f, 4f);

    [Header("Spawn Chance")]
    [Range(0f, 1f)]
    public float spawnChance = 1f; //Change this field to change how many bricks spawn

    private int chosenLevel = 0;

    void Start()
    {
        //Choose level1 or level2
        chosenLevel = Random.Range(0, 2);
        SpawnBricks();
    }

    void SpawnBricks()
    {
        if (brickPrefabs == null || brickPrefabs.Length == 0) return;

        //Get brick size for spacing
        SpriteRenderer sr = brickPrefabs[0].GetComponent<SpriteRenderer>();
        float brickWidth = sr.bounds.size.x;
        float brickHeight = sr.bounds.size.y;

        //This puts a small gap between bricks
        float spacingX = brickWidth + 0.2f; 
        float spacingY = brickHeight + 0.2f;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (chosenLevel == 1)
                {
                    //Level 2 will be staggered bricks
                    if ((r + c) % 2 == 0)
                    {
                        continue;
                    }
                }

                //Random brick spawns
                if (Random.value > spawnChance) 
                    continue;

                //Pick a random brick prefab
                int idx = Random.Range(0, brickPrefabs.Length);
                GameObject chosen = brickPrefabs[idx];

                Vector2 pos = new Vector2(
                    startPos.x + (c * spacingX),
                    startPos.y - (r * spacingY)
                );

                Instantiate(chosen, pos, Quaternion.identity, this.transform);
            }
        }
    }
}