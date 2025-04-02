using UnityEngine;
using System.Collections;

public class GhostDeathEffect : MonoBehaviour
{
    public ParticleSystem burstEffect; // Assign in Inspector
    public float fadeDuration = 1.5f; // Time for fading out

    private Renderer ghostRenderer;
    private Material ghostMaterial;
    private Color originalColor;
    private Animator animator;

    private void Start()
    {
        ghostRenderer = GetComponent<Renderer>(); // Get renderer
        animator = GetComponent<Animator>(); // Get animator (if exists)

        if (ghostRenderer != null)
        {
            ghostMaterial = ghostRenderer.material; // Get material
            originalColor = ghostMaterial.color; // Store original color
        }
    }

    public void Die()
    {
        if (animator)
        {
            animator.enabled = false; // Stop all animations
        }

        if (burstEffect)
        {
            // Instantiate burst effect at ghost's position
            Instantiate(burstEffect, transform.position, Quaternion.identity);
        }

        // Start fading out
        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            if (ghostMaterial)
            {
                ghostMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            }

            yield return null;
        }

        // Destroy the ghost after fading
        Destroy(gameObject);
    }
}
