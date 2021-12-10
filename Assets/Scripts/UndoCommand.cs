using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoCommand : Command
{
    //Called when we press a key
    public override void Execute(Transform boxTransform, Command command)
    {
        List<Command> oldCommands = InputHandler.oldCommands;

        if (oldCommands.Count > 0)
        {
            Command latestCommand = oldCommands[oldCommands.Count - 1];

            //Move the box with this command
            latestCommand.Undo(boxTransform);

            //Remove the command from the list
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }
}
