using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem current;

    void Awake()
    {
        current = this;
    }

    public event Action onEnemyKill;
    public void EnemyKill(){
        if(onEnemyKill != null){
            onEnemyKill();
        }
    }

    public event Action onPlayerDeath;
    public void PlayerDeath(){
        if(onPlayerDeath != null){
            onPlayerDeath();
        }
    }
    public event Action onPlayerSpawn;
    public void PlayerSpawn(){
        if(onPlayerDeath != null){
            onPlayerSpawn();
        }
    }

    public event Action onPlayerDamage;
    public void PlayerDamage(){
        if(onPlayerDamage != null){
            onPlayerDamage();
        }
    }
}
