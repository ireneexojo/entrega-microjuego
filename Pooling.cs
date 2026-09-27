
using UnityEngine;

public class Pooling : MonoBehaviour
{

    public GameObject[] bullets;
    public int cantidadInicial = 20;
    public GameObject bulletPrefab;

    public int cantidadInicial2 = 10;
    public GameObject[] asteroids;
    public GameObject asteroidPrefab;

    public GameObject[] tinyAsteroids;
    public GameObject tinyAsteroidPrefab;

    public void Start()
    {
        bullets = new GameObject[cantidadInicial];
        for(int i = 0; i<cantidadInicial; i++)
        {
            bullets[i] = Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }

        asteroids = new GameObject[cantidadInicial2/2];
        for(int i = 0; i<cantidadInicial2/2; i++)
        {
            asteroids[i] = Instantiate(asteroidPrefab);
            asteroids[i].SetActive(false);
        }

        tinyAsteroids = new GameObject[cantidadInicial];
        for(int i = 0; i<cantidadInicial2; i++)
        {
            tinyAsteroids[i] = Instantiate(tinyAsteroidPrefab);
            tinyAsteroids[i].SetActive(false);
        }
        
    }
    public GameObject GetBullet()
    {
        for(int i = 0; i<cantidadInicial; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].SetActive(true);
                return bullets[i];
            }
        }
        return null;
    }

    public GameObject GetAsteroid()
    {
        for(int i = 0; i<cantidadInicial2/2; i++)
        {
            if (!asteroids[i].activeInHierarchy)
            {
                asteroids[i].SetActive(true);
                return asteroids[i];
            }
        }
        return null;
    }

    public GameObject GetTinyAsteroid()
    {
        for(int i = 0; i<cantidadInicial2; i++)
        {
            if (!tinyAsteroids[i].activeInHierarchy)
            {
                tinyAsteroids[i].SetActive(true);
                return tinyAsteroids[i];
            }
        }
        return null;
        
    }
}