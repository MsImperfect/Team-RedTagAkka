using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneChanger : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign in Inspector
    public string nextSceneName; // Set the scene name to load

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += EndReached; // Subscribe to event
        }
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }
}