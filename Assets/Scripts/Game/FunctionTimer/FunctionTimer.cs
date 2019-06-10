using System;
using UnityEngine;

public class FunctionTimer : MonoBehaviour
{
    public event Action CallOnTimerEnd;

    public TimeSpan GetHowManyTime => _lastTime.Subtract(DateTime.Now);
    
    public bool IsTimerStart => _isTimerStart;

    private DateTime _lastTime;
    private bool _isTimerStart;
    
    public void TimerStart(float time)
    {
        _lastTime = DateTime.Now.AddSeconds(time);
        _isTimerStart = true;
    }

    public void AddSecondsToTimer(float time)
    {
        if (_isTimerStart)
        {
            _lastTime = _lastTime.AddSeconds(time);
        }
    }
    
    private void Update()
    {
        if (_isTimerStart)
        {
            if (DateTime.Now >= _lastTime)
            {
                _isTimerStart = false;
                CallOnTimerEnd?.Invoke();
            }
        }
    }
}
