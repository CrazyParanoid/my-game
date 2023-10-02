using UnityEngine;
using Zenject;

public class HeroInstaller : MonoInstaller
{
    [SerializeField]
    private HeroController controller;

    [SerializeField]
    private DialogWindow dialogWindow;

    [SerializeField]
    private ItemPanel itemPanel;

    [SerializeField]
    private Inventory inventory;

    public override void InstallBindings()
    {
        Container.Bind<HeroController>()
            .FromInstance(controller)
            .AsSingle()
            .NonLazy();
        Container.Bind<DialogWindow>()
            .FromInstance(dialogWindow)
            .AsSingle()
            .NonLazy();
        Container.Bind<ItemPanel>()
            .FromInstance(itemPanel)
            .AsSingle()
            .NonLazy();
        Container.Bind<Inventory>()
            .FromInstance(inventory)
            .AsSingle()
            .NonLazy();
    }
}