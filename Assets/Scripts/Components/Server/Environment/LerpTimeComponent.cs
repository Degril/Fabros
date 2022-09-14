using System;

namespace Components.Server.Environment
{
    [Serializable]
    public struct LerpTimeComponent
    {
        public float StartTime;
        public float StartPercent;
        public float EndTime;
    }
}