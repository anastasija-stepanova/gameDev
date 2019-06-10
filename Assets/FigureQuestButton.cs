using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FigureQuestButton : MonoBehaviour
{
    public event Action CallOnButtonClick;

    public FigureType GetFigureType => _figureType;
    
    [SerializeField] private FigureType _figureType;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnClick()
    {
        CallOnButtonClick?.Invoke();
    }

    public void SetColor(AvailableColors color)
    {
        _image.color = ColorManager.GetColorFromAvailable(color);
    }
}
