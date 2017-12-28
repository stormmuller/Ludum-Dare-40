using UnityEngine;

public abstract class Variable<T> : ScriptableObject
{
    public T DefaultValue;

    private T currentValue;

    public T CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }

    private void OnEnable()
    {
        currentValue = DefaultValue;
    }

    public void Reset()
    {
        CurrentValue = DefaultValue;
    }
}
