using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelClick : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
