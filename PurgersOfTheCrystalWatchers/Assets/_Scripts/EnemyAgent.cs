using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using POTCW;

public class EnemyAgent : MonoBehaviour
{
    EnemyBlackBoard board = new EnemyBlackBoard();

    private void Awake()
    {
        //Get animator controller
        if (GetComponent<Animator>() != null)
            board.AnimatorController = GetComponent<Animator>();

        Globals.BossBlackBoard = board;

        Debug.Log("EnemyAgentAwake" + board.AnimatorController);
    }

    private void Start()
    {
        //Create AIs
        var tree = new MyBehaviourTree();

        // Call start to actually run the AI.
        // The first argument is the MonoBehaviour the tree attaches to and depends on (like a coroutine), 
        // the second is the agent to control
        tree.Start(this, this);        
    }
}
