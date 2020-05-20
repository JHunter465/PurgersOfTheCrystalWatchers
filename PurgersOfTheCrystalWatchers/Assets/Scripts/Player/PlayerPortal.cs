using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class PlayerPortal : MonoBehaviour
{
    private ObjectPooler objectPooler;

    [SerializeField] private Transform CameraTransform;

    public KeyCode PortalKey;
    public KeyCode VoidKey;

    public GenericInput PortalInput = new GenericInput("Horizontal", "LeftAnalogHorizontal", "Horizontal");
    public GenericInput VoidInput = new GenericInput("Horizontal", "LeftAnalogHorizontal", "Horizontal");


    [SerializeField] private Vector3 PortalSpawnOffset;
    [SerializeField] private LayerMask RayCastLayerMask;

    [SerializeField] private GameObject voidPortal;

    [SerializeField] private GameObject lastPortal, currentPortal;

    [SerializeField] private float crystalCostPortal, crystalCostVoid, voidPortalDuration;

    private vThirdPersonController thirdPersonController;

    private bool voidPortalOn;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        thirdPersonController = GetComponent<vThirdPersonController>();
    }

    private void Update()
    {
        if(PortalInput.GetButtonDown() && thirdPersonController.currentStamina >= crystalCostPortal)
        {
            Debug.Log("Portal");
            SpawnPortal();
        }
        if(VoidInput.GetButtonDown() && !voidPortalOn && thirdPersonController.currentStamina >= crystalCostVoid)
        {
            StartCoroutine(ActivateVoidPortal());
        }
    }

    private void SpawnPortal()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x + PortalSpawnOffset.x * CameraTransform.rotation.y, transform.position.y + 1.8f + PortalSpawnOffset.y, transform.position.z), CameraTransform.forward, out hit, Mathf.Infinity, RayCastLayerMask))
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z), CameraTransform.forward * hit.distance, Color.magenta);
        }
        Debug.Log(hit.point);
        Quaternion dir = Quaternion.FromToRotation(new Vector3(transform.forward.x, transform.forward.y, transform.forward.z + 90), hit.normal);

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

        thirdPersonController.ReduceStamina(crystalCostPortal, false);
    }

    private IEnumerator ActivateVoidPortal()
    {
        voidPortalOn = true;
        thirdPersonController.ReduceStamina(crystalCostVoid, false);
        voidPortal.SetActive(true);
        yield return new WaitForSeconds(voidPortalDuration);
        voidPortal.SetActive(false);
        voidPortalOn = false;
    }
}
