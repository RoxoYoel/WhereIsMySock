using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{


    //VARIABLES PRINCIPALES
    public static int lives = 3;
    public static int livesEnemy = 1;
    public static float musicVolume;

    //canvas
    public GameObject completeLevelUI;
    public GameObject vidasUI;
    public GameObject GameOver;
    public GameObject pause;



    /*public int spawnRate;


    public void StartGame(int difficulty)
    {
        //UNIR EL SPAWNRATE Y LA DIFICULTAD
        spawnRate = spawnRate / difficulty;
    }*/

    public void Awake()
    {
        lives = 3;
    }
    public void Start()
    {
        GameOver.SetActive(false);
        completeLevelUI.SetActive(false);
    }
    public void Update()
    {

    }
    public void VidasEnemigo()
    {
        livesEnemy--;
        Debug.Log("Vidas restantes: " + livesEnemy);
    }
    public void Chocar()
    {
        lives--;
        Debug.Log("Vidas restantes: " + lives);
        vidasUI.GetComponent<CanvasUI>().setActiveSprite(lives);
        Time.timeScale = 0.5f;
        Invoke("Reanude", 1f);

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            GameOver.SetActive(false);
        }
    }


    public void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void Reanude()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void CompleteLevel()
    {
        
        completeLevelUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void CambioEscena()
    {
        SceneManager.LoadScene(1);
    }
    public void CambioEscenaMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1; 
    }
    public void CambioEscena0()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

}
