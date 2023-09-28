using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMenuClick : MonoBehaviour
{
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
