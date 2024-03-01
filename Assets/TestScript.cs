using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Map>().ReadMapFile();
        Territory alaska = GetComponent<Map>().continents[0].territories[0];
        Territory t2 = GetComponent<Map>().continents[0].territories[1];
        //Territory northWestTerritory = new Territory("North West Territory", "Player1", 0);
        //Territory alberta = new Territory("Alberta", "Player1", 0);
        //Territory greenland = new Territory("Greenland", "Player1", 0);
        //Territory ontario = new Territory("Ontario", "Player2", 0);
        //Territory quebec = new Territory("Quebec", "Player1", 0);
        //Territory westernUnitedStates = new Territory("Western United States", "Player1", 0);
        //Territory easternUnitedStates = new Territory("Eastern United States", "Player3", 0);
        //Territory centralAmerica = new Territory("Central America", "Player4", 0);

        //alberta.player = "Player1";
        //northWestTerritory.player = "Player1";
        alaska.player = "Player1";
        t2.player = "Player3";
        //greenland.player = "Player1";
        //ontario.player = "Player2";
        //quebec.player = "Player1";
        //westernUnitedStates.player = "Player1";
        //easternUnitedStates.player = "Player3";
        //centralAmerica.player = "Player 4";
        

        //alaska.adjacentTerritoryList = new List<Territory> { northWestTerritory, alberta };
        //northWestTerritory.adjacentTerritoryList = new List<Territory> { alaska, alberta, ontario, greenland };
        //alberta.adjacentTerritoryList = new List<Territory> { alaska, northWestTerritory, ontario, westernUnitedStates };
        //greenland.adjacentTerritoryList = new List<Territory> { northWestTerritory, ontario, quebec }; //Add Iceland when made
        //ontario.adjacentTerritoryList = new List<Territory> { quebec, easternUnitedStates, westernUnitedStates, alberta, northWestTerritory, greenland };
        //quebec.adjacentTerritoryList = new List<Territory> { greenland, ontario, easternUnitedStates };
        //westernUnitedStates.adjacentTerritoryList = new List<Territory> { alberta, ontario, easternUnitedStates, centralAmerica };
        //easternUnitedStates.adjacentTerritoryList = new List<Territory> { westernUnitedStates, centralAmerica, ontario, quebec };
        //centralAmerica.adjacentTerritoryList = new List<Territory> { westernUnitedStates, easternUnitedStates }; //Add Venezuela when made

        Player player = new Player();
        player.playerName = "Player1";


        GetComponent<Map>().DrawMap();

        /*          
                Continent northAmerica = new Continent("North America", 5, new List<Territory> { alaska, northWestTerritory, alberta, greenland, ontario, quebec, westernUnitedStates, easternUnitedStates, centralAmerica });

                //Debug.Log("Territories in North America:");
                for (int i = 0; i < northAmerica.territories.Count; i++)
                {
                    //Debug.Log(northAmerica.territories[i].name);
                }

                //Debug.Log("Adjacent territories to Ontario:");
                for (int i = 0; i < ontario.adjacentTerritoryList.Count; i++)
                {
                    //Debug.Log(ontario.adjacentTerritoryList[i].name);
                }



                player.availableArmies = 10;
                player.ownedTerritories = new List<Territory> { alberta, greenland, ontario };

                alberta.currentArmyCount = 4;
                westernUnitedStates.currentArmyCount = 2;



                player.Attack(westernUnitedStates, alberta);

                Debug.Log(player.AreTerritoriesConnected(alberta, quebec, player.playerName));
        */


    }
}
