using UnityEngine;
using UnityEngine.UI;

public class UICheckboxToggle : MonoBehaviour
{
    public Sprite uncheckedBox;
    public Sprite checkedBox;

    private Image UiImage;
    private bool toggle = false;

    private void Start()
    {
        UiImage = GetComponent<Image>();
    }

    public void ToggleCheckBox()
    {
        toggle = !toggle;
        UiImage.sprite = toggle ? checkedBox : uncheckedBox;
    }
}
