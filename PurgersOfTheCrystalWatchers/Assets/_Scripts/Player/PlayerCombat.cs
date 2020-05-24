using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Player player;

    public KeyCode AttackButton;
    public Animator Animator;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !player.Attacking)
        {
            player.Attacking = true;
            StartCoroutine(AttackCooldown(1.5f));
            Animator.SetBool("Attack",true);
        }
    }

    private IEnumerator AttackCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        Animator.SetBool("Attack", false);
        player.Attacking = false;
    }
}
