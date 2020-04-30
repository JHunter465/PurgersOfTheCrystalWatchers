using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class EnemyAgent : MonoBehaviour
    {
        [Header("Debugging")]
        public bool Stage1 = false;
        public bool Stage2 = false;
        public bool Stage3 = false;

        [Header("Player Related")]
        public float PlayerCloseRange = 10f;
        public float PlayerFarRange = 30f;
        public float PlayerToFarRange = 50f;
        public GameObject Player;
        public GameObject SearchPlayerGameObject;

        [Header("Minions Related")]
        public GameObject MinionPrefab;
        public List<Transform> MinionSpawns;

        [Header("Projectile Related")]
        public GameObject ProjectilePrefab;

        [Header("Mode1 (Open Terrain) Data")]
        public float ShockWaveRange = 3f;
        public GameObject ShockWaveTriggerObject;
        public float TornadoLifeTime = 10f;
        public GameObject CrystalTornadoPrefab;
        public float MovementSpeed = 10f;
        public int SpecialAttackAmount = 3;
        public float ThresHold;

        protected EnemyBlackBoard board = new EnemyBlackBoard();

        private void Awake()
        {
            //Get animator controller
            if (GetComponent<Animator>() != null)
                board.AnimatorController = GetComponent<Animator>();

            board.EnemyAgent = this;
            ShockWaveTriggerObject.SetActive(false);
            Globals.BossBlackBoard = board;

            Debug.Log("EnemyAgentAwakes with blackboard:  " + board);
        }

        private void Start()
        {
            //Create AI behaviour tree
            var tree = new MyBehaviourTree(board);

            // Calling the start so we run the behaviour tree
            // The first argument is the MonoBehaviour the tree attaches to and depends on (like a coroutine), 
            // the second is the agent to control
            // We use IEnumerators for performance optimazation and we are now able to pause and resume the behaviour if we wish.
            tree.Start(this, this);
        }

        private void LateUpdate()
        {
            transform.LookAt(Player.transform);
        }
    }
}
