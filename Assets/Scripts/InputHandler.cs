using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputHandler : MonoBehaviour
{
    public Transform boxTransform;

    private Command buttonW, buttonS, buttonA, buttonD, buttonB, buttonZ, buttonR;

    public static List<Command> oldCommands = new List<Command>();

    private Vector3 boxStartPosition;

    private Coroutine replayCoroutine;

    public static bool shouldStartReplay;

    private bool isReplaying;

    private void Start()
    {
        buttonB = new DoNothing();
        buttonW = new MoveForward();
        buttonS = new MoveBackwards();
        buttonA = new MoveLeft();
        buttonD = new MoveRight();
        buttonZ = new UndoCommand();
        buttonR = new ReplayCommand();

        boxStartPosition = boxTransform.position;
    }

    private void Update()
    {
        if (!isReplaying)
        {
            HandleInput();
        }

        StartReplay();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            buttonA.Execute(boxTransform, buttonA);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            buttonB.Execute(boxTransform, buttonB);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            buttonD.Execute(boxTransform, buttonD);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            buttonR.Execute(boxTransform, buttonZ);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            buttonS.Execute(boxTransform, buttonS);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            buttonW.Execute(boxTransform, buttonW);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            buttonZ.Execute(boxTransform, buttonZ);
        }
    }

    void StartReplay()
    {
        if(shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;

            if(replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }

            replayCoroutine = StartCoroutine(ReplayCommands(boxTransform));
        }

        
    }
    IEnumerator ReplayCommands(Transform boxTransform)
    {
        
        isReplaying = true;

       
        boxTransform.position = boxStartPosition;

        for (int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Move(boxTransform);

            yield return new WaitForSeconds(0.3f);
        }

        
        isReplaying = false;
    }


}
