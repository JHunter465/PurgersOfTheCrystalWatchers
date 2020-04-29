using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using POTCW;
using UnityEngine.Timers;

public class LeapNode : BehaviourNode<EnemyAgent>
{

    EnemyBlackBoard board;
    private bool check = false;

    public LeapNode(EnemyBlackBoard board)
    {
        this.board = board;
    }

    //Called when the node is entered
    public override State Start()
    {
        AnimatorClipInfo[] currentClipInfo;
        currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
        TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

        board.AnimatorController.SetTrigger(Globals.BOSS_LEAPING_ANIMATORBOOL);

        Debug.Log("Start Leap");
        return State.IN_PROGRESS;
    }

    //Called everey frame while the node is active
    public override State Update()
    {
        if (check)
            return State.SUCCESS;
        else
            return State.IN_PROGRESS;
    }
}
