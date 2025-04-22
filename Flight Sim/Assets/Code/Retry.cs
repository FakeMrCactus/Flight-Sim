using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Oooowa()
    {
        SceneManager.LoadScene("Title");
    }

    public void Zoinks()
    {
        Application.Quit();
    }
}
