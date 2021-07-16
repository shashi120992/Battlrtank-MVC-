using UnityEngine;
using Others;
using Bullet;
using BulletS;
using Sound;

namespace Tank
{
    public class TankController
    {
        public TankModel tankModel { get; private set; }
        public TankView tankView { get; private set; }
        private Rigidbody rigidbody;


        public TankController(TankModel _tankModel, TankView _tankView) //Tank constructor
        {

            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            CameraController.instance.SetTarget(tankView.transform);
            rigidbody = tankView.GetComponent<Rigidbody>();
            tankView.SetTankController(this);
            tankModel.SetTankController(this);
            tankView.ChangeColor(tankModel.material);
        }
        

        public void Move(float movement, float movementSpeed)
        {
            Vector3 move = tankView.transform.transform.position += tankView.transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(move);
        }

        public void Rotate(float rotation, float rotateSpeed)
        {
            Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
            Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        }

        public void ShootBullet()
        {
            SoundManager.instance.PlaySoundAtTrack1(tankView.BulletShootSound, 1f, 64, true);
            EventService.instance.InvokeOnPlayerFiredBulletEvent();
            BulletService.instance.CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }
        

        public Vector3 GetFiringPosition()
        {
            return tankView.BulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return tankView.transform.rotation;
        }
        public BulletSO GetBullet()
        {
            return tankModel.bulletType;
        }
        public Vector3 GetCurrentTankPosition()
        {
            return tankView.transform.position;
        }

        public void DestroyController()
        {
            SoundManager.instance.PlaySoundAtTrack1(tankView.TankDestroySound, 1f, 10, true);
            VFXService.instance.InstantiateEffects(tankView.TankDestroyVFX, tankView.transform.position);
            tankModel.DestroyModel();
            tankView.DestroyView();
            tankModel = null;
            tankView = null;
            rigidbody = null;
        }
       


        private void Dead()
        {
            TankService.instance.DestroyTank(this);
        }
        public void ApplyDamage(float damage)
        {
            tankModel.health -= damage;

            if (tankModel.health <= 0)
            {
                Dead();
            }
        }
    }
}