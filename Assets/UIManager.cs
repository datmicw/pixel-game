using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level 1"); 
    }
    public void OnQuitButton()
    {
        Application.Quit(); 
    }
}
