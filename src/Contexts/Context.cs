using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public sealed class Context
{
    public readonly GameObject agent;

    private readonly Dictionary<string, object> contextData = new Dictionary<string, object>();

    public Context(GameObject agent)
    {
        this.agent = agent;
    }

    public void SetContextData(string name, object data)
    {
        contextData[name] = data;
    }
    
    /// <summary>
    /// Get data from the context.
    /// </summary>
    /// <param name="name">The expected name of the data.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>The data if it exists, and the default value if it does not.</returns>
    public T TryGetContextData<T>(string name)
    {
        if (!dataExists<T>(name))
        {
            Debug.LogFormat("Tried to find a {0}-type object named '{1}', but it was either of the wrong type" +
                            "or it did not exist.", name, typeof(T));
            return default(T);
        }
        
        return (T) contextData[name];
    }

    /// <summary>
    /// Does the data exist at this label?
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public bool dataExists<T>(string label)
    {
        return contextData.Keys.Contains(label) && contextData["label"].GetType() == typeof(T);
    }
    
    /// <summary>
    /// Dumps the context's data including names. This allows for easy debugging.
    /// </summary>
    public void DumpData()
    {
        var result = string.Format("Context data members for {1}: ");
        foreach (var entry in contextData)
        {
            result += string.Format("{0}:{1} of type {2}", entry.Key, entry.Value, entry.Value.GetType());
        }
        Debug.Log(result);
    }
}
