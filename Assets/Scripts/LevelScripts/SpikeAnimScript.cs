using UnityEngine;
using System.Collections;

public class SpikeAnimation : MonoBehaviour
{
    public Animator animator;
    public string animationClipName = "BasicSpike";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.enabled = true;
            animator.Play(animationClipName, -1, 0f); // Reproduce la animación desde el inicio
            StartCoroutine(DisableAnimatorAfterDelay(5f));
        }
    }

    private IEnumerator DisableAnimatorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //animator.enabled = false;
    }
}
