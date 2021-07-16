
using UnityEngine;

namespace Others
{
    public class VFXService : GenericSingleton<VFXService>
    {
        public void InstantiateEffects(GameObject Effects, Vector3 position)
        {
            GameObject gameObject = Instantiate(Effects, position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }
    }
}
