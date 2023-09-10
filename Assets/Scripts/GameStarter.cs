using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public static event Action Start;
    public void StartGame() => Start?.Invoke();
}
