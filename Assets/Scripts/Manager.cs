using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Manager : MonoBehaviour
{
    private int playerCount;
    
    Player[] player;

    void Start()
    {
        //For 3 players, Army count is 35, 4 players 30, 5 players 25
        playerCount = 3; //For now, will implement button to adjust this

        GetComponent<Map>().ReadMapFile();



        Player player = new Player();
        player.playerName = "Player1";

        GetComponent<Map>().DrawMap();
    }

    //Assign Active Players
    void PlayerAssignment()
    {
        player = new Player[playerCount];
        for (int i = 0; i <= playerCount; i++)
        {
            player[i].playerName = $"Player{i + 1}";
            player[i].isPlaying = true;
        }

        //Logic for adding territory to 
    }
    

    //Cycle through the turns of active player count
    void PlayerTurn()
    {

        player = new Player[playerCount];
        for (int i = 0; i <= playerCount; i++)
        {
            //Print player[i] name, declare their turn, currently just debug, will switch to text box soon
            Debug.Log($"{player[i].playerName} Turn");


            int newRoundAdd = Mathf.FloorToInt(player[i].ownedTerritories.Count / 3);
            player[i].AddArmies(newRoundAdd);

            //player[i] Reinforce (Current logic is in the Fortify function), player selects a territory to reinforce and the amount to add
            
            Territory rTerritory = GetComponent<Map>().continents[0].territories[0]; //Will take the territory that the player selects, currently defaults to first, and reinforce it
            do
            {
                //clicks a territory to reinforce
                player[i].Fortify(1, rTerritory);
                newRoundAdd--;

            } while (newRoundAdd > 0);
            

            //player[i] Attack clicks a territory to attack and a territory to defend, 
            Territory attacker = GetComponent<Map>().continents[0].territories[0];
            Territory defender = GetComponent<Map>().continents[0].territories[1];
            player[i].Attack(attacker, defender);

            //player[i] Fortify (Current logic is in the Reinforce function)
            
        }
    }

    //Check that players have not been eliminated
    void RemainingPlayers()
    {

    }

    void Update()
    {
        
    }
}
