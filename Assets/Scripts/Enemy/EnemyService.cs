using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Others;
using EnemyS;
using Tank;

namespace Enemy
{
    public class EnemyService : GenericSingleton<EnemyService>
    {
        public EnemySOList enemyTypes;
        [HideInInspector] public EnemySO enemy;
        public List<EnemyController> enemies = new List<EnemyController>();
        private EnemyController enemyController;


        async public void SpawnWave(float enemyCount)
        {
            await new WaitForSeconds(TankService.instance.tankSpawnDelay + 1);
            for (int i = 0; i < enemyCount; i++)
            {
                CreateEnemy();
            }
        }
       
       

        private void CreateEnemy()
        {
            int rand = Random.Range(0, enemyTypes.enemies.Length);
            enemy = enemyTypes.enemies[rand];

            EnemyModel enemyModel = new EnemyModel(enemy);
            enemyController = new EnemyController(enemy.enemyView, enemyModel);

            enemies.Add(enemyController);
        }
        public EnemyController GetEnemyController()
        {
            return enemyController;
        }

        public void DestroyEnemy(EnemyController enemy)
        {
            enemy.DestoryController();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemy == enemies[i])
                {
                    enemies[i] = null;
                    enemies.Remove(enemies[i]);
                }
            }
            if (enemies.Count == 0)
            {
                Spawners.instance.SpawnWave();
            }

        }
        


        public void TurnOFFEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].view.gameObject.SetActive(false);
                }
            }
        }
        public void TurnONEnmeis()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].view.gameObject.SetActive(true);
                }
            }
        }
    }
}