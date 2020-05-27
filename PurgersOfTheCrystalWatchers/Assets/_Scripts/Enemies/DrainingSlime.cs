using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

namespace POTCW
{
    public class DrainingSlime : BaseEnemy
    {
        [SerializeField] private float drainDistance, gooSpawnTime, DisableTime, CrystalDrained;

        private ObjectPooler objectPooler;

        private void Start()
        {
            objectPooler = ObjectPooler.Instance;
            StartCoroutine(SpawnGoo());
            StartCoroutine(DrainCrystal());
        }

        protected override void Update()
        {
            base.Update();
            DrainCrystal();
        }

        public IEnumerator SpawnGoo()
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            Vector3 rotation = new Vector3(0, Random.Range(0, 360), 0);
            Debug.Log(objectPooler.PoolDictionary["FeetGnawer"]);
            objectPooler.SpawnFromPool("Goo", position, Quaternion.Euler(rotation));
            yield return new WaitForSeconds(gooSpawnTime);
            StartCoroutine(SpawnGoo());
        }

        private IEnumerator DrainCrystal()
        {
            if(player == null)
            {
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(DrainCrystal());
                yield break;
            }
            if(Vector3.Distance(transform.position, player.position) < drainDistance)
            {
                vThirdPersonController playerController = player.GetComponent<vThirdPersonController>();
                playerController.ReduceStamina(CrystalDrained, false);
            }
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(DrainCrystal());
        }
    }
}