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

    [Header("Image")]
    [SerializeField] private Sprite DefaultImage;
    [SerializeField] private Sprite SelectedImage;

    private Button Button;
    private Image Image;


    public void InitComponents()
    {
        if (!TryGetComponent<Button>(out Button))
        {
            Debug.LogError("Get Button Component Failed !!");
        }
        if (!TryGetComponent<Image>(out Image))
        {
            Debug.LogError("Get Image Component Failed !!");
        }
    }

    public void SetRadioOn()
    {
        Button.interactable = false;
        Image.sprite = SelectedImage;
        OnSelected?.Invoke();
    }
    public void SetRadioOff()
    {
        Button.interactable = true;
        Image.sprite = DefaultImage;
        OnCanceled?.Invoke();
    }
}
