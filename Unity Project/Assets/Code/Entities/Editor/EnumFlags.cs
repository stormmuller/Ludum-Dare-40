using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MenuStatus))]
[CustomPropertyDrawer(typeof(ResourceType))]
public class EnumFlagsAttributeDrawer : PropertyDrawer
{

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int enumLength = property.enumNames.Length;
        return enumLength * 28f;
    }

    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        int buttonsIntValue = 0;
        int enumLength = _property.enumNames.Length;
        bool[] buttonPressed = new bool[enumLength];
        float buttonWidth = EditorGUIUtility.currentViewWidth - (EditorGUIUtility.labelWidth + EditorGUIUtility.fieldWidth);

        EditorGUI.LabelField(new Rect(_position.x, _position.y, EditorGUIUtility.labelWidth, _position.height), _label);

        EditorGUI.BeginChangeCheck();

        //float buttonHeight = _position.height / enumLength;
        float buttonHeight = 20f;
        for (int i = 0; i < enumLength; i++)
        {

            // Check if the button is/was pressed 
            if ((_property.intValue & (1 << i)) == 1 << i)
            {
                buttonPressed[i] = true;
            }

            Rect buttonPos = new Rect(
                _position.x + EditorGUIUtility.labelWidth,
                _position.y + (i * buttonHeight),
                buttonWidth,
                buttonHeight - 4);

            buttonPressed[i] = GUI.Toggle(buttonPos, buttonPressed[i], _property.enumNames[i], "Button");

            if (buttonPressed[i])
                buttonsIntValue += 1 << i;
        }

        if (EditorGUI.EndChangeCheck())
        {
            _property.intValue = buttonsIntValue;
        }
    }
}