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
        public float MovementSpeed = 10f;

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
            //Create AIs
            var tree = new MyBehaviourTree(board);

            // Call start to actually run the AI.
            // The first argument is the MonoBehaviour the tree attaches to and depends on (like a coroutine), 
            // the second is the agent to control
            tree.Start(this, this);
        }

        private void LateUpdate()
        {
            transform.LookAt(Player.transform);
        }
    }
}
