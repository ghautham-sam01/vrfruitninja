using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public float spawnInterval = 1.5f;
    public Vector2 xRange = new Vector2(-0.5f, 0.5f);
    public Vector2 yRange = new Vector2(0.5f, 1.5f);
    public float launchForce = 4f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnFruit();
            timer = 0f;
        }
    }

    void SpawnFruit()
    {
        // random position a bit in front of spawner
        Vector3 spawnPos = transform.position 
                           + new Vector3(Random.Range(xRange.x, xRange.y),
                                         Random.Range(yRange.x, yRange.y),
                                         0f);

        GameObject fruit = Instantiate(fruitPrefab, spawnPos, Quaternion.identity);

        // toss it toward player / upward
        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 dir = Vector3.up + (Vector3.back * 0.2f); // up and a bit toward player
            rb.AddForce(dir.normalized * launchForce, ForceMode.VelocityChange);
        }

        // auto-destroy after 5s
        Destroy(fruit, 5f);
    }
}
