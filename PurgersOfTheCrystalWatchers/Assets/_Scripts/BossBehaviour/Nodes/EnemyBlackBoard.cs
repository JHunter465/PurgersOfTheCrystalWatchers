using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlackBoard : BehaviourTreeBoard<EnemyAgent>
{
    //Animation Related
    public Animator AnimatorController;

    //Player Related
    public float PlayerCloseRange = 10f;
    public float PlayerFarRange = 30f;
    public float PlayerToFarRange = 50f;
    public GameObject Player;
    public GameObject SearchPlayerGameObject;

    //Minions Related
    public GameObject MinionPrefab;
    public List<Transform> MinionSpawns;

    //Projectiles Related
    public GameObject ProjectilePrefab;

    //Mode1(open terrain)
    public float ShockWaveRange = 20f;
    public float TornadoLifeTime = 10f;
}
