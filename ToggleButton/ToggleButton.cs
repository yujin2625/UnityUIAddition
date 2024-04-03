using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button)), RequireComponent(typeof(Image))]
public class ToggleButton : MonoBehaviour
{
    public bool IsOn = false;

    [Header("Set Image")]
    [SerializeField] private bool ButtonTransitionOn = true;
    [Space(10f)]
    [SerializeField] private Sprite ImageOff;
    [SerializeField] private Sprite ImageOn;

    [Header("Set Color")]
    [SerializeField] private Color ColorOff = Color.white;
    [SerializeField] private Color ColorOn = Color.white;

    [Header("Event"),Space(10f)]
    [SerializeField] private UnityEvent TrunedOn;
    [SerializeField] private UnityEvent TurnedOff;

    private Button button;
    private Image image;

    private void Awake()
    {
        if (!TryGetComponent<Button>(out button))
            Debug.LogError("Button component not set with toggle script");
        if (!TryGetComponent<Image>(out image))
            Debug.LogError("Image component not set with toggle script");
        button.onClick.AddListener(OnClickToggle);
        if(!ButtonTransitionOn)
            button.transition = Selectable.Transition.None;
        if (ImageOn == null)
            ImageOn = image.sprite;
        if(ImageOff == null)
            ImageOff = image.sprite;

        OnClickToggle(IsOn);
    }
    public void SetToggleOn()
    {
        IsOn = true;
        image.sprite = ImageOn;
        image.color = ColorOn;
        TrunedOn?.Invoke();
    }
    public void SetToggleOff()
    {
        IsOn = false;
        image.sprite = ImageOff;
        image.color = ColorOff;
        TurnedOff?.Invoke();
    }
    public void OnClickToggle()
    {
        if (IsOn) SetToggleOff();
        else SetToggleOn();
    }
    public void OnClickToggle(bool setOn)
    {
        if (setOn) SetToggleOn();
        else SetToggleOff();
    }
}
