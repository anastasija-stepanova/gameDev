using UnityEngine;

public class FigureFactory : MonoBehaviour
{
    public static FigureFactory Instance;
    
    [SerializeField] private GenericFigure _circlePrefab;
    [SerializeField] private GenericFigure _ellipsePrefab;
    [SerializeField] private GenericFigure _rectanglePrefab;
    [SerializeField] private GenericFigure _squarePrefab;
    [SerializeField] private GenericFigure _trianglePrefab;

    private void Awake()
    {
        Instance = this;
    }

    public IFigure Create(FigureType figureType, Transform parent)
    {
        IFigure newFigure = null;

        switch (figureType)
        {
                case FigureType.Circle:
                    newFigure = Instantiate(_circlePrefab, parent);
                    break;
                case FigureType.Ellipse:
                    newFigure = Instantiate(_ellipsePrefab, parent);
                    break;
                case FigureType.Rectangle:
                    newFigure = Instantiate(_rectanglePrefab, parent);
                    break;
                case FigureType.Square:
                    newFigure = Instantiate(_squarePrefab, parent);
                    break;
                case FigureType.Triangle:
                    newFigure = Instantiate(_trianglePrefab, parent);
                    break;
        }

        return newFigure;
    }   
}
