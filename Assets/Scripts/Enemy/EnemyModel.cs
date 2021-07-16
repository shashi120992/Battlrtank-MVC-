using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EnemyS;
using BulletS;

namespace Enemy
{
    public class EnemyModel
    {
        //Enemy Type
        public EnemyType enemyType { get; private set; }

        //Movement and attack
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float patrollingRadius { get; private set; }
        public float patrolTime { get; private set; }
        public float fireRate { get; private set; }
        public float attackDist { get; private set; }
        public BulletSO bullet { get; private set; }

        //health
        public float health { get; set; }
        private EnemyController controller;

        //visuals
        public Material material { get; private set; }
        public float scaleMultiplier { get; private set; }


        public EnemyModel(EnemySO enemyData)
        {
            enemyType = enemyData.enemyType;
            movementSpeed = enemyData.movementSpeed;
            rotationSpeed = enemyData.rotationSpeed;
            patrollingRadius = enemyData.patrollingRadius;
            patrolTime = enemyData.patrolTime;
            fireRate = enemyData.fireRate;
            attackDist = enemyData.attackDistace;
            bullet = enemyData.bulletType;
            health = enemyData.health;
            material = enemyData.Material;
            scaleMultiplier = enemyData.ScaleMultiplier;
        }

        

        public void SetEnemyController(EnemyController _controller)
        {
            controller = _controller;
        }
        public void DestroyModel()
        {
            bullet = null;
            controller = null;
            material = null;
        }
    }
}