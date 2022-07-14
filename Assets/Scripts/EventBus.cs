using System.Collections.Generic;
using UnityEngine.Events;

public class EventBus
{
    private static readonly IDictionary<PlayerEventType, UnityEvent> Events = new Dictionary<PlayerEventType, UnityEvent>();

    public static void Subscribe(PlayerEventType eventType, UnityAction listener)
    {
        if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe(PlayerEventType type, UnityAction listener)
    {
        if (Events.TryGetValue(type, out UnityEvent thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(PlayerEventType type)
    {
        if (Events.TryGetValue(type, out var thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}