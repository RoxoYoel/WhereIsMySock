using UnityEngine;

public class siChocoVidaMenos : MonoBehaviour
{
    public GameManager GameManager;
    //public AudioSource AudioSource;
    public void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            GameManager.Chocar();
        }
    }
}
