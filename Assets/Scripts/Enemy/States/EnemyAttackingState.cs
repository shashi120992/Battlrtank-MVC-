using System.Collections;
using System.Collections.Generic;
using Tank;
using UnityEngine;


namespace Enemy
{
    public class EnemyAttackingState : EnemyStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.activeState = EnemyState.Attacking;
        }
        public override void OnStateExit()
        {
            base.OnStateExit();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                enemyView.navMeshAgent.isStopped = true;
                enemyView.navMeshAgent.ResetPath();
                ChangeState(this);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                Vector3 lookDir = other.transform.position - enemyView.transform.position;
                if (lookDir != new Vector3(0, 0, 0))
                    RotateTowardsTarget();

                enemyView.controller.Attack();
            }
        }

        private void RotateTowardsTarget()
        {
            enemyView.transform.LookAt(enemyView.GetTankTransform());
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                ChangeState(enemyView.chasingState);
            }
        }
    }
}