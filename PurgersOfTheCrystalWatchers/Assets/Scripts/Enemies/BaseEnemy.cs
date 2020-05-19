using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //References
    protected Transform player;

    //Variables
    [SerializeField] protected float BaseSpeed, RotationSpeed, StopDistance;

    protected float currentSpeed;

    //Components
    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        player = null;
        currentSpeed = BaseSpeed;
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (player == null && other.tag == "Player")
        {
            animator.SetBool("Running", true);
            player = other.transform;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Running", false);
            player = null;
        }
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
