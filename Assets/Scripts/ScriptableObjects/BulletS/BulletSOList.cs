
using UnityEngine;

namespace BulletS
{
    [CreateAssetMenu(fileName = "BulletSOList", menuName = "ScriptableObject/Bullet/BulletSOList")]
    public class BulletSOList : ScriptableObject
    {
        public BulletSO[] bulletsTypes;

    }
}