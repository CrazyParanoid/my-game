using System;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavigation
{
    private readonly NavMeshAgent agent;

    //Distance
    public float distance;
    public float speed;
    public float maxSpeed;
    private const float START_MOVE_DISTANCE = 0.6f;
    private const float STOP_MOVE_DISTANCE = 0.5f;
    private const float STOP_INTERACT_DISTANCE = 3f;

    public event Action<bool> OnStopMove;
    public event Action<bool> OnStartAttack;
    public event Action<bool> OnStopAttack;
    public event Action<bool> OnStartComingUp;

    public CharacterNavigation(NavMeshAgent agent)
    {
        this.agent = agent;
    }

    public virtual void Attack(Transform characherTransform, Vector3 targetInteractPosition)
    {
        distance = Vector3.Distance(characherTransform.position, targetInteractPosition);
        speed = Mathf.Clamp(speed, 0, 1);

        if (distance >= 6f)
        {
            StopAttack(targetInteractPosition);
        }
        else if (distance <= 6f)
        {
            StartAttack(characherTransform, targetInteractPosition);
        }
    }

    protected void StartAttack(Transform characherTransform, Vector3 targetInteractPosition)
    {
        speed -= 5 * Time.deltaTime;

        TurnTowardsTheTarget(characherTransform, targetInteractPosition);

        if (speed <= 0.2f)
        {
            OnStopAttack.Invoke(false);
            OnStartAttack.Invoke(true);

            agent.isStopped = true;
        }
    }

    protected void StopAttack(Vector3 position)
    {
        agent.SetDestination(position);
        agent.isStopped = false;

        OnStartAttack.Invoke(false);
        OnStopAttack.Invoke(true);
    }

    public void TurnTowardsTheTarget(Transform characherTransform, Vector3 enemyPosition)
    {
        Vector3 direction = (enemyPosition - characherTransform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        characherTransform.rotation = Quaternion.Slerp(
            characherTransform.rotation,
            lookRotation,
            Time.deltaTime * 10);
    }

    public virtual void Move(Vector3 characterPosition, Vector3 targetPosition)
    {
        distance = Vector3.Distance(characterPosition, targetPosition);

        if (distance > START_MOVE_DISTANCE)
        {
            StartMove(targetPosition);
        }
        else if (distance <= STOP_MOVE_DISTANCE)
        {
            StopMove(characterPosition, targetPosition);
        }

        speed = Mathf.Clamp(speed, 0, 1);
    }

    public void ComeUp(Transform characherTransform, Vector3 targetInteractPosition)
    {
        distance = Vector3.Distance(characherTransform.position, targetInteractPosition);

        if (distance > START_MOVE_DISTANCE)
        {
            StartComingUp(targetInteractPosition);
        }
        if (distance <= STOP_INTERACT_DISTANCE)
        {
            StopMove(characherTransform.position, targetInteractPosition);
            OnStartComingUp?.Invoke(false);
        }

        speed = Mathf.Clamp(speed, 0, 1);
    }

    protected void StartComingUp(Vector3 position)
    {
        agent.SetDestination(position);
        agent.isStopped = false;

        OnStartComingUp?.Invoke(true);
    }

    protected virtual void StartMove(Vector3 targetPosition)
    {
        OnStopMove.Invoke(false);
        
        StopAttack(targetPosition);

        if (distance > 0.7f)
            speed += 3.5f * Time.deltaTime;

        else if (distance < 0.7f)
        {
            if (speed > distance)
                speed -= 2 * Time.deltaTime;
            else speed += 2 * Time.deltaTime;
        }
    }

    protected virtual void StopMove(Vector3 characterPosition, Vector3 targetPosition)
    {
        speed -= 5 * Time.deltaTime;
        targetPosition = characterPosition;

        if (speed <= 0.2f)
        {
            agent.isStopped = true;
            OnStopMove.Invoke(true);

            speed = 0;
        }
    }
}
