using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class HeroController : BasicCharacterController<Hero>
{
    //Tags
    protected const string GROUND = "Ground";
    protected const string ENEMY = "Enemy";
    protected const string HERO = "Hero";
    protected const string PERSON = "Person";
    protected const string ITEM = "Item";

    private GameObject clickPointer;

    [Inject]
    private readonly ItemPanel itemPanel;

    [Inject]
    private readonly Inventory inventory;

    protected override void RunBehavior()
    {
        if (!character.IsDead())
        {
            healthBar.OnHealthReducedByDamage(character.CurrentHealth);
            UpdateAction();
        }
    }

    private void Awake()
    {
        clickPointer = transform.Find("ClickPointer").gameObject;
    }

    protected override void InitComponents()
    {
        base.InitComponents();
        characterMovement.OnStopMove += OnStopComingUp;
    }

    protected override CharacterNavigation CreateCharacterMovement(NavMeshAgent agent)
    {
        return new HeroMovement(agent, clickPointer);
    }

    private void UpdateAction()
    {
        OnRightButtonClick();
        OnIButtonClick();
    }

    private void OnRightButtonClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                switch (hit.transform.tag)
                {
                    case GROUND: SetActionToMove(hit.point); break;
                    case ENEMY: SetActionToAttack(hit.transform); break;
                    case HERO: SetActionToAttack(hit.transform); break;
                    case PERSON: SetActionToInteract(hit.transform); break;
                    case ITEM: SetActionToInteract(hit.transform); break;
                }
            }
        }
    }

    private void OnIButtonClick()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (itemPanel.IsVisible())
            {
                itemPanel.MakeInvisible();
            }
            else
            {
                itemPanel.MakeVisible();
            }
        }
    }

    protected override void SetActionToAttack(Transform transform)
    {
        transform.GetComponent<ISelectable>().Selected();
        base.SetActionToAttack(transform);
    }

    protected override void SetActionToMove(Vector3 position)
    {
        if (targetInteract != null)
        {
            targetInteract.transform.GetComponent<ISelectable>().Unselected();

        }
        base.SetActionToMove(position);
    }

    private void SetActionToInteract(Transform transform)
    {
        targetInteract = transform;
        action = Interact;
    }

    private void Interact()
    {
        targetInteract.GetComponent<ISelectable>().Selected();
        characterMovement.ComeUp(transform, targetInteract.position);
    }

    public override void Damage()
    {

        base.Damage();

        if (targetInteract != null)
        {
            NpcController npcController = targetInteract.GetComponent<NpcController>();
            Npc enemy = npcController.character;

            character.TakeExpirience(enemy);
        }
    }

    private void OnStopComingUp(bool stop)
    {
        if (stop)
        {
            action = () => { };
            if (targetInteract != null)
            {
                if (targetInteract.TryGetComponent<INteractable>(out var target))
                {
                    target.Interact();
                }
                if (targetInteract.TryGetComponent<DropItem>(out var item))
                {
                    inventory.AddItem(item);
                }

                targetInteract = null;
            }
        }
    }
}
