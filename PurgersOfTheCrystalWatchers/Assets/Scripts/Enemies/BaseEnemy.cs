using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class BaseEnemy : MonoBehaviour, IMinion
    {
        //Minion type
        [SerializeField] private MinionType currentMinionType;

        //References
        public Transform player;

        //Variables
        [SerializeField] protected float BaseSpeed, RotationSpeed, StopDistance;

        protected float currentSpeed;

        //Components
        public Animator animator;

        [SerializeField] protected EnemyTrigger distanceTrigger;

        protected virtual void Awake()
        {
            animator = GetComponent<Animator>();
        }

        protected virtual void OnEnable()
        {
            player = null;
            currentSpeed = BaseSpeed;
        }

        public void Init(GameObject playerRef)
        {
            player = playerRef.transform;
        }

        public MinionType GetMinionType()
        {
            return currentMinionType;
        }

        protected virtual void Update()
        {
            Move();
            Rotate();
        }

        protected virtual void Move()
        {
            //return out of method if there is no player assigned
            if (player == null)
            {
                return;
            }

            //Run towards player
            if (Vector3.Distance(transform.position, player.position) > StopDistance)
            {
                transform.position += transform.forward * currentSpeed * Time.deltaTime;
            }
        }

        protected virtual void Rotate()
        {
            //return out of method if there is no player assigned
            if (player == null)
            {
                return;
            }

            var lookPos = player.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
        }
    }
}
