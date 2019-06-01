using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;
    public string message = "Время вышло!";
    // Start is called before the first frame update
    public float timer = 0;
    public int max = 10;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = (max - timer).ToString("#.");

        if (text.text == "0")
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
        }
    }
}
