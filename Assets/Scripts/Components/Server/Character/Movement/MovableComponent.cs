using Leopotam.Ecs;
using UnityEngine;

namespace Components.Both.Character.Movement
{
    public struct MovableComponent : IEcsAutoReset<MovableComponent>
    {
        public Vector3 FromPosition { get; set; }
        public Vector3 TargetPosition { get; set; }
        public float MovingEndTime { get; set; }
        public float MovingStartTime { get; set; }
        
        public void AutoReset(ref MovableComponent c)
        {
            c.FromPosition = Vector3.zero;
            c.TargetPosition = Vector3.zero;
            c.MovingEndTime = 0;
            c.MovingStartTime = 0;
        }
    }
}