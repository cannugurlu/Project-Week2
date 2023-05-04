using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundManager : MonoBehaviour
{
    public bool key2;
    private GameObject[] kutular1;
    int controllerInteger=0;
    void Start()
    {
        solgunlastir();
        kutular1 = GameObject.FindGameObjectsWithTag("ground");
    }
    void Update()
    {
        key2 = gameManager.key;
    }

    private void OnMouseDown()
    {
        if (!key2)
        {
            rengiduzelt();
            
            gameManager.key = true;
        }
    }
    private void OnMouseEnter()
    {
        if (key2)
        {
            rengiduzelt();
        }
    }

    private void OnMouseUp()
    {
        gameManager.key = false;

    }
    public void solgunlastir()
    {
        if (controllerInteger == 0)
        {
            Material[] materials = gameObject.GetComponent<Renderer>().materials;
            foreach (Material material in materials)
            {
                Color color = material.color;
                color.r *= 0.65f;
                color.g *= 0.65f;
                color.b *= 0.65f;
                material.color = color;
            }
            controllerInteger++;
        }
    }
    public void rengiduzelt()
    {
        if (controllerInteger == 1)
        {
            Material[] materials = gameObject.GetComponent<Renderer>().materials;
            foreach (Material material in materials)
            {
                Color color = material.color;
                color.r *= 1.53846f;
                color.g *= 1.53846f;
                color.b *= 1.53846f;
                material.color = color;
            }
            controllerInteger--;
        }
    }
}
