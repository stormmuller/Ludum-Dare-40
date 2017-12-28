using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ListVariable<T> : ScriptableObject
{
    public List<T> DefaultItems = new List<T>();
    private List<T> currentItems = new List<T>();


    public List<T> CurrentItems
    {
        get { return currentItems; }
        set { currentItems = value; }
    }

    private void OnEnable()
    {
        var temp = new T[DefaultItems.Count];

        DefaultItems.CopyTo(temp);
        currentItems = temp.ToList();
    }

    public void Add(T obj)
    {
        if (!CurrentItems.Contains(obj))
            CurrentItems.Add(obj);
    }

    public void Remove(T obj)
    {
        if (CurrentItems.Contains(obj))
            CurrentItems.Remove(obj);
    }
}
