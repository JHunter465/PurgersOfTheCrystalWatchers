using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public interface IBossManager
    {
        AnimationData ReturnAnimationData(string name);
        Animator ReturnAnimator();
    }
}
