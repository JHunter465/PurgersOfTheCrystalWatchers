using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    [System.Serializable]
    public struct AnimationData
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public string AnimationBoolName;
        [SerializeField]
        public AnimationClip AnimationClip;
    }

    public class BossManager : GenericSingleton<BossManager, IBossManager>, IBossManager
    {
        public List<AnimationData> BossAnimationDatas;
        public Animator BossAnimator;
        public AnimationData ReturnAnimationData(string name)
        {
            return BossAnimationDatas.Find(bad => bad.name == name);
        }    
        public Animator ReturnAnimator()
        {
            return BossAnimator;
        }
    }


}
