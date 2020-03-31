using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats mysStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        mysStats = GetComponent<CharacterStats>();
    }

    public override void Interact()

    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(mysStats);
        }
    }
}
