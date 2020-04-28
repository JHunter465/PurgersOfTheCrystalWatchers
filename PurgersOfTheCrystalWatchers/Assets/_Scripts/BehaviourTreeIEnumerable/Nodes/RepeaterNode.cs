using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterNode<X> : ParentBehaviourNode<X>
{
    BehaviourNode<X>[] childs;

    public RepeaterNode(params BehaviourNode<X>[] _childs)
    {
        childs = _childs;
    }

    public override bool Recalculate()
    {
        return false;
    }

    public override IEnumerable<BehaviourNode<X>> GetChilds()
    {
        return childs;
    }

    public override State CalculateState(State childState)
    {
        return childState;
    }
}
