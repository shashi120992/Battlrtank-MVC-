using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using Tank;

namespace Others
{
    public class Spawners : GenericSingleton<Spawners>
    {
        private float currentWave;

        [SerializeField] private Transform[] Quarter1 = new Transform[5];
        [SerializeField] private Transform[] Quarter2 = new Transform[5];
        [SerializeField] private Transform[] Quarter3 = new Transform[5];
        [SerializeField] private Transform[] Quarter4 = new Transform[5];

        private TankQuarter currentQuarter;

        private void Start()
        {
            SpawnWave();
        }

        public Vector3 GetRandomPosition()
        {
            currentQuarter = TankService.instance.GetTankController().tankView.GetQuarter();
            int randTransform = Random.Range(0, 5);
            int randQuarter = Random.Range(1, 4);

            if (currentQuarter == TankQuarter.Quarter1)
            {
                if (randQuarter == 1)
                {
                    return Quarter2[randTransform].position;
                }
                else if (randQuarter == 2)
                {
                    return Quarter3[randTransform].position;
                }
                else if (randQuarter == 3)
                {
                    return Quarter4[randTransform].position;
                }
            }
            else if (currentQuarter == TankQuarter.Quarter2)
            {
                if (randQuarter == 1)
                {
                    return Quarter1[randTransform].position;
                }
                else if (randQuarter == 2)
                {
                    return Quarter3[randTransform].position;
                }
                else if (randQuarter == 3)
                {
                    return Quarter4[randTransform].position;
                }
            }
            else if (currentQuarter == TankQuarter.Quarter3)
            {
                if (randQuarter == 1)
                {
                    return Quarter1[randTransform].position;
                }
                else if (randQuarter == 2)
                {
                    return Quarter2[randTransform].position;
                }
                else if (randQuarter == 3)
                {
                    return Quarter4[randTransform].position;
                }
            }
            else if (currentQuarter == TankQuarter.Quarter4)
            {
                if (randQuarter == 1)
                {
                    return Quarter1[randTransform].position;
                }
                else if (randQuarter == 2)
                {
                    return Quarter2[randTransform].position;
                }
                else if (randQuarter == 3)
                {
                    return Quarter3[randTransform].position;
                }
            }

            return new Vector3(0, 0, 0);
        }

        public void SpawnWave()
        {
            currentWave++;
            float enemyiesTobeSpawned = Mathf.Pow(2, (currentWave - 1));
            EnemyService.instance.SpawnWave(enemyiesTobeSpawned);
        }
    }

}