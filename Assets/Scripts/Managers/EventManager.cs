
using System.Collections.Generic;

using System;


public static class EventTypes
{ 
    public enum GlobalEvents
    {
        LevelStarted,
        GridGenerated,
        
    }
    public enum InGameEvents{
        DisplayPath,
        
    }
}


public static class EventManager
{
    private static Dictionary<object, Delegate> eventDictionaryWithParams = new Dictionary<object, Delegate>();
    private static Dictionary<object, Delegate> eventDictionaryWithoutParams = new Dictionary<object, Delegate>();

    public static void RegisterEvent<TEventEnum, TEventArgs>(TEventEnum eventType, Action<TEventArgs> eventHandler)
    {
        if (eventType == null) return;

        if (!eventDictionaryWithParams.ContainsKey(eventType))
            eventDictionaryWithParams[eventType] = eventHandler;
        else
            eventDictionaryWithParams[eventType] = Delegate.Combine(eventDictionaryWithParams[eventType], eventHandler);
    }

    public static void RegisterEvent<TEventEnum>(TEventEnum eventType, Action eventHandler)
    {
        if (eventType == null) return;

        if (!eventDictionaryWithoutParams.ContainsKey(eventType))
            eventDictionaryWithoutParams[eventType] = eventHandler;
        else
            eventDictionaryWithoutParams[eventType] = Delegate.Combine(eventDictionaryWithoutParams[eventType], eventHandler);
    }

    public static void TriggerEvent<TEventEnum>(TEventEnum eventType)
    {
        if (eventDictionaryWithoutParams.TryGetValue(eventType, out Delegate del)){
            if (del is Action action){
                action();
            }
        }
    }
    public static void TriggerEvent<TEventEnum, TEventArgs>(TEventEnum eventType, TEventArgs eventArgs)
    {
        if (eventDictionaryWithParams.TryGetValue(eventType, out Delegate del))
        {
            if (del is Action<TEventArgs> action)
            {
                action(eventArgs);
            }
        }
    }
}
