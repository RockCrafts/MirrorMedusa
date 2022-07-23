using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Game Event to register.")]
    [SerializeField]
    private GameEvent gameEvent;

    [Tooltip("Unity Events to perform when the Game Event is raised.")]
    public UnityEvent response;
    public void OnEnable()
    {
        gameEvent.action += response.Invoke;
    }
    public void OnDisable()
    {
        gameEvent.action -= response.Invoke;
    }
}
