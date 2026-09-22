using UnityEngine;

public class MoveUnitCommand : ICommand
{
    private Unit unit;
    private Vector3 previousPosition;
    private Vector3 targetPosition;

    public MoveUnitCommand(Unit unit, Vector3 targetPosition)
    {
        this.unit = unit;
        this.previousPosition = unit.transform.position;
        this.targetPosition = targetPosition;
    }

    public void Execute()
    {
        unit.MoveTo(targetPosition);
    }

    public void Undo()
    {
        unit.MoveTo(previousPosition);
    }

}
