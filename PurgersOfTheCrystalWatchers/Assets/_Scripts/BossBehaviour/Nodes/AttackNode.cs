using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using POTCW;
using UnityEngine.Timers;

public class AttackNode : BehaviourNode<EnemyAgent>
{
    private float count = 0;
    EnemyBlackBoard board;
    private bool check = false;

    public AttackNode(EnemyBlackBoard board)
    {

        this.board = board;
    }

    //Called when the node is entered
    public override State Start()
    {
        AnimatorClipInfo[] currentClipInfo;
        currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);

        TimerManager.Instance.AddTimer(()=>{ check = !check; }, currentClipInfo[0].clip.length);

        /*
        if (board.AnimatorController.GetBool(Globals.BOSS_SUMMON_ANIMATORBOOL))
        {
            Debug.Log("Oke set summon to false");
            board.AnimatorController.SetBool(Globals.BOSS_SUMMON_ANIMATORBOOL, false);
        }
        if (!board.AnimatorController.GetBool(Globals.BOSS_FIRING_ANIMATORBOOL))
        {
            Debug.Log("Oke let's set firing to true");
            board.AnimatorController.SetBool(Globals.BOSS_FIRING_ANIMATORBOOL, true);
        }*/

        board.AnimatorController.SetTrigger(Globals.BOSS_FIRING_ANIMATORBOOL);

        //DEZE WORDT 1 KEER AANGEROEPEN
        Debug.Log("Start Attack");

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
