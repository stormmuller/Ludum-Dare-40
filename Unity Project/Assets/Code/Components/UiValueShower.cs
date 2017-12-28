using UnityEngine;
using UnityEngine.UI;

public class UiValueShower : MonoBehaviour
{
    public IntVariable valueToTrack;
    public Text textToUpdate;
    public StringVariable textToAmend;

    private void Start()
    {
        UpdateUiText();
    }

    public void UpdateUiText()
    {
        textToUpdate.text = valueToTrack.CurrentValue + " " + textToAmend.CurrentValue;
    }
}
