using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundManager : MonoBehaviour
{
    public bool key2;
    private GameObject[] kutular1;
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
        Material[] materials = gameObject.GetComponent<Renderer>().materials;
        foreach(Material material in materials)
        {
            Color color = material.color;
            color.r *= 0.65f;
            color.g *= 0.65f;
            color.b *= 0.65f;
            material.color = color;
        }
    }
    public void rengiduzelt()
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
    }
}
