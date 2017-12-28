using UnityEngine;

public class EventRaiser : MonoBehaviour
{
    public GameEvent gameEvent;

    public virtual void RaiseEvent()
    {
        gameEvent.Raise();
    }
}
