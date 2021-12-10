using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwards : Command
{
    public override void Execute(Transform boxTransform, Command command)
    {
        Move(boxTransform);

        InputHandler.oldCommands.Add(command);
    }

    public override void Undo(Transform boxTransform)
    {
        boxTransform.Translate(boxTransform.forward * moveDistance);
    }

    public override void Move(Transform boxTransform)
    {
        boxTransform.Translate(-boxTransform.forward * moveDistance);
    }
}
