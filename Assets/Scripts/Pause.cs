using UnityEngine;

public class Escape : MonoBehaviour
{
    public GameObject pause;
    public bool action = true;
    void Start()
    {
        pause.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && action == true)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            action = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && action == false)
        {
            Time.timeScale = 1;
            pause.SetActive(false);
            action = true;
        }
    }
}
