using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform OtherPortal;

    private void OnTriggerEnter(Collider other)
    {
        if (OtherPortal != null)
        {
            other.transform.position = OtherPortal.position + OtherPortal.forward * 3;

            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddRelativeForce(new Vector3(OtherPortal.transform.forward.x, OtherPortal.transform.forward.y, OtherPortal.transform.forward.z) * 500);
            }

            other.transform.forward = transform.forward;
        }
    }
}
