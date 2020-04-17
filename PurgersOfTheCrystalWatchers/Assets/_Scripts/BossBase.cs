using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class BossBase : BaseEntity
    {
        public bool Stage1 = false;
        public bool Stage2 = false;
        public bool Stage3 = false;

        public GameObject Player;

        protected BlackBoard Blackboard = new BlackBoard();       
        protected BaseNode behaviourTreeStage1;
        protected BaseNode behaviourTreeStage2;
        protected BaseNode behavoiurTreeStage3;
        protected BaseNode activeBehaviourTree;

        private void Start()
        {

            Blackboard.AnimationController = BossManager.Instance.ReturnAnimator();

            //Blackboard.AnimationController = animatorController;
            Blackboard.Boss = this;
            Blackboard.BossBody = GetComponent<Rigidbody>();
            behaviourTreeStage1 = new SequenceNode(Blackboard,
                new SlashAttackNode(Blackboard,1),
                new MineNode(Blackboard, 100, BossManager.Instance.ReturnAnimationData("Mine")),
                //new ConditionNode(Blackboard, new System.Func<bool>(() => JumpCheck()),
                new JumpNode(Blackboard, Globals.BOSS_JUMP_ANIMATORBOOL,10),               
                new ShieldSlamNode(Blackboard, 10));

            activeBehaviourTree = behaviourTreeStage1;
        }

        private bool JumpCheck()
        {
            return Physics.Raycast(transform.position, -Vector3.up, 10);
        }

        private void FixedUpdate()
        {
            activeBehaviourTree.Tick();
        }
    }
}