using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float maxLifetime = 3f;
    public Vector3 targetVector;

    public GameObject tinyAsteroidPrefab;

    public float lifeTime;

    public float angulo = 60f;

    private void OnEnable()
    {
        lifeTime = 0f;
    }

    private void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if(lifeTime > maxLifetime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
        
    }

    public void IncreaseScore()
    {
        Player.SCORE++;
        if(Player.SCORE > Player.RECORD)
        {
            Player.RECORD = Player.SCORE;
            PlayerPrefs.SetInt("Record", Player.RECORD);
            PlayerPrefs.Save();
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();
            // Destroy(gameObject);
            gameObject.SetActive(false);
            Dividir(collision.transform.position);
            // Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("TinyEnemy"))
        {
            IncreaseScore();
            // Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void Dividir(Vector3 position)
    {
        Vector3 bulletDir = targetVector.normalized;
        // Vector3 perpendicular = new Vector3(bulletDir.y, -bulletDir.x, 0);
        Vector3 dir1 = Quaternion.Euler(0, 0, angulo) * bulletDir;
        Vector3 dir2 = Quaternion.Euler(0, 0, -angulo) * bulletDir;
        Pooling pooling = FindAnyObjectByType<Pooling>();
        GameObject t1 = pooling.GetComponent<Pooling>().GetTinyAsteroid();
        GameObject t2 = pooling.GetComponent<Pooling>().GetTinyAsteroid();
        if(t1 != null && t2 != null)
        {
            t1.transform.position = position;
            t1.transform.rotation = Quaternion.identity;
            t1.GetComponent<Rigidbody>().linearVelocity = dir1 * 5f;

            t2.transform.position = position;
            t2.transform.rotation = Quaternion.identity;
            t2.GetComponent<Rigidbody>().linearVelocity = dir2 * 5f;
        }

        // t1.GetComponent<Rigidbody>().linearVelocity = perpendicular * 3f;
        // t2.GetComponent<Rigidbody>().linearVelocity = -perpendicular * 3f;
        // t1.GetComponent<Rigidbody>().linearVelocity = dir1 * 3f;
        // t2.GetComponent<Rigidbody>().linearVelocity = dir2 * 3f;

    }
}   