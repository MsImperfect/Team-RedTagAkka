using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuToCall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("Call");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
