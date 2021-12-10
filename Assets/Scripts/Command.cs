using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    protected float moveDistance = 1f;

    public abstract void Execute(Transform boxTransform, Command command);

    public virtual void Undo(Transform boxTransform) { }

    public virtual void Move(Transform boxTransform) { }
}
