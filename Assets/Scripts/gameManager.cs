using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI roadText,timeText;
    public static bool key = false;
    public static int howManyRoad=4;
    int time=20;

    private void Start()
    {
        InvokeRepeating("zamanazalt", 0.0f, 1.0f);
    }
    private void Update()
    {
        roadText.text = howManyRoad.ToString();
        timeText.text = time.ToString();
    }

    void zamanazalt()
    {
        if (time >= 0)
        {
            time--;
        }
    }
}