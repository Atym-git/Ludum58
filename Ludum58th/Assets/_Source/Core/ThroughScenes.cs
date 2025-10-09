using UnityEngine;
using UnityEngine.SceneManagement;

public class ThroughScenes : MonoBehaviour
{
    public void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
