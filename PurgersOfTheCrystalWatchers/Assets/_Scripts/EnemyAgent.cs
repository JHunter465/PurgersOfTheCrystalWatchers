using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;
using System.Linq;

namespace POTCW
{
    public enum FindPlatformType
    {
        Random = 0,
        CloseByPlayer = 1,
    }

    public class EnemyAgent : MonoBehaviour
    {
        [Header("Debugging")]
        public bool Stage1 = false;
        public bool Stage2 = false;
        public bool Stage3 = false;
        public float TimeBetweenNodes = 10f;
        public GameObject Player1;
        public GameObject Player2;

        [Header("Player Related")]
        public float PlayerCloseRange = 10f;
        public float PlayerFarRange = 30f;
        public float PlayerToFarRange = 50f;
        public GameObject Player;
        public GameObject SearchPlayerGameObject;
        public float PlayerSearchTime = 10f;
        public float LookAtDamping = 10f;

        [HideInInspector]
        public Rigidbody PlayerBody;
        [HideInInspector]
        public bool PlayerInGrabRange = false;

        [Header("Minions Related")]
        public GameObject MinionPrefab;
        public List<Transform> MinionSpawns;

        [Header("Projectile Related")]
        public float ProjectileForceSpeed = 1000f;
        public GameObject ProjectilePrefab;
        public GameObject ProjectileSpawn;
        public int LineRendererLenght = 20;

        [Header("Mode1 (Open Terrain) Data")]
        public float ShockWaveRange = 3f;
        public GameObject ShockWaveTriggerObject;
        public float TornadoLifeTime = 10f;
        public GameObject CrystalTornadoPrefab;
        public float MovementSpeed = 10f;
        public int SpecialAttackAmount = 3;
        public float ThresHold = 0;
        public float ReachedThresHold = 10f;

        [Header("Mode2 (Platform Area) Data")]
        public List<Transform> Platforms;
        [HideInInspector] public Transform CurrentSelectedPlatform;
        public float YeetSpeed = 10f;
        public float PlatformCloseDistance = 10f;
        public FindPlatformType FindPlatformType;
        public GameObject DestroyPlatformParticleEffect;
        public Transform AoEProjectileRainSpawn;
        public float AoEProjectileRainSpawnPlayerDistanceHeight = 20f;
        public int AoEProjectilesAmount = 10;

        [Header("Mode3 (Narrow Clifs Area) Data")]
        public float MineTime = 10f;
        public float MineDepth = 20f;
        public GameObject GrabObject;
        public GameObject GrabSpawn;
        public float GrabSpeed = 20f;

        //Blackboard 
        protected EnemyBlackBoard board = new EnemyBlackBoard();

        private void Awake()
        {
            //Get animator controller
            if (GetComponent<Animator>() != null)
                board.AnimatorController = GetComponent<Animator>();

            //Get all platforms in scene that can be dynamically used
            if(Platforms.Count < 1)
            {
                //Platforms = FindObjectsOfType<Transform>().ToList();
            }

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

            //Every PlayerSearchTime seconds update the closest player we want to target
            InvokeRepeating("FindClosestPlayer", 0.1f, PlayerSearchTime);
        }

        private void FindClosestPlayer()
        {
            Debug.Log("Find Closest Player");

            GameObject currentClosePlayer;
            
            if(Player1 == null || Player2 == null)
            {
                return;
            }
            else
            {
                if (Vector3.Distance(Player1.transform.position, this.transform.position) < Vector3.Distance(Player2.transform.position, this.transform.position))
                    currentClosePlayer = Player1;
                else
                    currentClosePlayer = Player2;
            }

            Player = currentClosePlayer;
            PlayerBody = Player.GetComponent<Rigidbody>();
        }

        private void LateUpdate()
        {
            ThresHold+=Time.deltaTime;
            if(ThresHold > ReachedThresHold)
                ThresHold = 0;

            var lookPos = Player.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * LookAtDamping);
            //transform.LookAt(Player.transform);

            if (board.EnemyAgent.GrabObject.activeSelf)
            {
                if (Vector3.Distance(board.EnemyAgent.Player.transform.position, board.EnemyAgent.GrabObject.transform.position) < 3f)
                {
                    if (!PlayerInGrabRange)
                    {
                        GameObject plyr = board.EnemyAgent.Player;
                        //plyr.transform.parent = board.EnemyAgent.GrabObject.transform;
                        board.EnemyAgent.PlayerBody.constraints = RigidbodyConstraints.FreezeAll;
                        Debug.Log("Lerp the player bitch");
                        plyr.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.GrabSpawn.transform.position, board.EnemyAgent.GrabSpeed);
                        PlayerInGrabRange = true;
                        StartCoroutine(ResetPlayerBody(GrabSpeed/10));
                        board.EnemyAgent.GrabObject.transform.position = board.EnemyAgent.GrabSpawn.transform.position;
                        board.EnemyAgent.GrabObject.SetActive(false);
                    }
                }
            }
        }

        public IEnumerator ResetPlayerBody(float time)
        {
            yield return new WaitForSeconds(time);
            board.EnemyAgent.PlayerBody.constraints = RigidbodyConstraints.None;
            board.EnemyAgent.PlayerBody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        public bool ThresHoldCheck()
        {
            if (ThresHold >= ReachedThresHold-3)
            {
                //Debug.Log("Threshold reached, do special");
                return true;
            }
            else
            {
                //Debug.Log("Standard behaviour running");
                return false;
            }
        }

        public bool PlayerDistanceCheck(Transform measureTransform, float range)
        {
            if (Vector3.Distance(measureTransform.position, Player.transform.position) < range)
                return true;
            else
                return false;
        }

        public FindPlatformType GetYeetPlatformType()
        {
            return FindPlatformType;
        }

        public void Die()
        {
            this.gameObject.SetActive(false);
        }
    }
}
