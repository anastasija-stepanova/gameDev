using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform),typeof(Image))]
public class GenericFigure : MonoBehaviour, IFigure
{
    public AvailableColors GetColor => _color;
    public FigureType GetFigureType => _figureType;
    
    private RectTransform _rectTransform;
    private Image _image;
    private AvailableColors _color;
    private FigureType _figureType;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    public void Initialize(Vector2 position, float scale, int zRotation, FigureType type)
    {
        transform.localPosition = position;
        transform.localScale = new Vector3(scale,scale,1);
        transform.localEulerAngles = new Vector3(0,0,zRotation);
        _figureType = type;
    }

    public void SetPosition(Vector2 position)
    {
        transform.DOLocalMove(position, 0.5f);
    }

    public void SetSize(float scale)
    {   
        transform.DOScale(new Vector3(scale,scale,1), 0.5f);
    }

    public void SetRotation(int zRotation)
    {
        transform.DORotate(new Vector3(0,0,zRotation), 0.5f);
    }

    public void SetColor(AvailableColors color)
    {
        _color = color;
        _image.color = ColorManager.GetColorFromAvailable(color);
    }
}
