using System;
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
    [SerializeField] bool isRoadAdd;
    public static int roadcount;
    Camera cam;
    [SerializeField] GameObject roadprefab;
    [SerializeField] GameObject roadprefab2;
    public static GameObject[] roads = new GameObject[10];
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
      //  Debug.Log(a);

        if (key2)
        {
            rengiduzelt();
            etrafiniaydinlat2(a);
        }
    }

    private void OnMouseUp()
    {
        gameManager.key = false;
        SceneManager.LoadScene(0);

        for(int i = 0; i < 10; i++)
        {
            roads[i] = null;
        }
        roadcount = 0;
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
               // print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
                etrafaydinlat(kutu);
                if (kutu.transform.childCount > 0)
                {
                    GameObject ev = kutu.transform.GetChild(0).gameObject;
                    etrafaydinlat(ev);
                }
                YoluEkranaGetir();
            }
            if (int.Parse(kutu.transform.name) == int.Parse(a) + 5)
            {
             //   print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
                etrafaydinlat(kutu);
                if (kutu.transform.childCount > 0)
                {
                    GameObject ev = kutu.transform.GetChild(0).gameObject;
                    etrafaydinlat(ev);
                }
                YoluEkranaGetir();
            }
            if (int.Parse(kutu.transform.name) == int.Parse(a) - 5)
            {
            //    print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
                etrafaydinlat(kutu);
                if (kutu.transform.childCount > 0)
                {
                    GameObject ev = kutu.transform.GetChild(0).gameObject;
                    etrafaydinlat(ev);
                }
                YoluEkranaGetir();
            }
            if (int.Parse(kutu.transform.name) == int.Parse(a) - 1 && int.Parse(a) % 5 != 1)
            {
          //      print(int.Parse(a) + " " + int.Parse(kutu.transform.name));
                etrafaydinlat(kutu);
                if (kutu.transform.childCount > 0)
                {
                    GameObject ev = kutu.transform.GetChild(0).gameObject;
                    etrafaydinlat(ev);
                }
                YoluEkranaGetir();
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
    public void YoluEkranaGetir()
    {
        if(roadprefab != null && !isRoadAdd)
        {
            Debug.Log("Oluþturuluyor");
            GameObject road = Instantiate(roadprefab, transform.position + new Vector3(0, 0.02f, 0), transform.rotation);
            groundManager.roads[roadcount] = road;
            print(groundManager.roadcount + "count");
            if (groundManager.roadcount >= 1 && roads[groundManager.roadcount - 1] !=null)
            {
                print("dev" + groundManager.roads[roadcount].transform.position);
                Vector3 prevroad = groundManager.roads[groundManager.roadcount - 1].transform.position;
                print(prevroad);    
                if(prevroad.x - road.transform.position.x != 0 && prevroad.z - road.transform.position.z == 0)
                {
                    

                }
                else if(prevroad.z - road.transform.position.z != 0 && prevroad.x - road.transform.position.x == 0)
                {
                    road.transform.Rotate(0, 90f, 0);
                }
            }
            if(groundManager.roadcount == 1)
            {
                print("a");
                if (roads[0].transform.position.x != roads[1].transform.position.x)
                {
                    print("b");
                }
                else
                {
                    print("c");
                    roads[0].transform.Rotate(0, 90f, 0);
                }
            }
            if (groundManager.roadcount >= 2)
            {
                if (groundManager.roads[roadcount - 1].transform.rotation != groundManager.roads[roadcount].transform.rotation)
                {
                    Vector3 roadvector3 = groundManager.roads[roadcount - 1].transform.position;
                    Destroy(groundManager.roads[roadcount - 1]);
                   //  print(roadvector3 + "vectoe3");
                    GameObject roadtree = Instantiate(roadprefab2, roadvector3 + new Vector3(0, 0.02f, 0), transform.rotation);
                    groundManager.roads[roadcount - 1] = roadtree;
                    print("kmdfmkfdmk");
                    if (roads[roadcount].transform.position.x - roads[roadcount - 2].transform.position.x > 0)
                    {
                        print("d");
                        roadtree.transform.Rotate(0, 270f, 0);
                        
                    }
                    else if (roads[roadcount].transform.position.x - roads[roadcount - 2].transform.position.x < 0)
                    {
                        print("e");
                        roadtree.transform.Rotate(0, 90, 0);
                    }
                }
            }
            groundManager.roadcount++;
            isRoadAdd = true;
        }
    }
}