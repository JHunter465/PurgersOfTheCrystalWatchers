using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class FireProjectileNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;
        LineRenderer lineRenderer;

        public FireProjectileNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            
            board.AnimatorController.ResetTrigger(Globals.BOSS_LEAPING_ANIMATORBOOL);

            board.AnimatorController.SetTrigger(Globals.BOSS_FIRING_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);

            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

            //Use line renderer to determine and show player where the laser will be going
            board.EnemyAgent.ProjectileSpawn.SetActive(true);
            lineRenderer = board.EnemyAgent.ProjectileSpawn.GetComponent<LineRenderer>();
            lineRenderer.positionCount = board.EnemyAgent.LineRendererLenght;
            float alpha =1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                    new GradientColorKey[] {new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f)},
                    new GradientAlphaKey[] {new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 0.4f)}
                );
            lineRenderer.colorGradient = gradient;

            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                board.EnemyAgent.ProjectileSpawn.SetActive(false);

                //Fire Projectile
                GameObject projectile = ObjectPooler.Instance.SpawnFromPool(board.EnemyAgent.ProjectilePrefab.name, board.EnemyAgent.ProjectileSpawn.transform.position, board.EnemyAgent.ProjectileSpawn.transform.rotation);
                projectile.GetComponent<Rigidbody>().AddRelativeForce(projectile.transform.forward * 1000);
                return State.SUCCESS;
            }
            else
            {
                if(lineRenderer != null)
                {
                    var points = new Vector3[board.EnemyAgent.LineRendererLenght];
                    for(int i = 0; i < board.EnemyAgent.LineRendererLenght; i++)
                    {
                        points[i] = board.EnemyAgent.ProjectileSpawn.transform.position + board.EnemyAgent.ProjectileSpawn.transform.forward * i;
                    }
                    lineRenderer.SetPositions(points);
                }
                return State.IN_PROGRESS;
            }
        }
    }
}
