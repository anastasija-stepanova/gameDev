using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameView : MonoBehaviour
{
   [SerializeField] private GameController _gameController;
   
   [SerializeField] private QuestManager _questManager;
   [SerializeField] private ErrorPanel _errorPanel;
   [SerializeField] private RectTransform _game;
   [SerializeField] private Text _scoreText;
   [SerializeField] private Text _timerText;

   //private List<AvailableColors> _unUsedColors = new List<AvailableColors>();
   
   private void Awake()
   {
      _questManager.CallOnQuestionTrue += OnTrue;
      _questManager.CallOnQuestionFalse += OnFalse;
     
   }

   public IFigure SpawnNewFigure(FigureType type)
   {
      var newFigure = FigureFactory.Instance.Create(type, _game);
      
      newFigure.Initialize(GetRandomScreenPosition(), GetRandomScale(), GetRandomRotation(), type);

      return newFigure;
   }

   public void ReinitializeFiguresRandomly(List<GenericFigure> figures)
   {
      foreach (var figure in figures)
      {
         figure.SetPosition(GetRandomScreenPosition());
         figure.SetRotation(GetRandomRotation());
         figure.SetSize(GetRandomScale());
      }
   }

   public void RecolorAll(List<GenericFigure> spawnedFigures)
   {     
      foreach (var figure in spawnedFigures)
      {
         figure.SetColor(GetRandomAvailableColor());
      }
   }
   
   public void CreateNewFigureQuest(FigureType _trueFigure, FigureType _falseFigure, bool equal = false)
   {
      _questManager.CreateNewFigureQuest(_trueFigure,_falseFigure, equal);
   }
   
   public void CreateNewColorQuest(AvailableColors _trueColor, AvailableColors _falseColor, bool equals = false)
   {
      _questManager.ColorQuestion(_trueColor,_falseColor,equals);
   }

   public void CreateNewFigureAndColorQuest(FigureType _trueFigure, FigureType _falseFigure, AvailableColors _trueColor,
      AvailableColors _falseColor, bool equals = false)
   {
      _questManager.FigureAndColorCountQuestion(_trueFigure,_falseFigure,_trueColor,_falseColor,equals);
   }
   
   private AvailableColors GetRandomAvailableColor()
   {
      var colors = Enum.GetValues(typeof(AvailableColors));

      return (AvailableColors)colors.GetValue(Random.Range(0, colors.Length - 1));
   }
   
   private void OnTrue()
   {
      _gameController.NextQuestion();
   }

   private void OnFalse()
   {
      Debug.Log("False");
      SetErrorPanel();
      this.enabled = false;
   }

   private void SetErrorPanel()
   {
      _gameController.EndGame();
      _errorPanel.gameObject.SetActive(true);
      _errorPanel.SetText(_scoreText.text);
   }
   
   private Vector2 GetRandomScreenPosition()
   {
      float xSize = _game.rect.width;
      float ySize = _game.rect.height;
      
      return new Vector2(Random.Range(0,xSize),Random.Range(0,ySize));
   }

   public void PrintScore(int score)
   {
      _scoreText.text = $"Score: {score}";
   }
   
   private float GetRandomScale() => Random.Range(1f, 3f);

   private int GetRandomRotation() => Random.Range(0, 360);

   public void PrintTimer(TimeSpan time)
   {
      _timerText.text = $"{time.Seconds}:{time.Milliseconds}";
   }
}
