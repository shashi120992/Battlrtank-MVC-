using UnityEngine;

namespace TankS
{
    [CreateAssetMenu(fileName = "TankSOList", menuName = "ScriptableObject/Tank/TankSOList")]
    public class TankSOList : ScriptableObject
    {
        public TankSO[] tanks;
    }
}