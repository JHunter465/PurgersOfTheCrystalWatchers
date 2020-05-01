using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public interface IBossManager
    {
        Attacks ReturnAttack(string name);
    }
}
