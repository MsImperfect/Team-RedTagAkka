using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetFloat("move", Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
