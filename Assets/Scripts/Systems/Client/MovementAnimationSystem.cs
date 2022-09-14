using Components.Client.Character;
using Components.Client.Character.Movement;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems.Client
{
    public class MovementAnimationSystem : IEcsRunSystem
    {
        private static readonly int Speed = Animator.StringToHash("speed");
       
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var filter = world.Filter<AnimationComponent>()
                .Inc<MovableStateComponent>().End ();
            
            foreach (var entity in filter)
            {
                var animationComponent = world.GetPool<AnimationComponent>().Get(entity);
                var movableStateComponent = world.GetPool<MovableStateComponent>().Get(entity);
                
                animationComponent.Animator.SetFloat(Speed, movableStateComponent.CurrentSpeed);
            }
        }
    }
}