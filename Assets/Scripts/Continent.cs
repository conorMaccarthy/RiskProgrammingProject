using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent
{
    public int armiesGiven;
    public List<Territory> territories;

    public Continent(int initArmiesGiven, List<Territory> initTerritories)
    {
        armiesGiven = initArmiesGiven;
        territories = initTerritories;
    }
}
