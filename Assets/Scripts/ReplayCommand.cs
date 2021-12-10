using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayCommand : Command
{
    public override void Execute(Transform boxTransform, Command command)
    {
        InputHandler.shouldStartReplay = true;
    }
}
