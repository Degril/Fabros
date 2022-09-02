using Components.Both.Character;
using Components.Both.Character.Movement;
using Components.Client.CharacterMovement;
using Components.Server.CharacterMovement;
using Leopotam.Ecs;

namespace Systems.Client
{
    public class AnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AnimationComponent, MovableStateComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var animationComponent = _filter.Get1(i);
                var movableStateComponent = _filter.Get2(i);
                
                animationComponent.Animator.SetFloat("speed", movableStateComponent.CurrentSpeed);
            }
        }
    }
}