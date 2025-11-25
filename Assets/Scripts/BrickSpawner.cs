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
    public float spawnChance = 1f;

    void Start()
    {
        SpawnBricks();
    }

    void SpawnBricks()
    {
        if (brickPrefabs.Length == 0) return;

        //Get width & height from first prefabs
        SpriteRenderer sr = brickPrefabs[0].GetComponent<SpriteRenderer>();
        float brickWidth = sr.bounds.size.x;
        float brickHeight = sr.bounds.size.y;

        //This spacing adds a gap between bricks
        float spacingX = brickWidth + 0.2f;
        float spacingY = brickHeight + 0.2f;

        //This loop spawns the bricks in the grid using the hierarchy of the rows and columns
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (Random.value > spawnChance) continue;

                //idx stores a random number using the range of the array
                int idx = Random.Range(0, brickPrefabs.Length);
                //selectedBrick spawns the actual brick
                GameObject selectedBrick = brickPrefabs[idx];

                Vector2 pos = new Vector2(startPos.x + c * spacingX, startPos.y - r * spacingY);

                Instantiate(selectedBrick, pos, Quaternion.identity, this.transform);
            }
        }
    }
}
