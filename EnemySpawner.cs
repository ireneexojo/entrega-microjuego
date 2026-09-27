using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xBorderLimit, yBorderLimit;
    public GameObject pooling;

    private float spawnNext = 0f;

    private void Update()
    {
        if (Time.time >= spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;

            var rand = Random.Range(-xBorderLimit, xBorderLimit);
            var spawnPosition = new Vector2(rand, yBorderLimit);
            GameObject asteroid = pooling.GetComponent<Pooling>().GetAsteroid();
            if(asteroid != null)
            {
                asteroid.transform.position = spawnPosition;
                asteroid.transform.rotation = Quaternion.identity;
            }
            else
            {
                Debug.Log("No hay suficientes asteroides");
            }
        }
    }
}