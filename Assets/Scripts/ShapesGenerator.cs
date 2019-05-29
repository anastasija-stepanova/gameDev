using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

using Random = UnityEngine.Random;
public class ShapesGenerator : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject inst_obj;
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < 5; ++j)
        {
            int randomX = Random.Range(1, 320);
            int randomY = Random.Range(300, 720);
            int randScale = Random.Range(100, 150);
            int randRotation = Random.Range(100, 150);
            inst_obj = Instantiate(objects[1], new Vector2(randomX, randomY), Quaternion.identity) as GameObject;
            inst_obj.transform.localScale = new Vector3(randScale, randScale, 1);
            inst_obj.transform.localRotation = Quaternion.Euler(randRotation, randRotation, 1);
        }

        for (int j = 0; j < 5; ++j)
        {
            int randomX = Random.Range(1, 320);
            int randomY = Random.Range(300, 720);
            int randScale = Random.Range(100, 150);
            inst_obj = Instantiate(objects[0], new Vector2(randomX, randomY), Quaternion.identity) as GameObject;
            inst_obj.transform.localScale = new Vector3(randScale, randScale, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log("Space key was pressed.");

        if (Input.GetKeyUp(KeyCode.Mouse0))
            Debug.Log("Space key was released.");
    }
}
