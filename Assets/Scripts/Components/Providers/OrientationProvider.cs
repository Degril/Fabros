using Components.Server.Character;
using Voody.UniLeo;

namespace Components.Providers
{
    public class OrientationProvider : MonoProvider<OrientationComponent>
    {
        private void Awake()
        {
            value.Position = transform.position;
            value.Rotation = transform.rotation;
        }
    }
}