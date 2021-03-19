using UnityEngine;
using Zenject;

class HouseInstaller : MonoInstaller
{
    [SerializeField] private House _house;
    public override void InstallBindings()
    {
        Container.Bind<House>().FromInstance(_house).AsSingle().NonLazy();
    }
}