using Components.Client.Character;
using Components.Client.Character.Movement;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Client
{
    public class MovementAnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AnimationComponent, MovableStateComponent> _filter;
        private static readonly int Speed = Animator.StringToHash("speed");

        public void Run()
        {
            foreach (var i in _filter)
            {
                var animationComponent = _filter.Get1(i);
                var movableStateComponent = _filter.Get2(i);
                
                animationComponent.Animator.SetFloat(Speed, movableStateComponent.CurrentSpeed);
            }
        }
    }
}