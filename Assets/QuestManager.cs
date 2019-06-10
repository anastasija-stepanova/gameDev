using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestManager : MonoBehaviour
{
    public event Action CallOnQuestionTrue;
    public event Action CallOnQuestionFalse;
    
    [Header("Buttons")]
    [SerializeField] private FigureQuestButton _circleButtonPrefab;
    [SerializeField] private FigureQuestButton _ellipseButtonPrefab;
    [SerializeField] private FigureQuestButton _rectangleButtonPrefab;
    [SerializeField] private FigureQuestButton _squareButtonPrefab;
    [SerializeField] private FigureQuestButton _triangleButtonPrefab;

    [Header("Positions")] 
    [SerializeField] private Transform _firstButtonPosition;
    [SerializeField] private Transform _secondButtonPosition;

    [Header("Color")]
    [SerializeField] private FigureQuestButton _colorButtonPrefab;
    
    private FigureQuestButton _firstButton;
    private FigureQuestButton _secondButton;
    
    public void CreateNewFigureQuest(FigureType _trueFigure, FigureType _falseFigure, bool equals = false)
    {
        if (_firstButton != null)
        {
            Destroy(_firstButton.gameObject);
            Destroy(_secondButton.gameObject);
        }

        if (equals)
        {
            _firstButton = Instantiate(GetPrefabByFigureType(_trueFigure), transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition,0.3f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();

            _secondButton = Instantiate(GetPrefabByFigureType(_falseFigure),transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition,0.3f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            return;
        }
        
        if (RandomBool())
        {
            _firstButton = Instantiate(GetPrefabByFigureType(_trueFigure), transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition,0.6f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();

            _secondButton = Instantiate(GetPrefabByFigureType(_falseFigure),transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition,0.6f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionFalse?.Invoke();
        }
        else
        {
            _secondButton = Instantiate(GetPrefabByFigureType(_trueFigure), transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition,0.6f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();

            _firstButton = Instantiate(GetPrefabByFigureType(_falseFigure) , transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition,0.6f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionFalse?.Invoke();
        }
    }

    public void FigureAndColorCountQuestion(FigureType _trueFigure, FigureType _falseFigure, AvailableColors _trueColor, AvailableColors _falseColor, bool equals = false)
    {
        if (_firstButton != null)
        {
            Destroy(_firstButton.gameObject);
            Destroy(_secondButton.gameObject);
        }

        if (equals)
        {
            _firstButton = Instantiate(GetPrefabByFigureType(_trueFigure), transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition,0.3f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            _firstButton.SetColor(_trueColor);

            _secondButton = Instantiate(GetPrefabByFigureType(_falseFigure),transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition,0.3f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            _secondButton.SetColor(_falseColor);
            return;
        }
        
        if (RandomBool())
        {
            _firstButton = Instantiate(GetPrefabByFigureType(_trueFigure), transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition,0.6f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            _firstButton.SetColor(_trueColor);

            _secondButton = Instantiate(GetPrefabByFigureType(_falseFigure),transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition,0.6f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionFalse?.Invoke();
            _secondButton.SetColor(_falseColor);
        }
        else
        {
            _secondButton = Instantiate(GetPrefabByFigureType(_trueFigure), transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition,0.6f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            _secondButton.SetColor(_trueColor);

            _firstButton = Instantiate(GetPrefabByFigureType(_falseFigure) , transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition,0.6f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionFalse?.Invoke();
            _firstButton.SetColor(_falseColor);
        }
    }
    
    public void ColorQuestion(AvailableColors _trueColor, AvailableColors _falseColor, bool equals = false)
    {
        if (_firstButton != null)
        {
            Destroy(_firstButton.gameObject);
            Destroy(_secondButton.gameObject);
        }

        if (equals)
        {
            _firstButton = Instantiate(_colorButtonPrefab, transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition,0.6f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            _firstButton.SetColor(_trueColor);

            _secondButton = Instantiate(_colorButtonPrefab,transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition,0.6f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            _secondButton.SetColor(_falseColor);
            return;
        }

        if (RandomBool())
        {
            Debug.Log("rand true");
            _firstButton = Instantiate(_colorButtonPrefab, transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition, 0.6f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            _firstButton.SetColor(_trueColor);

            _secondButton = Instantiate(_colorButtonPrefab, transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition, 0.6f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionFalse?.Invoke();
            _secondButton.SetColor(_falseColor);
        }
        else
        {
            Debug.Log("rand false");
            _secondButton = Instantiate(_colorButtonPrefab, transform);
            _secondButton.transform.DOLocalMove(_secondButtonPosition.localPosition, 0.6f);
            _secondButton.CallOnButtonClick += () => CallOnQuestionTrue?.Invoke();
            _secondButton.SetColor(_trueColor);

            _firstButton = Instantiate(_colorButtonPrefab, transform);
            _firstButton.transform.DOLocalMove(_firstButtonPosition.localPosition, 0.6f);
            _firstButton.CallOnButtonClick += () => CallOnQuestionFalse?.Invoke();
            _firstButton.SetColor(_falseColor);
        }
    }
    
    private FigureQuestButton GetPrefabByFigureType(FigureType type)
    {
        switch (type)
        {
                case FigureType.Circle:
                    return _circleButtonPrefab;
                case FigureType.Ellipse:
                    return _ellipseButtonPrefab;
                case FigureType.Rectangle:
                    return _rectangleButtonPrefab;
                case FigureType.Square:
                    return _squareButtonPrefab;
                case FigureType.Triangle:
                    return _triangleButtonPrefab;
        }

        return null;
    }

    private bool RandomBool() => Random.Range(0, 100) >= 50;
}
