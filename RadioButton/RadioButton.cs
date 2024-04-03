using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button),typeof(Image))]
public class RadioButton : MonoBehaviour
{
    [SerializeField] private UnityEvent OnSelected;
    [SerializeField] private UnityEvent OnCanceled;

    public void SetRadioOn()
    {
        OnSelected?.Invoke();
    }
    public void SetRadioOff()
    {
        OnCanceled?.Invoke();
    }
}
