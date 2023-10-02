using UnityEngine;
using UnityEngine.AI;

public class HeroMovement : CharacterNavigation
{
    private GameObject clickPointer;

    public HeroMovement(NavMeshAgent agent, GameObject clickPointer)
        : base(agent)
    {
        this.clickPointer = clickPointer;
    }

    protected override void StartMove(Vector3 targetPosition)
    {
        PutClickPointer(targetPosition);
        base.StartMove(targetPosition);
    }

    private void PutClickPointer(Vector3 targetPosition)
    {
        Vector3 position = new Vector3(targetPosition.x, targetPosition.y + 0.1f, targetPosition.z);

        clickPointer.transform.position = position;
        clickPointer.SetActive(true);
    }


    public override void Move(Vector3 characterPosition, Vector3 targetPosition)
    {
        base.Move(characterPosition, targetPosition);
        if (distance <= 1.1f)
        {
            clickPointer.SetActive(false);
        }
    }

    public override void Attack(Transform characherTransform, Vector3 enemyPosition)
    {
        clickPointer.SetActive(false);
        base.Attack(characherTransform, enemyPosition);
    }
}
