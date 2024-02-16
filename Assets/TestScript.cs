using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        Territory alaska = new Territory("Alaska", 0);
        Territory northWestTerritory = new Territory("North West Territory", 0);
        Territory alberta = new Territory("Alberta", 0);
        Territory greenland = new Territory("Greenland", 0);
        Territory ontario = new Territory("Ontario", 0);
        Territory quebec = new Territory("Quebec", 0);
        Territory westernUnitedStates = new Territory("Western United States", 0);
        Territory easternUnitedStates = new Territory("Eastern United States", 0);
        Territory centralAmerica = new Territory("Central America", 0);

        alaska.adjacentTerritoryList = new List<Territory> { northWestTerritory, alberta };
        northWestTerritory.adjacentTerritoryList = new List<Territory> { alaska, alberta, ontario, greenland };
        alberta.adjacentTerritoryList = new List<Territory> { alaska, northWestTerritory, ontario, westernUnitedStates };
        greenland.adjacentTerritoryList = new List<Territory> { northWestTerritory, ontario, quebec }; //Add Iceland when made
        ontario.adjacentTerritoryList = new List<Territory> { quebec, easternUnitedStates, westernUnitedStates, alberta, northWestTerritory, greenland };
        quebec.adjacentTerritoryList = new List<Territory> { greenland, ontario, easternUnitedStates };
        westernUnitedStates.adjacentTerritoryList = new List<Territory> { alberta, ontario, easternUnitedStates, centralAmerica };
        easternUnitedStates.adjacentTerritoryList = new List<Territory> { westernUnitedStates, centralAmerica, ontario, quebec };
        centralAmerica.adjacentTerritoryList = new List<Territory> { westernUnitedStates, easternUnitedStates }; //Add Venezuela when made

        Continent northAmerica = new Continent(5, new List<Territory> { alaska, northWestTerritory, alberta, greenland, ontario, quebec, westernUnitedStates, easternUnitedStates, centralAmerica });

        Debug.Log("Territories in North America:");
        for (int i = 0; i < northAmerica.territories.Count; i++)
        {
            Debug.Log(northAmerica.territories[i].name);
        }

        Debug.Log("Adjacent territories to Ontario:");
        for (int i = 0; i < ontario.adjacentTerritoryList.Count; i++)
        {
            Debug.Log(ontario.adjacentTerritoryList[i].name);
        }
    }
}
