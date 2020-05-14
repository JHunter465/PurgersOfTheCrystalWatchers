using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Invector;

public class Crystal : MonoBehaviour
{
    public int crystalGiven;
    public Vector2 RespawnTimeMinMax;
    public Vector2 ScaleMinMax;

    private vThirdPersonController currentPlayer;
    private vHealthController healthController;


    private void OnTriggerEnter(Collider other)
    {
        vThirdPersonController player = other.GetComponent<vThirdPersonController>();
        if (player != null)
        {
            currentPlayer = player;
        }
    }

    private void Start()
    {
        healthController = GetComponent<vHealthController>();
    }

    private void OnEnable()
    {
        float scaleFactor = Random.Range(ScaleMinMax.x, ScaleMinMax.y);
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        if (healthController != null)
        {
            healthController.ResetHealth();
        }
    }

    public void Die()
    {
        if(currentPlayer == null)
        {
            return;
        }
        currentPlayer.ChangeStamina(crystalGiven);
        currentPlayer.StartCoroutine(Respawn());
        gameObject.SetActive(false);
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(Random.Range(RespawnTimeMinMax.x, RespawnTimeMinMax.y));
        gameObject.SetActive(true);
    }
}
