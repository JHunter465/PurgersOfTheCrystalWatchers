using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCombat RPlayerCombat;
    public PlayerMovement RPlayerMovement;
    public PlayerEntity RPlayerEntity;

    [HideInInspector] public bool Attacking;

    private void Awake()
    {
        RPlayerCombat = GetComponent<PlayerCombat>();
        RPlayerMovement = GetComponent<PlayerMovement>();
        RPlayerEntity = GetComponent<PlayerEntity>();
    }
}
