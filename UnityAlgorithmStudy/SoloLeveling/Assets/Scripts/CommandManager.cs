using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
    }

    public void Undo()
    {
        if (undoStack.Count == 0)
        {
            Debug.Log("되돌릴 게 없습니다.");
            return;
        }

        ICommand command = undoStack.Pop();
        command.Undo();

        redoStack.Push(command);
    }

    public void Redo()
    {
        if (redoStack.Count == 0)
        {
            Debug.Log("실행할게 없어요");
            return;
        }

        ICommand command = redoStack.Pop();
        command.Execute ();


    }


}
