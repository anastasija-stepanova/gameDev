using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameModel : MonoBehaviour
{
    [SerializeField] private GameView _gameView;
    
    [SerializeField] private int _countOfStartFigures;
    [SerializeField] private FunctionTimer _functionTimer;
    
    private List<GenericFigure> _spawnedFigures = new List<GenericFigure>();
    private List<FigureType> _spawnedFigureTypes = new List<FigureType>();
    private QuestionType _currentQuestion;
    
    private int _score = 0;
    
    private void Start()
    {
        SpawnStartFigures();
        _gameView.RecolorAll(_spawnedFigures);
        ExecuteRandomQuestion();
        _gameView.PrintScore(_score);
        
        _functionTimer.TimerStart(15);
    }

    public void NextQuestion()
    {
        _gameView.ReinitializeFiguresRandomly(_spawnedFigures);
        _gameView.RecolorAll(_spawnedFigures);

        _score += 100;
        _gameView.PrintScore(_score);
        
        _functionTimer.AddSecondsToTimer(3);
        
        ExecuteRandomQuestion();
    }

    private void Update()
    {
        if (_functionTimer.IsTimerStart)
        {
            _gameView.PrintTimer(_functionTimer.GetHowManyTime);
        }
    }

    private void ExecuteRandomQuestion()
    {
        var quest = GetRandomQuestionData();

        switch (quest)
        {
                case QuestionType.FigureColorQuestion:
                    ColorCountQuestion();
                    break;
                case QuestionType.FigureCountQuestion:
                    FigureCountQuestion();
                    break;
                case QuestionType.FigureCountAndColorQuestion:
                    ColorAndFigureColorQuestion();
                    break;
        }
    }
    
    private void SpawnStartFigures()
    {
        for (int i = 0; i < _countOfStartFigures; i++)
        {
            FigureType randomType = GetRandomFigureType();
            _spawnedFigures.Add((GenericFigure)_gameView.SpawnNewFigure(randomType));
            _spawnedFigureTypes.Add(randomType);
        }
    }

    public void FigureCountQuestion() //Question
    {
        var randomFigureTypes = GetRandomFigureTypesForCountQuestion();

        if (GetFigureCount(randomFigureTypes.Item1) == GetFigureCount(randomFigureTypes.Item2))
        {
            _gameView.CreateNewFigureQuest(randomFigureTypes.Item1, randomFigureTypes.Item2, true);
            Debug.Log("equal");
            return;
        }
        
        if (GetFigureCount(randomFigureTypes.Item1) > GetFigureCount(randomFigureTypes.Item2))
        {
            _gameView.CreateNewFigureQuest(randomFigureTypes.Item1, randomFigureTypes.Item2);
            Debug.Log("Item1 > Item2");
        }
        else
        {
            _gameView.CreateNewFigureQuest(randomFigureTypes.Item2, randomFigureTypes.Item1);
            Debug.Log("Item1 < Item2");
        }
    }

    public void ColorCountQuestion() //Question
    {
        var colors = GetRandomAvailableForColorQuestion();
        if (GetColorCount(colors.Item1) == GetColorCount(colors.Item2))
        {
            _gameView.CreateNewColorQuest(colors.Item1,colors.Item2, true);
            Debug.Log("Equals");
            return;
        }
        
        if (GetColorCount(colors.Item1) > GetColorCount(colors.Item2))
        {
            _gameView.CreateNewColorQuest(colors.Item1,colors.Item2);
            Debug.Log("Item1 > Item2");
        }
        else
        {
            _gameView.CreateNewColorQuest(colors.Item2,colors.Item1);
            Debug.Log("Item1 < Item2");
        }
    }

    public void ColorAndFigureColorQuestion() //Question
    {
        var figures = GetRandomFigureTypesForCountQuestion();
        var firstColor = CountOfFigureColor(figures.Item1);
        var secondColor = CountOfFigureColor(figures.Item2);
        
        if (firstColor.Item2 == secondColor.Item2)
        {
            _gameView.CreateNewFigureAndColorQuest(figures.Item1,figures.Item2,firstColor.Item1,secondColor.Item1,true);
            Debug.Log("Equals");
            return;
        }
        
        if (firstColor.Item2 > secondColor.Item2)
        {        
            _gameView.CreateNewFigureAndColorQuest(figures.Item1,figures.Item2,firstColor.Item1,secondColor.Item1);
            Debug.Log("Item1 > Item2");
        }
        else
        {
            _gameView.CreateNewFigureAndColorQuest(figures.Item2,figures.Item1,secondColor.Item1,firstColor.Item1);
            Debug.Log("Item1 < Item2");
        }
    }

    private (AvailableColors,int) CountOfFigureColor(FigureType type)
    {
        bool colornull = true;
        AvailableColors color = AvailableColors.Blue;
        int count = 0;
        
        foreach (var figure in _spawnedFigures)
        {
            if (figure.GetFigureType == type)
            {
                if (colornull)
                {
                    color = figure.GetColor;
                    count = 1;
                    colornull = false;
                    continue;
                }

                if (figure.GetColor == color)
                {
                    count++;
                }
            }
        }

        return (color, count);
    }
    
    private int GetColorCount(AvailableColors color)
    {
        int count = 0;
        
        foreach (var figure in _spawnedFigures)
        {
            if (figure.GetColor == color)
            {
                count++;
            }
        }

        return count;
    }
    
    private int GetFigureCount(FigureType figureType)
    {
        int count = 0;
        
        foreach (var type in _spawnedFigureTypes)
        {
            if (type == figureType)
            {
                count++;
            }
        }

        return count;
    }

    private List<AvailableColors> GetAvailableColors()
    {
        List<AvailableColors> colors = new List<AvailableColors>();

        foreach (var figure in _spawnedFigures)
        {
            if (!colors.Contains(figure.GetColor))
            {
                colors.Add(figure.GetColor);
            }
        }

        return colors;
    }
    
    private List<FigureType> GetAvailableFigureTypes()
    {
        List<FigureType> aloneFigureTypes = new List<FigureType>();
        
        foreach (var figureType in _spawnedFigureTypes)
        {
            if (!aloneFigureTypes.Contains(figureType))
            {
                aloneFigureTypes.Add(figureType);
            }
        }

        return aloneFigureTypes;
    }    
    
    private (FigureType, FigureType) GetRandomFigureTypesForCountQuestion()
    {
        List<FigureType> aloneFigureTypes = GetAvailableFigureTypes();

        FigureType firstType;
        FigureType secondType;
        

        int firstFigureRandomIndex = Random.Range(0, aloneFigureTypes.Count - 1);
        firstType = aloneFigureTypes[firstFigureRandomIndex];
        aloneFigureTypes.RemoveAt(firstFigureRandomIndex);
        
        secondType = aloneFigureTypes[Random.Range(0, aloneFigureTypes.Count - 1)];

        return (firstType, secondType);
    }
    
    private (AvailableColors, AvailableColors) GetRandomAvailableForColorQuestion()
    {
        List<AvailableColors> aloneFigureTypes = GetAvailableColors();

        AvailableColors firstType;
        AvailableColors secondType;
        

        int firstFigureRandomIndex = Random.Range(0, aloneFigureTypes.Count - 1);
        firstType = aloneFigureTypes[firstFigureRandomIndex];
        aloneFigureTypes.RemoveAt(firstFigureRandomIndex);
        
        secondType = aloneFigureTypes[Random.Range(0, aloneFigureTypes.Count - 1)];

        return (firstType, secondType);
    }
    
    private FigureType GetRandomFigureType()
    {
        var values = Enum.GetValues(typeof(FigureType));
        return (FigureType)values.GetValue(Random.Range(0, values.Length));
    }
    
    private QuestionType GetRandomQuestionData()
    {
        var values = Enum.GetValues(typeof(QuestionType));
        return (QuestionType)values.GetValue(Random.Range(0, values.Length));
    }
}
