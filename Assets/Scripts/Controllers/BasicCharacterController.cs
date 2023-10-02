using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class BasicCharacterController<T> : MonoBehaviour, ICharacterController where T : Character
{
    public GameObject healtBar;

    public T character;

    protected NavMeshAgent agent;
    protected Animator animator;
    protected CapsuleCollider capsuleCollider;

    //Body
    public Transform[] bodyElements;

    //Variables
    protected const string WALK = "Walk";
    protected const string ATTACK = "Attack";

    //Target
    protected Vector3 target;
    protected Transform targetInteract;

    [SerializeField]
    protected HealthBar healthBar;

    //Hit
    private GameObject hitEffect;

    protected CharacterNavigation characterMovement;

    protected Action action;

    void Start()
    {
        InitComponents();
    }

    protected virtual void InitComponents()
    {
        action = DisableAnimations;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        characterMovement = CreateCharacterMovement(agent);
        characterMovement.OnStopMove += OnMovementStop;
        characterMovement.OnStopAttack += OnStopAttack;
        characterMovement.OnStartAttack += OnStartAttack;
        characterMovement.OnStartComingUp += OnStartInteract;

        character.OnHealthReducedByDamage += healthBar.OnHealthReducedByDamage;
        character.OnDeath += OnDeath;
        hitEffect = transform.Find("HitEffect").gameObject;
    }

    protected virtual  CharacterNavigation CreateCharacterMovement(NavMeshAgent agent)
    {
        return new CharacterNavigation(agent);
    }

    void Update()
    {
        action?.Invoke();
        RunBehavior();
    }

    protected abstract void RunBehavior();

    protected void DisableAnimations()
    {
        animator.SetBool(WALK, false);
        animator.SetBool(ATTACK, false);
    }

    protected virtual void SetActionToMove(Vector3 position)
    {
        target = position;
        targetInteract = null;
        action = Move;
    }

    protected virtual void SetActionToAttack(Transform transform)
    {
        targetInteract = transform;
        action = Attack;
    }

    protected void Move()
    {
        characterMovement.Move(transform.position, target);
    }

    protected void Attack()
    {
        characterMovement.Attack(transform, targetInteract.position);
    }

    protected void TurnTowardsTheTarget()
    {
        Vector3 direction = (targetInteract.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }

    public virtual void Damage()
    {
        if (targetInteract != null)
        {
            var characterCotroller = targetInteract.GetComponent<ICharacterController>();

            characterCotroller.ReceiveDamage(character.Damage(), transform);
            if (characterCotroller.IsDead())
            {
                action = DisableAnimations;
            }
        }
    }

    public bool IsDead()
    {
        return character.IsDead();
    }

    public Character Character()
    {
        return character;
    }

    public virtual void ReceiveDamage(Hit hit, Transform target)
    {
        GameObject newHitEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        newHitEffect.SetActive(true);

        Destroy(newHitEffect, 2f);

        character.ReceiveDamage(hit);
    }

    //Events
    protected void OnMovementStop(bool stop)
    {
        if (stop)
        {
            action = () => { };
            DisableAnimations();
        }
    }

    protected void OnStartAttack(bool start)
    {
        if (start)
        {
            animator.SetBool(WALK, false);
            animator.SetBool(ATTACK, true);
        }
    }

    protected void OnStartInteract(bool start)
    {
        if (start)
        {
            animator.SetBool(WALK, true);
            animator.SetBool(ATTACK, false);
        }
    }

    protected void OnStopAttack(bool stop)
    {
        if (stop)
        {
            animator.SetBool(WALK, true);
            animator.SetBool(ATTACK, false);
        }
    }

    protected virtual void OnDeath(bool dead)
    {
        if (dead)
        {
            action = () => { };

            DisableAnimations();

            capsuleCollider.enabled = false;
            animator.enabled = false;

            foreach (Transform body in bodyElements)
            {
                body.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
