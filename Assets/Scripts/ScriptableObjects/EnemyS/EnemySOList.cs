
using UnityEngine;
namespace EnemyS
{
    [CreateAssetMenu(fileName = "EnemySOList", menuName = "ScriptableObject/Enemy/EnemySOList")]
    public class EnemySOList : ScriptableObject
    {
        public EnemySO[] enemies;

    }
}