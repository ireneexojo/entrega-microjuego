using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject menuPausa;
    public bool isPaused;

    public GameObject menuGameOver;

    private void Start()
    {
        menuPausa.SetActive(false);
        isPaused = false;
        menuGameOver.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isPaused)
            {
                // Reanudar el juego
                Reanudar();
            }
            else
            {
                // Pausar el juego
                Pausar();                
                
            }
        }
    }

    public void Pausar()
    {
        Time.timeScale = 0;
        menuPausa.SetActive(true);
        isPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Reanudar()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        isPaused = false;
        EventSystem.current.SetSelectedGameObject(null);

    }

    public void NuevaPartida()
    {
        Reanudar();
        Player.SCORE = 0;
        SceneManager.LoadScene("Game");
        EventSystem.current.SetSelectedGameObject(null);

    }

    public void Salir()
    {
        Application.Quit();
    }

    public void FinPartida()
    {
        Time.timeScale = 0;
        menuGameOver.SetActive(true);
        GameObject go = GameObject.FindGameObjectWithTag("UIgo");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
        GameObject re = GameObject.FindGameObjectWithTag("Record");
        re.GetComponent<Text>().text = "Max Score: " + Player.RECORD;
    }

}