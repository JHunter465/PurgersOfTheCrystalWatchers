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

        protected BlackBoard Blackboard;       
        protected BaseNode behaviourTreeStage1;
        protected BaseNode behaviourTreeStage2;
        protected BaseNode behavoiurTreeStage3;
        protected BaseNode activeBehaviourTree;

        private void Start()
        {
            behaviourTreeStage1 = new SequenceNode(Blackboard,
                new JumpNode(Blackboard),
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