﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPatrolState : IMonsterState {

    private MonsterAI monster;

    public MonsterPatrolState(MonsterAI monsterAI)
    {
        monster = monsterAI;
    }

    public void UpdateState()
    {

        

        if (monster.TargetIsVisible())
        {
            ToMonsterChaseState();
            return;
        }

        if (monster.patrolNodes.Count <= 0)
        {
            Debug.Log("Error: Nowhere to patrol.");
            return;
        }

        

        //Once we're close enough to a patrol point, we go to the next
        if ((monster.transform.position - monster.patrolNodes[monster.currentNode]).magnitude < monster.agent.stoppingDistance)
        {
            monster.currentNode++;
            if (monster.currentNode >= monster.patrolNodes.Count)
                monster.currentNode = 0;

            monster.agent.destination = new Vector3(monster.patrolNodes[monster.currentNode].x, monster.proxyLocation.position.y, monster.patrolNodes[monster.currentNode].y);
        }

        
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        //If we encounter a distraction, we exit our previous state,
        //no matter what that state was, and go to the Distraction state
        if (other.tag == "Distraction")
        {
            ToMonsterDistractionState(other);
            return;
        }

        //If we encounter the player, the game should reset. Nothing for now.
        if (other.tag == "Player")
        {
            //TODO reset game.
            Debug.Log("Player caught");
        }
    }*/

    #region State Transitions
    public void ToMonsterPatrolState()
    {
        //Cannot transition- already in patrol state
        Debug.Log("Transition Error: Already in patrol state.");
    }

    public void ToMonsterChaseState()
    {
        monster.currentState = monster.monsterChaseState;
    }

    public void ToMonsterSearchState()
    {

        if (monster.targetLocation != null)
        {
            monster.searchPosition = new Vector3(monster.targetLocation.position.x, monster.targetLocation.position.y, 0f);

            monster.monsterSearchState.currentSubState = MonsterSearchState.SearchingSubState.CheckingLastPosition; //TODO verify this works
            monster.currentState = monster.monsterSearchState;
        } else
        {
            Debug.Log("Player disabled, transitioning to patrol state.");
        }

        
    }

    public void ToMonsterDistractionState(Collider2D other)
    {
        monster.distractionTime = 0f;
        monster.currentState = monster.monsterDistractionState;
        monster.agent.destination = new Vector3(other.GetComponent<Transform>().position.x, monster.proxyLocation.position.y, other.GetComponent<Transform>().position.y);

        //Once the distraction is finished, destroy it.
        GameObject.Destroy(other.gameObject, monster.maxDistractionTime);
    }
    #endregion
}
