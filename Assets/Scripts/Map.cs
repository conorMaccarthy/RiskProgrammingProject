using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Map:MonoBehaviour //for unity visuals, I need some functions.
{
    public List<Continent> continents = new List<Continent>(); //This value is initialized after all the continents have been initialized


    List<GameObject> drawPool = new List<GameObject>(); //barely functions as an actual object pool, but wtvr.
    public void DrawMap()
    {
        foreach (GameObject g in drawPool)
            Destroy(this.gameObject);




        int objectCount= 0;
        foreach(Continent c in continents)
        {
            foreach (Territory ter in c.territories)
            {
                objectCount++;
                if (drawPool.Count < objectCount)
                {
                    drawPool.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
                    var gO = drawPool[objectCount - 1];
                    Debug.Log("Primitive Created");
                    Debug.Log(gO.name);
                    gO.transform.position = new Vector2(ter.xOffset,ter.yOffset);
                    switch (ter.player)
                    {
                        case "Player1":
                            drawPool[objectCount - 1].GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                            break;
                        case "Player2":
                            drawPool[objectCount - 1].GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                            break;
                        case "Player3":
                            drawPool[objectCount - 1].GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
                            break;
                        case "Player4":
                            drawPool[objectCount - 1].GetComponent<Renderer>().material.color = new Color(1, 1, 0, 1);
                            break;
                        case "Unowned":
                            drawPool[objectCount - 1].GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
                            break;
                    }
                }
            }
        }
    }

    public void ReadMapFile()
    {
        StreamReader sR = new StreamReader("Assets/TerritoryFile.txt");
        string store= null;
        int indexContinent= -1;
        do
        {
            Debug.Log("Next line");
            store = sR.ReadLine();
            Debug.Log(store);
            if (store != null)
            {
                string[] peices = store.Split(',');
                if (peices.Length == 2)
                {
                    indexContinent++;
                    Debug.Log(peices[0]);
                    Debug.Log(peices[1]);
                    continents.Add(new Continent(peices[0], int.Parse(peices[1])));
                }
                else if (peices.Length == 3)
                {
                    continents[indexContinent].territories.Add(new Territory(peices[0], "Unowned", float.Parse(peices[1]), float.Parse(peices[2])));
                }
            }
        } while (store != null);
        Debug.Log("Finished Reading File");
        sR.Close();
    }
}
