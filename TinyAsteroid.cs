using UnityEngine;
public class TinyAsteroid : MonoBehaviour
{
    public GameObject tinyAsteroidPrefab;

    public float maxLifetime = 3f;
    private float lifeTime;

    private void OnEnable()
    {
        lifeTime = 0f;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime > maxLifetime)
        {
            gameObject.SetActive(false);
        }
    }

}