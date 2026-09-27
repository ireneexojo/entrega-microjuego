using UnityEngine;


public class Player : MonoBehaviour
{
    public float thrustForce = 5f;
    public float rotationSpeed = 120f;
    private Rigidbody rb;
    private Vector2 thrustDirection;

    public static int SCORE = 0;
    public static int RECORD;
    public static float xBorderLimit, yBorderLimit;

    public GameObject gun, bulletPrefab, pooling;

    public AudioSource audioSource;
    public AudioClip sonidoDisparo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        yBorderLimit = Camera.main.orthographicSize + 1;
        xBorderLimit = yBorderLimit * Screen.width / Screen.height;

        SCORE = 0;
        RECORD = PlayerPrefs.GetInt("Record", 0);
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x > xBorderLimit)
            pos.x = -xBorderLimit+1;
        else if (pos.x < -xBorderLimit)
            pos.x = xBorderLimit-1;

        if (pos.y > yBorderLimit)
            pos.y = -yBorderLimit+1;
        else if (pos.y < -yBorderLimit)
            pos.y = yBorderLimit-1;

        transform.position = pos;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = pooling.GetComponent<Pooling>().GetBullet();
            if(bullet != null)
            {
                bullet.transform.position = gun.transform.position;
                bullet.transform.rotation = Quaternion.identity;
                Bullet balaScript = bullet.GetComponent<Bullet>();
                balaScript.targetVector = transform.right;
                audioSource.PlayOneShot(sonidoDisparo);
            }
            else
            {
                Debug.Log("No hay suficientes balas");
            }

        }
    }

    private void FixedUpdate()
    {
        float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.fixedDeltaTime; 
        float thrust = Input.GetAxis("Thrust") * thrustForce;
        thrustDirection = transform.right;
        transform.Rotate(Vector3.forward, -rotation);
        rb.AddForce(thrustDirection * thrust);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("TinyEnemy"))
        {
            GameManager gm = FindAnyObjectByType<GameManager>();
            gm.FinPartida();
        }
        else
        {
            Debug.Log("He colisionado con otra cosa...");
        }
    }
}