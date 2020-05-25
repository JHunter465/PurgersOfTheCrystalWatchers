using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Invector;

public class Goo : MonoBehaviour
{
    public float DisableTime, Damage;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(DisableAfterTime());
    }
    
    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(DisableTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        vThirdPersonController player = other.GetComponent<vThirdPersonController>();
        if (player != null)
        {
            Invector.vDamage damage = new vDamage((int)Damage);
            player.TakeDamage(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
