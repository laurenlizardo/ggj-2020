using System;
using System.Collections.Generic;

public delegate void Callback();

public static class Messenger
{
    private static Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();

    public static void AddListener(string eventType, Callback handler)
    {
        lock (eventTable)
        {
            if (!eventTable.ContainsKey(eventType))
            {
                eventTable.Add(eventType, null);
                Debug.Log(string.Format("ADDED: Listener ({0}) to Dictionary({1}).", eventType, eventTable.ToString()));
            }
            eventTable[eventType] = (Callback)eventTable[eventType] + handler;
        }
    }

    public static void RemoveListener(string eventType, Callback handler)
    {
        lock (eventTable)
        {
            if (eventTable.ContainsKey(eventType))
            {
                eventTable[eventType] = (Callback)eventTable[eventType] - handler;

                if (eventTable[eventType] == null)
                {
                    eventTable.Remove(eventType);
                }
            }
        }
    }

    public static void Invoke(string eventType)
    {
        if (eventTable.TryGetValue(eventType, out Delegate d))
        {
            ((Callback)d)?.Invoke();
        }
    }
}