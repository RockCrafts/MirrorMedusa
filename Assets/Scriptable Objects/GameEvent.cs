using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    public event Action action;

    public void Invoke()
    {
        action?.Invoke();
    }
}
