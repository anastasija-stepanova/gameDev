using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameModel _gameModel;
    
    public void NextQuestion()
    {
         _gameModel.NextQuestion();
    }

    public void EndGame()
    {
        _gameModel.enabled = false;
        this.enabled = false;
    }
}
