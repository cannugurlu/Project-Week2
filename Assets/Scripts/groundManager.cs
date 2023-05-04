using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class groundManager : MonoBehaviour
{
    public bool key2;
    private GameObject[] kutular1,allObjects;
    int controllerInteger = 0;
    public bool isClicked;
    Camera cam;
    void Start()
    {
        allObjects = FindObjectsOfType<GameObject>();
        cam = Camera.main;
            solgunlastir();
        kutular1 = GameObject.FindGameObjectsWithTag("ground");
        foreach (var item in allObjects)
        {
            if (item.CompareTag("house") || item.CompareTag("engel"))
            {
                solgunlastir();
            }
        }
    }
    void Update()
    {
        key2 = gameManager.key;
        print(gameManager.howManyRoad);
    }

    private void OnMouseDown()
    {
        string a = transform.name;

        if (!key2)
        {
            rengiduzelt();
            etrafiniaydinlat2(a);

            gameManager.key = true;
        }
    }
    private void OnMouseEnter()
    {
        string a = transform.name;
        Debug.Log(a);

        if (key2)
        {
            rengiduzelt();
            etrafiniaydinlat2(a);
        }
    }

    private void OnMouseUp()
    {
        foreach (GameObject item in allObjects)
        {
                if (item.CompareTag("ground") || item.CompareTag("house") || item.CompareTag("engel"))
                {
                if (!item.GetComponent<groundManager>().isClicked)
                {
                    Color color = item.GetComponent<Renderer>().material.color;
                    color.r *= 0.65f;
                    color.g *= 0.65f;
                    color.b *= 0.65f;
                    item.GetComponent<Renderer>().material.color=color;
                }
            }
        }
        gameManager.key = false;
        SceneManager.LoadScene(0);

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
            isClicked = true;
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
            isClicked = false;
            controllerInteger--;
        }

    }
    public void etrafiniaydinlat2(string a)
    {
        foreach (GameObject kutu in kutular1)
        {
            //print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
            if (int.Parse(kutu.transform.name) == int.Parse(a) + 1 && int.Parse(a) % 5 != 0)
            {
                print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
                etrafaydinlat(kutu);
                if (kutu.transform.childCount > 0)
                {
                    GameObject ev = kutu.transform.GetChild(0).gameObject;
                    etrafaydinlat(ev);
                }

            }
            if (int.Parse(kutu.transform.name) == int.Parse(a) + 5)
            {
                print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
                etrafaydinlat(kutu);
                if (kutu.transform.childCount > 0)
                {
                    GameObject ev = kutu.transform.GetChild(0).gameObject;
                    etrafaydinlat(ev);
                }

            }
            if (int.Parse(kutu.transform.name) == int.Parse(a) - 5)
            {
                print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
                etrafaydinlat(kutu);
                if (kutu.transform.childCount > 0)
                {
                    GameObject ev = kutu.transform.GetChild(0).gameObject;
                    etrafaydinlat(ev);
                }

            }
            if (int.Parse(kutu.transform.name) == int.Parse(a) - 1 && int.Parse(a) % 5 != 1)
            {
                print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
                etrafaydinlat(kutu);
                if (kutu.transform.childCount > 0)
                {
                    GameObject ev = kutu.transform.GetChild(0).gameObject;
                    etrafaydinlat(ev);
                }

            }

        }
    }
    public void keysettrue()
    {

        gameManager.key = true;
    }
    public void etrafaydinlat(GameObject kutu)
    {
        kutu.GetComponent<groundManager>().keysettrue();
        kutu.GetComponent<groundManager>().rengiduzelt();
    }
}


