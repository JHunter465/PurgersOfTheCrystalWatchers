﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public interface IMinion
    {
        MinionType GetMinionType();
        void Init(GameObject playerRef);
    }
}