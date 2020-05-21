using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class CrystalExplosion : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter(Collider other)
    {
        vThirdPersonController player = other.GetComponent<vThirdPersonController>();
        if (player != null)
        {
            Invector.vDamage damage = new Invector.vDamage(Damage);
            player.TakeDamage(damage);
        }
    }
}
