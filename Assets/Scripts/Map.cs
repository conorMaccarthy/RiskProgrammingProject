using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Map:MonoBehaviour //for unity visuals, I need some functions.
{
    [SerializeField]
    GameObject drawnLinePrefab;

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
                    var tempSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    tempSphere.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    drawPool.Add(tempSphere);
                    var gO = drawPool[objectCount - 1];
                    gO.transform.position = new Vector3(ter.xOffset,ter.yOffset, 1.25f);
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
        Territory current;
        Territory target;
        int indexContinent= -1;
        do
        {
            current = null;
            target = null;
            store = sR.ReadLine();
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
                else if (peices.Length >= 3)
                {
                    continents[indexContinent].territories.Add(new Territory(peices[0], "Unowned", float.Parse(peices[1]), float.Parse(peices[2])));
                    current = continents[indexContinent].territories[continents[indexContinent].territories.Count - 1];
                    if (peices.Length > 3)
                    {
                        for (int i = 3; i < peices.Length; i++) //for every connection
                        {
                            target = FindTerritory(peices[i]);
                            Debug.Log("ReadMap, Develop line from" + current.name + " to " + target.name);
                            DrawLine(current, target);
                            current.adjacentTerritoryList.Add(target);
                            target.adjacentTerritoryList.Add(current);
                        }
                    }

                }
            }
        } while (store != null);
        Debug.Log("Finished Reading File");
        sR.Close();
    }

    Territory FindTerritory(string targetName)
    {
        for (int contCount = 0; contCount < continents.Count; contCount++) //seach each continent
        {
            for (int terr = 0; terr < continents[contCount].territories.Count; terr++)
            {
                if (continents[contCount].territories[terr].name == targetName)
                    return continents[contCount].territories[terr];
            }
        }

        Debug.Log("That Territory is not found");
        return null;
    }

    public void DrawLine(Territory start, Territory end)
    {
        GameObject newLine = Instantiate(drawnLinePrefab, Vector2.zero, Quaternion.identity);
        newLine.GetComponent<LineRenderer>().SetPosition(0, new Vector3(start.xOffset, start.yOffset,1.1f));
        newLine.GetComponent<LineRenderer>().SetPosition(1, new Vector3(end.xOffset, end.yOffset,1.1f));
        
    }
}
