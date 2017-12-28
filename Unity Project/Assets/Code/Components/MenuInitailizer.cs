using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class MenuInitailizer : MonoBehaviour
{
    public GameObjectVariable[] menus;

    private void Awake()
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].CurrentValue = Instantiate(menus[i].CurrentValue, transform);
        }
    }
}
