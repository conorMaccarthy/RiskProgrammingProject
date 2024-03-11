using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Territory
{
    public string name;
    public string player = "";
    public int currentArmyCount;
    public List<Territory> adjacentTerritoryList; //This list does not appear in the constructor, rather it is initialized shortly after all the Territories have been made

    public float xOffset;
    public float yOffset;

    public Territory(string initName, string initPlayer, int initArmyCount)
    {
        name = initName;
        player = initPlayer;
        currentArmyCount = initArmyCount;
        adjacentTerritoryList = new List<Territory>();
    }
    public Territory(string initName, string initPlayer, float initXOffset, float initYOffset)
    {
        name = initName;
        player = initPlayer;
        xOffset = initXOffset;
        yOffset = initYOffset;
        adjacentTerritoryList = new List<Territory>();
    }

}
