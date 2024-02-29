using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int availableArmies;
    public List<Territory> ownedTerritories;
    public List<Continent> ownedContinents;
    public bool isPlaying;
    
    //public List<Card> heldCards;
    //To be added when card functionality is made

    public void AddArmies(int armiesAdded)
    {
        availableArmies += armiesAdded;
    }
    
    public void Attack(Territory territoryToAttack, Territory territoryAttackingFrom)
    {
        if (!territoryAttackingFrom.adjacentTerritoryList.Contains(territoryToAttack))
        {
            Debug.Log("Error: Territories not adjacent");
            return;
        }
        
        int attackingDice = 0; //Attacking dice are gotten from the number of attacking armies up to a maximum of 3
        switch (territoryAttackingFrom.currentArmyCount)
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

        Debug.Log("Attacking dice: " + attackingDice + ", Defending dice: " + defendingDice);

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
        attackingRolls.Reverse();
        defendingRolls.Sort();
        defendingRolls.Reverse();

        Debug.Log("Attacking rolls: ");
        foreach (int roll in attackingRolls)
        {
            Debug.Log(roll);
        }
        Debug.Log("Defending rolls: ");
        foreach (int roll in defendingRolls)
        {
            Debug.Log(roll);
        }

        if (attackingRolls.Count == defendingRolls.Count) //Compare all die rolls if an equal number are rolled
        {
            for (int i = 0; i < attackingRolls.Count; i++) //Increment through lists starting with highest values
            {
                if (territoryAttackingFrom.currentArmyCount != 0 && territoryToAttack.currentArmyCount != 0)
                {
                    if (attackingRolls[i] > defendingRolls[i]) 
                        territoryToAttack.currentArmyCount--;
                    else 
                        territoryAttackingFrom.currentArmyCount--;
                    Debug.Log("Comparison made");
                }
            }
        }
        else if (attackingRolls.Count > defendingRolls.Count) //If there are more attackers, every defending die roll is compared with the highest attack rolls
        {
            for (int i = 0; i < defendingRolls.Count; i++) //Increment through lists starting with highest values
            {
                if (territoryAttackingFrom.currentArmyCount != 0 && territoryToAttack.currentArmyCount != 0)
                {
                    if (attackingRolls[i] > defendingRolls[i]) 
                        territoryToAttack.currentArmyCount--;
                    else 
                        territoryAttackingFrom.currentArmyCount--;
                    Debug.Log("Comparison made");
                }
            }
        }
        else if (attackingRolls.Count < defendingRolls.Count) //If there are more defenders, every attacking roll is compared with the highest attack rolls
        {
            for (int i = 0; i < attackingRolls.Count; i++) //Increment through lists starting with highest values
            {
                if (territoryAttackingFrom.currentArmyCount != 0 && territoryToAttack.currentArmyCount != 0)
                {
                    if (attackingRolls[i] > defendingRolls[i]) 
                        territoryToAttack.currentArmyCount--;
                    else 
                        territoryAttackingFrom.currentArmyCount--;
                    Debug.Log("Comparison made");
                }
            }
        }

        Debug.Log("Remaining armies in " + territoryAttackingFrom.name + ": " + territoryAttackingFrom.currentArmyCount);
        Debug.Log("Armies remaining in " + territoryToAttack.name + ": " + territoryToAttack.currentArmyCount);
    }

    public void Fortify(int armiesAdded, Territory territoryToFortify)
    {
        if (armiesAdded > availableArmies)
        {
            Debug.Log("Player does not have enough armies to fortify");
            return;
        }
        
        territoryToFortify.currentArmyCount += armiesAdded;
        availableArmies -= armiesAdded;
        Debug.Log(territoryToFortify.name + " has been fortified with " + armiesAdded + " armies");
    }

    public void Reinforce(Territory territoryGiving, Territory territoryTaking, int armiesMoving)
    {
        if (armiesMoving > territoryGiving.currentArmyCount - 1)
        {
            Debug.Log("Territory cannot give up that many armies");
            return;
        }
        
        territoryGiving.currentArmyCount -= armiesMoving;
        territoryTaking.currentArmyCount += armiesMoving;
        Debug.Log(territoryTaking.name + " has been reinforced with " + armiesMoving + " armies");
    }

    private int RollDice()
    {
        return Random.Range(1, 6);
    }
}
