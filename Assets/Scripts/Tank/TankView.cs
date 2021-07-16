using UnityEngine;
using Sound;
using Others;

namespace Tank
{
    public class TankView : MonoBehaviour, IDamagable
    {
        public GameObject TankDestroyVFX;
        public AudioClip TankDestroySound;
        public AudioClip BulletShootSound;
        public AudioClip TankIdleSound;
        public AudioClip TankMovingSound;
        private float rotation;
        private float movement;
        private float canFire = 0f;
        
        public Transform BulletShootPoint;
        public MeshRenderer[] childs;
        private TankQuarter currentQuarter;


        private TankController tankController;

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        private void Update()
        {
            Movement();
            ShootBullet();
        }
        private void FixedUpdate()
        {
            if (movement != 0)
            {
                tankController.Move(movement, tankController.tankModel.movementSpeed);
                SoundManager.instance.MovingSoundTrack(TankMovingSound, 0.1f, 256, false);
            }
            else
            {
                SoundManager.instance.MovingSoundTrack(TankIdleSound, 0.1f, 256, false);
            }

            if (rotation != 0)
                tankController.Rotate(rotation, tankController.tankModel.rotationSpeed);
        }

        public TankQuarter GetQuarter()
        {
            Debug.Log(currentQuarter);
            return currentQuarter;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Q1"))
            {
                currentQuarter = TankQuarter.Quarter1;
            }
            else if (other.CompareTag("Q2"))
            {
                currentQuarter = TankQuarter.Quarter2;
            }
            else if (other.CompareTag("Q3"))
            {
                currentQuarter = TankQuarter.Quarter3;
            }
            else if (other.CompareTag("Q4"))
            {
                currentQuarter = TankQuarter.Quarter4;
            }
        }
        private void Movement()
        {
            rotation = Input.GetAxis("Horizontal");
            movement = Input.GetAxis("Vertical");
        }

        private void ShootBullet()
        {
            if (Input.GetButton("Fire1") && canFire < Time.time)
            {
                canFire = tankController.tankModel.fireRate + Time.time;
                tankController.ShootBullet();
            }
        }
        public void ChangeColor(Material material)
        {
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].material = material;
            }
        }

        public void DestroyView()
        {
            for (int i = 0; i < childs.Length; i++)
                childs[i] = null;
            tankController = null;
            BulletShootPoint = null;
            TankDestroyVFX = null;
            Destroy(this.gameObject);
        }


        public void TakeDamage(float damage)
        {
            tankController.ApplyDamage(damage);
        }
    }
}