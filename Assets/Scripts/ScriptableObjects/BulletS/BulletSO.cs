using System;
using UnityEngine;
using Bullet;

namespace BulletS
{
    [CreateAssetMenu(fileName = "NewBulletSO", menuName = "ScriptableObject/Bullet/Bullet")]
    public class BulletSO : ScriptableObject
    {
        public BulletView bulletView;

        public float speed;
        public float damage;
        public BulletType bulletType;

    }

}