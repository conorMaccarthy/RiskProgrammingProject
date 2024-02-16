using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Territory
{
    public string name;
    public int currentArmyCount;
    public List<Territory> adjacentTerritoryList; //This list does not appear in the constructor, rather it is initialized shortly after all the Territories have been made

    public Territory(string initName, int initArmyCount)
    {
        name = initName;
        currentArmyCount = initArmyCount;
    }

    public void Attack(Territory territoryToAttack)
    {
        int attackingDice = 0; //Attacking dice are gotten from the number of attacking armies up to a maximum of 3
        switch (currentArmyCount)
        {
            case 0:
            case 1:
                Debug.Log("Not enough armies to attack");
                return;
            case 2:
                attackingDice = 1;
                break;
            case 3:
                attackingDice = 2;
                break;
            default: //4 or more current armies
                attackingDice = 3;
                break;
        }

        int defendingDice = 0; //Defending dice are gotten from the number of defending armies up to a maximum of 2
        if (territoryToAttack.currentArmyCount == 1) defendingDice = 1;
        else if (territoryToAttack.currentArmyCount >= 1) defendingDice = 2;

        List<int> attackingRolls = new List<int>();
        for (int i = 0; i < attackingDice; i++)
        {
            attackingRolls.Add(RollDice()); //Get a list of random ints from 1-6 for each die rolled
        }

        List<int> defendingRolls = new List<int>();
        for (int i = 0; i < defendingDice; i++)
        {
            defendingRolls.Add(RollDice()); //Get a list of random ints from 1-6 for each die rolled
        }

        attackingRolls.Sort(); //Both lists are sorted so the highest rolls can be compared to each other
        defendingRolls.Sort();

        if (attackingRolls.Count == defendingRolls.Count) //Compare all die rolls if an equal number are rolled
        {
            for (int i = attackingRolls.Count; i > 0; i--) //Increment through lists starting with highest values
            {
                if (attackingRolls[i] > defendingRolls[i]) territoryToAttack.currentArmyCount--;
                else currentArmyCount--;
            }
        }
        else if (attackingRolls.Count > defendingRolls.Count) //If there are more attackers, every defending die roll is compared with the highest attack rolls
        {
            for (int i = defendingRolls.Count; i > 0; i--) //Increment through lists starting with highest values
            {
                if (attackingRolls[i] > defendingRolls[i]) territoryToAttack.currentArmyCount--;
                else currentArmyCount--;
            }
        }
        else if (attackingRolls.Count < defendingRolls.Count) //If there are more defenders, every attacking roll is compared with the highest attack rolls
        {
            for (int i = attackingRolls.Count; i > 0; i--) //Increment through lists starting with highest values
            {
                if (attackingRolls[i] > defendingRolls[i]) territoryToAttack.currentArmyCount--;
                else currentArmyCount--;
            }
        }
    }

    public void Fortify(int armiesAdded)
    {
        currentArmyCount += armiesAdded;
    }

    private int RollDice()
    {
        return Random.Range(1, 6);
    }
}
