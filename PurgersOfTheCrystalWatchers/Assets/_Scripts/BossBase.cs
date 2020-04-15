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

        protected BlackBoard Blackboard = new BlackBoard();       
        protected BaseNode behaviourTreeStage1;
        protected BaseNode behaviourTreeStage2;
        protected BaseNode behavoiurTreeStage3;
        protected BaseNode activeBehaviourTree;
        protected Animator animatorController;

        private void Start()
        {
            if (animatorController == null)
                animatorController = GetComponent<Animator>();

            //Blackboard.AnimationController = animatorController;
            Blackboard.Boss = this;

            behaviourTreeStage1 = new SequenceNode(Blackboard,
                new JumpNode(Blackboard, Globals.BOSS_JUMP_ANIMATORBOOL),
                new SlashAttackNode(Blackboard),
                new ShieldSlamNode(Blackboard));

            activeBehaviourTree = behaviourTreeStage1;
        }

        private void FixedUpdate()
        {
            activeBehaviourTree.Tick();
        }
    }
}