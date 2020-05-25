using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{ 
public class UnstableCrystalGolem : BaseEnemy
{
    //Variables
    [SerializeField] private float ExplosionDistance, ExplosionDamage;

    private bool exploding;

    [SerializeField] private GameObject materialHolder;
    private Material material;

    protected override void Awake()
    {
        base.Awake();
        material = materialHolder.GetComponent<SkinnedMeshRenderer>().material;
    }

    protected virtual void OnEnable()
    {
        base.OnEnable();
        exploding = false;
    }

    protected override void Update()
    {
        base.Update();
        CheckExplosion();
    }


    private void CheckExplosion()
    {
        //return out of method if there is no player assigned
        if (player == null)
        {
            return;
        }

        if (Vector3.Distance(transform.position, player.position) < ExplosionDistance && !exploding)
        {
            exploding = true;
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        currentSpeed = 0;

        animator.SetTrigger("Explode");
        //StartCoroutine(lerpEmission(material.GetFloat("_EmissiveIntensity"), material.GetFloat("_EmissiveIntensity") * 40f, 1f));

        yield return new WaitForSeconds(1.4f);

        Vector3 effectPosition = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z);
        GameObject effect = ObjectPooler.Instance.SpawnFromPool("CrystalExplosion", effectPosition, Quaternion.identity);
        effect.GetComponent<CrystalExplosion>().Damage = (int)ExplosionDamage;
        gameObject.SetActive(false);
    }

        //Juice to implement later: Currently does lerp number but visuals don't change.
        public IEnumerator lerpEmission(float start, float end, float LerpTime)
        {
            float StartTime = Time.time;
            float EndTime = StartTime + LerpTime;

            while (Time.time < EndTime)
            {
                float timeProgressed = (Time.time - StartTime) / LerpTime;  // this will be 0 at the beginning and 1 at the end.
                material.SetFloat("_EmissiveIntensity", Mathf.Lerp(start, end, timeProgressed));

                yield return new WaitForFixedUpdate();
            }
            material.SetFloat("_EmissiveIntensity", end);
        }
    }
}
