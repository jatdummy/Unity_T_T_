using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private CommandManager commandManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveSelectedUnit(new Vector3(0f, 0f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveSelectedUnit(new Vector3(2f, 0f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveSelectedUnit(new Vector3(4f, 0f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            commandManager.Undo();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            commandManager.Redo();
        }
    }

    private void MoveSelectedUnit(Vector3 targetPosition)
    {
        if (selectedUnit == null)
        {
            return;
        }

        ICommand command = new MoveUnitCommand(selectedUnit, targetPosition);
        commandManager.ExecuteCommand(command);
    }
}

