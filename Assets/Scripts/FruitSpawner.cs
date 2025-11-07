using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public float spawnInterval = 1f;
    public float xRange = 8f;

    private float timer;

    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), transform.position.y, 0);
            Instantiate(fruitPrefab, spawnPos, Quaternion.identity);
        }
    }
}
