using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Others;
using BulletS;

namespace Bullet
{
    public class BulletService : GenericSingleton<BulletService>
    {

        private List<BulletController> bullets = new List<BulletController>();
        public void CreateBullet(Vector3 position, Quaternion rotation, BulletSO type)
        {
            BulletSO bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, position, rotation);
            bullets.Add(bulletController);
        }

        public void DestroyBullet(BulletController bullet)
        {
            if (bullet != null)
                bullet.DestroyController();

            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] == bullet)
                {
                    bullets[i] = null;
                    bullets.Remove(bullets[i]);
                }
            }
        }
    }
}
