using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Invector;

public class Goo : MonoBehaviour
{
    public float DisableTime, CrystalDrained;

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
            player.ReduceStamina(CrystalDrained, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
