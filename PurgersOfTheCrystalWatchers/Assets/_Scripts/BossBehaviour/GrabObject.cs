using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;
using Invector.vCharacterController;

namespace POTCW
{
    public class GrabObject : MonoBehaviour
    {
        public Transform startPosition;
        public float PullSpeed = 10f;
        private bool getBack = true;

        private void OnEnable()
        {
            if(getBack)
                this.gameObject.DeactivateAfterTime(this, 2f);
        }

        private void OnDisable()
        {
            transform.position = startPosition.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.HasComponent<vMeleeCombatInput>())
            {
                getBack = false;
                //Pull player towards boss

                //other.gameObject.GetComponent<vMeleeCombatInput>().enabled = false;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                other.gameObject.transform.parent = this.transform;
                if (!getBack)
                {
                    this.transform.LerpTransform(this, startPosition.position, PullSpeed);
                    StartCoroutine(ReleaseAfterTime(other.gameObject));
                }
            }
        }

        private IEnumerator ReleaseAfterTime(GameObject other)
        {
            yield return new WaitForSeconds(PullSpeed);
            //other.gameObject.GetComponent<vMeleeCombatInput>().enabled = true;
            var cmp = other.gameObject.GetComponent<Rigidbody>();
            cmp.constraints = RigidbodyConstraints.None;
            cmp.constraints = RigidbodyConstraints.FreezeRotation;
            getBack = true;
            other.transform.parent = null;
            transform.position = startPosition.transform.position;

            this.gameObject.DeactivateAfterTime(this, 1f);
        }
    }
}
