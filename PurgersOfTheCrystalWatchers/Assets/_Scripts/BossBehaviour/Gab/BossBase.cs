using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class BossBase : BaseEntity
    {
        [Header("Debugging")]
        public bool Stage1 = false;
        public bool Stage2 = false;
        public bool Stage3 = false;

        [Header("Player Related")]
        public float PlayerFarRange = 30f;
        public GameObject Player;
        public GameObject SearchPlayerGameObject;

        [Header("Minions Related")]
        public GameObject MinionPrefab;
        public List<Transform> MinionSpawns;

        [Header("Projectile Related")]
        public Rigidbody ProjectilePrefab;

        /// <summary>
        /// Blackboard contains all data used for the behaviourtree
        /// </summary>
        protected BlackBoard Blackboard = new BlackBoard();  
        
        protected BaseNode behaviourTreeStage1;
        protected BaseNode behaviourTreeStage2;
        protected BaseNode behavoiurTreeStage3;
        protected BaseNode activeBehaviourTree;

        /// <summary>
        /// This tree contains all active behaviour the boss has acces to at all times
        /// </summary>
        protected BaseNode alwaysActiveTree;

        private void InitializeTree()
        {
           
        }

        private void Start()
        {
            /*
            Blackboard.Boss = this;
            Blackboard.AnimationController = GetComponent<Animator>();
            Blackboard.Player = Player;
            Blackboard.ProjectilePrefab = ProjectilePrefab;
            Blackboard.MinionPrefab = MinionPrefab;

            Transform[] minionSpawnPositions = MinionSpawns.ToArray();

            behaviourTreeStage1 = new RepeaterNode(Blackboard,
               new SequenceNode(Blackboard,
                   new LeapAtPlayerNode(Blackboard, Globals.BOSS_FIRING_ANIMATORBOOL, Globals.BOSS_LEAPING_ANIMATORBOOL),
                   new SummonMinionsNode(Blackboard, Globals.BOSS_LEAPING_ANIMATORBOOL, Globals.BOSS_SUMMON_ANIMATORBOOL, minionSpawnPositions),
                   new JabLegNode(Blackboard, Globals.BOSS_SUMMON_ANIMATORBOOL, Globals.BOSS_FIRING_ANIMATORBOOL)));
            //This is the base behaviour tree of the boss, 
            //These are the things he should always do no matter the enivronment
            //We need to add the different modes with each there own movement sett
            //We need some sort of "mode holder" what we can easily change to give different moveset
            alwaysActiveTree = new SequenceNode(Blackboard,
                    new ConditionNode(Blackboard, new System.Func<bool>(()=>RangeCheck()),
                        //new PlayerFarNode(Blackboard,
                            new ConditionNode(Blackboard, new System.Func<bool>(()=>FireCheck()),
                             new FireProjectileNode(Blackboard)),
                            new LeapAtPlayerNode(Blackboard, Globals.BOSS_FIRING_ANIMATORBOOL, Globals.BOSS_LEAPING_ANIMATORBOOL),
                            new ConditionNode(Blackboard, new System.Func<bool>(()=>SummonCheck()),
                                new SummonMinionsNode(Blackboard, Globals.BOSS_LEAPING_ANIMATORBOOL, Globals.BOSS_SUMMON_ANIMATORBOOL, minionSpawnPositions))),
                    //new ConditionNode(Blackboard, new System.Func<bool>(()=>RangeCheck()), 
                        new JabLegNode(Blackboard, Globals.BOSS_SUMMON_ANIMATORBOOL, Globals.BOSS_FIRING_ANIMATORBOOL));

           
            //Blackboard.AnimationController = animatorController;
            Blackboard.BossBody = GetComponent<Rigidbody>();
            /*
            behaviourTreeStage1 = new SequenceNode(Blackboard,
                new SlashAttackNode(Blackboard, BossManager.Instance.ReturnAnimationData("Mine")),
                new MineNode(Blackboard, 100, BossManager.Instance.ReturnAnimationData("Jump")),
                //new ConditionNode(Blackboard, new System.Func<bool>(() => JumpCheck()),
                new JumpNode(Blackboard, BossManager.Instance.ReturnAnimationData("Mine"),10),               
                new ShieldSlamNode(Blackboard, 10));*/
            InitializeTree();
            activeBehaviourTree = behaviourTreeStage1;
        }

        private bool RangeCheck()
        {
            if(Vector3.Distance(Player.transform.position, this.transform.position) < PlayerFarRange)
            {
                //Player close
                return true;
            }
            else
            {
                //Player far
                return false;
            }
        }
        int summonCooldown = 100;
        int summonCounter = 0;
        private bool SummonCheck()
        {
            summonCounter++;
            if (summonCounter >= summonCooldown)
            {
                summonCounter = 0;
                return true;
            }
            else
                return false;
        }

        private bool FireCheck()
        {
            return false;
        }

        private bool JumpCheck()
        {
            return Physics.Raycast(transform.position, -Vector3.up, 10);
        }

        private void Update()
        {
            //When the composition node returns succes we need to reset al the child nodes
            //lua code
            //if behaviourtree is done, 
            //reset all child nodes. 
            //Every first time a node gets entered the node should call some init or enter method
            activeBehaviourTree.Tick();
            transform.LookAt(Player.transform);
        }
    }
}