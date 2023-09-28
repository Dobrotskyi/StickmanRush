using UnityEngine;

public class LoadLevelOnClick : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        LevelLoader.LoadScene(name);
    }
}
