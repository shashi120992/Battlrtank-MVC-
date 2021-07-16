using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletS;

namespace Bullet
{
    public class BulletModel
    {
        public float speed { get; private set; }
        public float damage { get; private set; }
        public BulletType type;
        private BulletController bulletController;

        public BulletModel(BulletSO bullet)
        {
            speed = bullet.speed;
            damage = bullet.damage;
            type = bullet.bulletType;
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        public void DestroyModel()
        {
            bulletController = null;
        }
    }

}