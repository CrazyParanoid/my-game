using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NpcController : BasicNpcController<Npc>
{
    private float timer;

    private const string ATTACKED = "Attacked";

    public GameObject[] wayPoints;

    private List<DropItem> dropItems;

    protected override void InitComponents()
    {
        character = (Npc)character.Copy();
        healthBar.OnHealthReducedByDamage(character.CurrentHealth);
        dropItems = GetComponentsInChildren<DropItem>().ToList();

        base.InitComponents();
    }

    private void TakeBattlePose()
    {
        if (character.IsAattacked())
        {
            TurnTowardsTheTarget();
            animator.SetBool(ATTACKED, true);
        }
        else
        {
            animator.SetBool(ATTACKED, false);
        }
    }

    private float GeneratePatrollTimer() => Random.Range(25, 36);

    protected override void OnDeath(bool dead)
    {
        if (dead)
        {
            base.OnDeath(dead);
            targetPointer.SetActive(false);
            Destroy(gameObject, 5f);

            Drop();
        }
    }

    private void Drop()
    {
        var items = new HashSet<DropItem>();

        for (int i = 0; i < dropItems.Count; i++)
        {
            var dropItem = ChanceUtil.TakeRandomByChance(dropItems, 0);
            if (!dropItem.IsEmpty())
            {
                items.Add(dropItem);
            }
        }

        foreach (var item in items)
        {
            item.transform.position = transform.position;
        }
    }

    public override void ReceiveDamage(Hit hit, Transform target)
    {
        SetActionToAttack(target);
        base.ReceiveDamage(hit, target);
    }

    private void Patroll()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !character.IsAattacked())
        {
            var wayPointIndex = Random.Range(0, wayPoints.Length);
            SetActionToMove(wayPoints[wayPointIndex].transform.position);

            timer = GeneratePatrollTimer();
        }
    }

    private void SetAttackedToFalseIfEnemyDead()
    {
        if (targetInteract != null)
        {
            var enemy = targetInteract.GetComponent<ICharacterController>();

            character.SetAttackedToFalseIfEnemyDead(enemy.Character());
        }
    }

    protected override void RunBehavior()
    {
        if (!character.IsDead())
        {
            if (patroll) Patroll();
            SetAttackedToFalseIfEnemyDead();
            TakeBattlePose();
        }
    }
}