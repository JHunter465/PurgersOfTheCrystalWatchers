using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    [System.Serializable]
    public struct Attacks
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public string AnimationBoolName;
        [SerializeField]
        public float Damage;
    }

    public class BossManager : GenericSingleton<BossManager, IBossManager>, IBossManager
    {
        public List<Attacks> BossAttackDatas;
        
        public Attacks ReturnAttack(string name)
        {
            return BossAttackDatas.Find(bad => bad.name == name);
        }    
    }


}
