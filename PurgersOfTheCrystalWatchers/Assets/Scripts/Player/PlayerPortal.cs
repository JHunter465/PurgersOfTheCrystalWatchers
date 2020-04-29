using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : MonoBehaviour
{
    private ObjectPooler objectPooler;

    [SerializeField] private Transform CameraTransform;
    public KeyCode PortalKey;
    public KeyCode ParryKey;

    [SerializeField] private Vector3 PortalSpawnOffset;
    [SerializeField] private LayerMask RayCastLayerMask;

    [SerializeField] private GameObject lastPortal, currentPortal;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        if(Input.GetKeyDown(PortalKey))
        {
            SpawnPortal();
        }
    }

    private void SpawnPortal()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x + PortalSpawnOffset.x * CameraTransform.rotation.y, transform.position.y + 1.8f + PortalSpawnOffset.y, transform.position.z), CameraTransform.forward, out hit, Mathf.Infinity, RayCastLayerMask))
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z), CameraTransform.forward * hit.distance, Color.magenta);
        }
        Quaternion dir = Quaternion.FromToRotation(new Vector3(transform.up.x, transform.up.y, transform.up.z + 90), hit.normal);

        GameObject Portal = objectPooler.SpawnFromPool("Portal", new Vector3(hit.point.x, hit.point.y, hit.point.z), dir);

        if(lastPortal != null)
        {
            lastPortal.SetActive(false);
        }
        if(currentPortal != null)
        {
            lastPortal = currentPortal;
        }

        currentPortal = Portal;

        if(lastPortal != null)
        {
            currentPortal.transform.GetChild(0).GetComponent<Portal>().OtherPortal = lastPortal.transform;
            lastPortal.transform.GetChild(0).GetComponent<Portal>().OtherPortal = currentPortal.transform;
        }
    }
}
