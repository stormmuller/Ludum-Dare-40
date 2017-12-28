using System;
using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public MenuStatusVariable menuStatus;
    public GameObjectVariable menu;

    public void UpdateVisiblity(string restriction)
    {
        var enumValue = (MenuStatus)Enum.Parse(typeof(MenuStatus), restriction);

        if ((menuStatus.CurrentValue & enumValue) == enumValue)
        {
            menu.CurrentValue.SetActive(!menu.CurrentValue.activeInHierarchy);
        }
    }
}
