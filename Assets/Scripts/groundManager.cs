using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundManager : MonoBehaviour
{
    public bool key2;
    private GameObject[] kutular1;
    private GameObject[] allObjects;
    public int controllerInteger=0;
    float kupposx,kupposz;
    void Start()
    {
        solgunlastir();
        kutular1 = GameObject.FindGameObjectsWithTag("ground");
        allObjects = FindObjectsOfType<GameObject>();
    }
    void Update()
    {
        key2 = gameManager.key;
    }

    private void OnMouseDown()
    {
        if (!key2)
        {
            rengiduzelt(gameObject);
            kupposx = gameObject.transform.position.x;
            kupposz = gameObject.transform.position.z;
            foreach (GameObject otherCubes in kutular1)
            {
                if (otherCubes.transform.position.x == kupposx + 2 && otherCubes.transform.position.z == kupposz)
                {
                    rengiduzelt(otherCubes);
                }
                if (otherCubes.transform.position.x == kupposx - 2 && otherCubes.transform.position.z == kupposz)
                {
                    rengiduzelt(otherCubes);
                }
                if (otherCubes.transform.position.x == kupposx && otherCubes.transform.position.z == kupposz + 2)
                {
                    rengiduzelt(otherCubes);
                }
                if (otherCubes.transform.position.x == kupposx && otherCubes.transform.position.z == kupposz - 2)
                {
                    rengiduzelt(otherCubes);
                }
            }
            gameManager.key = true;
        }
    }
    private void OnMouseEnter()
    {
        if (key2)
        {
            rengiduzelt(gameObject);
            kupposx = gameObject.transform.position.x;
            kupposz = gameObject.transform.position.z;
            foreach (GameObject otherCubes in kutular1)
            {
                if (otherCubes.transform.position.x == kupposx + 2 && otherCubes.transform.position.z == kupposz)
                {
                    rengiduzelt(otherCubes);
                }
                if (otherCubes.transform.position.x == kupposx - 2 && otherCubes.transform.position.z == kupposz)
                {
                    rengiduzelt(otherCubes);
                }
                if (otherCubes.transform.position.x == kupposx && otherCubes.transform.position.z == kupposz + 2)
                {
                    rengiduzelt(otherCubes);
                }
                if (otherCubes.transform.position.x == kupposx && otherCubes.transform.position.z == kupposz - 2)
                {
                    rengiduzelt(otherCubes);
                }
            }
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
    public void rengiduzelt(GameObject X)
    {
        if (controllerInteger == 1)
        {
            Material[] materials = X.GetComponent<Renderer>().materials;
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
