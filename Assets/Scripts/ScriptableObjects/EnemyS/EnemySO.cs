
using UnityEngine;
using Enemy;
using BulletS;


namespace EnemyS
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObject/Enemy/Enemy")]
    public class EnemySO : ScriptableObject
    {
       
        public EnemyType enemyType;

        public EnemyView enemyView;

        public float health;

        public float movementSpeed;
        public float rotationSpeed;
        public float patrollingRadius;
        public float patrolTime;


        public float fireRate;
        public float attackDistace;
        public BulletSO bulletType;

        public Material Material;
        public float ScaleMultiplier = 1;
    }


}
