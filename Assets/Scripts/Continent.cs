using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent
{
    public int armiesGiven;
    public List<Territory> territories;
    public string playerOwner;


    public bool isOwned() //returns if every territory within is owned by the same player, thus making this continent owned.
    {
        foreach (Territory t in territories)
        {
            if (t.player != territories[0].player) return false;
        }


        if (playerOwner == null)
        {
            playerOwner = territories[0].player;
            //ContinentjustClaimedvisual functionality.
        }

        return true;

    }
    public Continent(int initArmiesGiven, List<Territory> initTerritories)
    {
        armiesGiven = initArmiesGiven;
        territories = initTerritories;
    }

    public string getTerritoryOwner(int index)
    {
        if (territories.Count < index)
            return territories[index].player;
        else
            return "ErrorIndexOutOfBounds"; //this could be a trycatch, but I think this can be resolved before runtime consistantly.
    }
}
