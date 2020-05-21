using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            other.gameObject.SetActive(false);
        }
    }
}
