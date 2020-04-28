using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using POTCW;

public class MyBehaviourTree : BehaviourTree<EnemyAgent>
{
    protected override BehaviourNode<EnemyAgent> GetRootNode()
    {
        return new SequenceNode<EnemyAgent>(
            new AttackNode(Globals.BossBlackBoard),
            new LeapNode(Globals.BossBlackBoard),
            new SummonNode(Globals.BossBlackBoard));
    }
}
