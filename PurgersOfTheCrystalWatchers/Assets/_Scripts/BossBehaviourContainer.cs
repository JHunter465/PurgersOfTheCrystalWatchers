using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    [System.Serializable]
    public class BossBehaviourContainer
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public BaseNode[] InputNodes;
    }
}