
using UnityEngine;
using Tank;
using BulletS;

namespace TankS
{
    [CreateAssetMenu(fileName = "TankSO", menuName = "ScriptableObject/Tank/TankSO")]
    public class TankSO : ScriptableObject
    {
    
        public TankType tankType;

        public TankView tankView;

        public float health;

        public float movementSpeed;
        public float rotationSpeed;

        public float fireRate;
        public BulletSO bulletType;
        public Material material;
    }
}