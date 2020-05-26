using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;
using System.Linq;
using UnityEngine.AI;
using Invector;

namespace POTCW
{
    public enum FindPlatformType
    {
        Random = 0,
        CloseByPlayer = 1,
    }

    public enum SpecialMode
    {
        OpenTerrain = 0,
        PlatformArea = 1,
        NarrowClifs = 2,
    }

    [System.Serializable]
    public class CrystalContainer
    {
        public string name;
        public SpecialMode Area;
        public List<Crystal> AllCrystalsInArea;
    }

    [RequireComponent(typeof(Rigidbody),typeof(NavMeshAgent),typeof(CapsuleCollider))]
    [RequireComponent(typeof(vHealthController), typeof(vHitDamageParticle))]
    public class EnemyAgent : MonoBehaviour
    {
        [Header("Debugging")]
        public float TimeBetweenNodes = 10f;
        public GameObject Player1;
        public GameObject Player2;
        public SpecialMode SpecialModeActive;
        public bool BossActivatedByPlayer = false;
        public bool UpdateUIOnce = false;

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

        [Header("Standard Behaviour")]
        public float MovementSpeed = 10f;
        public float ThresHold = 0;
        public float ReachedThresHold = 10f;
        public List<Transform> PatrolPoints;
        public int PatrolIndex = 0;
        public GameObject JabLegObject;
        public Transform LookTransform;
        public float CurrentHealth = 1000;
        public float MaxHealth = 1000;
        public List<CrystalContainer> CrystalsInAreas;
        public SpecialMode CurrentArea;
        public int HPPercentageLostToDestroyCrystals = 25;

        [HideInInspector]
        public vHealthController CurrentVHealthController;

        [Header("Minions Related")]
        public GameObject MinionPrefab;
        public List<Transform> MinionSpawns;

        [Header("Projectile Related")]
        public float ProjectileSpeed = 1000f;
        public GameObject ProjectilePrefab;
        public GameObject ProjectileSpawn;
        public int LineRendererLenght = 20;

        [Header("Mode1 (Open Terrain) Data")]
        public float ShockWaveRange = 3f;
        public GameObject ShockWaveTriggerObject;
        public float TornadoLifeTime = 10f;
        public GameObject CrystalTornadoPrefab;
        public int MinionSpawnAmount = 10;

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
        public float GrabTime = 2f;
        public GameObject QuickAttackObject;

        [HideInInspector]
        public NavMeshAgent NavMeshAgent;

        //Blackboard 
        protected EnemyBlackBoard board = new EnemyBlackBoard();

        private void Awake()
        {
            //Get animator controller
            if (GetComponent<Animator>() != null)
                board.AnimatorController = GetComponent<Animator>();

            //Get NavMeshAgent
            if (GetComponent<NavMeshAgent>() != null)
            {
                NavMeshAgent = GetComponent<NavMeshAgent>();
                NavMeshAgent.speed = MovementSpeed;
            }

            if(GetComponent<vHealthController>() != null)
            {
                CurrentVHealthController = GetComponent<vHealthController>();
                CurrentVHealthController.ChangeHealth((int)CurrentHealth);
            }

            //Get all platforms in scene that can be dynamically used
            if(Platforms.Count < 1)
            {
                //Platforms = FindObjectsOfType<Transform>().ToList();
            }

            board.EnemyAgent = this;
            ShockWaveTriggerObject.SetActive(false);
            Globals.BossBlackBoard = board;
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
            //InvokeRepeating("FindClosestPlayer", 0.1f, PlayerSearchTime);

            EventManager<SpecialMode>.AddHandler(EVENT.SwitchBossSpecialModeType, SetActiveSpecialModeType);

            EventManager<SpecialMode>.AddHandler(EVENT.SwitchInCurrentArea, SetInCurrentArea);

            EventManager<SpecialMode>.BroadCast(EVENT.SwitchBossSpecialModeType, SpecialModeActive);

            EventManager<SpecialMode>.BroadCast(EVENT.SwitchInCurrentArea, CurrentArea);
        }

        /// <summary>
        /// Setter for our current area
        /// </summary>
        /// <param name="area">Area we want to switch to</param>
        public void SetInCurrentArea(SpecialMode area)
        {
            CurrentArea = area;
        }

        /// <summary>
        /// Setter for our current active special mode 
        /// </summary>
        /// <param name="type">Incoming special mode type</param>
        public void SetActiveSpecialModeType(SpecialMode type)
        {
            SpecialModeActive = type;
        }

        /// <summary>
        /// Find closest player and set it to current targeted player
        /// </summary>
        private void FindClosestPlayer()
        {
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


            
            if(Vector3.Distance(Player1.transform.position, this.transform.position) < PlayerCloseRange || Vector3.Distance(Player2.transform.position, this.transform.position) < PlayerCloseRange)
            {
                BossActivatedByPlayer = true;
                if(!UpdateUIOnce)
                {
                    UpdateUIOnce = true;
                    EventManager<bool>.BroadCast(EVENT.ActivateBoss, true);
                }
            }

            if (BossActivatedByPlayer)
            {
                if (Vector3.Distance(Player1.transform.position, this.transform.position) < Vector3.Distance(Player2.transform.position, this.transform.position))
                {
                    Player = Player1;
                    LookTransform = Player.transform;
                }
                else
                {
                    Player = Player2;
                    LookTransform = Player.transform;
                }
            }

            RotateAgent(LookTransform);
            DestroyAllCrystalsInCurrentArea(HPPercentageLostToDestroyCrystals);

            /*This needs cleaning*/
            //This is for the pull
            if (board.EnemyAgent.GrabObject.activeSelf)
            {
                if (Vector3.Distance(board.EnemyAgent.Player.transform.position, board.EnemyAgent.GrabObject.transform.position) < 3f)
                {
                    if (!PlayerInGrabRange)
                    {
                        GameObject plyr = board.EnemyAgent.Player;
                        Rigidbody plyrBody = plyr.GetComponent<Rigidbody>();
                        //plyr.transform.parent = board.EnemyAgent.GrabObject.transform;
                        plyrBody.constraints = RigidbodyConstraints.FreezeAll;
                        plyr.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.transform.position, board.EnemyAgent.GrabSpeed);
                        PlayerInGrabRange = true;
                        StartCoroutine(ResetPlayerBody(GrabTime));
                        board.EnemyAgent.GrabObject.transform.position = board.EnemyAgent.GrabSpawn.transform.position;
                        board.EnemyAgent.GrabObject.SetActive(false);
                    }
                }
            }
        }

        public void DestroyAllCrystalsInCurrentArea(float percentage)
        {
            var tmpHP = CurrentHealth - (MaxHealth / 100 * percentage);
            if (CurrentVHealthController.currentHealth < tmpHP)
            {
                //CurrentHealth = tmpHP;
                CrystalContainer currentCrystalsInArea = CrystalsInAreas.Find(cia => cia.Area == CurrentArea);
                if (currentCrystalsInArea == null) return;
                foreach(Crystal crystal in currentCrystalsInArea.AllCrystalsInArea)
                {
                    if (crystal == null) return;
                    //Destroy all crystals in current area
                    //crystal.Die();
                    crystal.gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Rotate the agent at given transform
        /// </summary>
        /// <param name="lookat">Transform to rotate towards</param>
        public void RotateAgent(Transform lookat)
        {
            var lookPos = lookat.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * LookAtDamping);
        }

        /// <summary>
        /// Resets the player constraints
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public IEnumerator ResetPlayerBody(float time)
        {
            yield return new WaitForSeconds(time);
            Rigidbody body = Player.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.None;
            body.constraints = RigidbodyConstraints.FreezeRotation;
        }

        /// <summary>
        /// Keep track of the threshold to do a special move
        /// </summary>
        /// <returns></returns>
        public bool ThresHoldCheck()
        {
            if (ThresHold >= ReachedThresHold-3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Measure the distance between the player and given transform
        /// </summary>
        /// <param name="measureTransform">Transform to measure distance from </param>
        /// <param name="range">Given range to check</param>
        /// <returns></returns>
        public bool PlayerDistanceCheck(Transform measureTransform, float range)
        {
            if (Vector3.Distance(measureTransform.position, Player.transform.position) < range)
                return true;
            else
                return false;
        }


        public int GetPlayerDistanceFromBoss()
        {
            if (!PlayerDistanceCheck(this.transform, PlayerFarRange))
                return 0;
            else if (!PlayerDistanceCheck(this.transform, PlayerCloseRange))
                return 1;
            else if (PlayerDistanceCheck(this.transform, PlayerCloseRange))
                return 2;
            else
                return 0;
        }

        /// <summary>
        /// Returns the current platform search choice
        /// </summary>
        /// <returns></returns>
        public FindPlatformType GetYeetPlatformType()
        {
            return FindPlatformType;
        }

        /// <summary>
        /// Dissable this game object
        /// </summary>
        public void Die()
        {
            this.gameObject.SetActive(false);
        }
    }
}
