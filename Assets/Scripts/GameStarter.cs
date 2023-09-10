using System;
using UnityEngine;

public class GameStarter
{
    public event Action Start;
    private static GameStarter s_instance;
    private GameStarter() { }

    public static GameStarter Instance
    {
        get
        {
            if (s_instance == null)
                s_instance = new();
            return s_instance;
        }
    }

    public void StartGame() => Start?.Invoke();
}
