using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            animator.enabled = true;
        }
    }
}
