using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Text;
//координаты выбирать из заданных диапазонов, будет более струртурировано
//размеры тоже выбрать примеирно 5 штук

   //background белый 
using Random = UnityEngine.Random;
public class ShapesGenerator : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject inst_obj;
    public Button[] but;
    public Button button1;
    public Button button2;
    [SerializeField]
    private int[] counter = new int[2];

    public void IsCircle()
    {
       if(counter[1] > counter[0])
       {
           Debug.Log("Верно");
       }
       else
       {
           Debug.Log("Неверно");
       }
    }
    public void IsRect()
    {
        if (counter[0] > counter[1])
        {
            Debug.Log("Верно");
        }
        else
        {
            Debug.Log("Неверно");
        }
    }
    


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < counter.Length; i++)
        {
            counter[i] = 0;
        }
        for (int j = 0; j < 5; ++j)
        {
            int randomX = Random.Range(1, 320);
            int randomY = Random.Range(300, 720);
            int randScale = Random.Range(100, 150);
            int randRotation = Random.Range(100, 150);
            inst_obj = Instantiate(objects[1], new Vector2(randomX, randomY), Quaternion.identity) as GameObject;
            inst_obj.transform.localScale = new Vector3(randScale, randScale, 1);
            inst_obj.transform.rotation = Quaternion.Euler(0, 0, randRotation);
            counter[0]++;
        }

        for (int j = 0; j < 4; ++j)
        {
            int randomX = Random.Range(1, 320);
            int randomY = Random.Range(300, 720);
            int randScale = Random.Range(100, 150);
            inst_obj = Instantiate(objects[0], new Vector2(randomX, randomY), Quaternion.identity) as GameObject;
            inst_obj.transform.localScale = new Vector3(randScale, randScale, 1);
            counter[1]++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < but.Length; i++)
        {
            print(but[i]);
        }
    }

    void MixShapes()
    {

    }
}
