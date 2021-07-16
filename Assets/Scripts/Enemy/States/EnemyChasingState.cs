
using Tank;
using UnityEngine;

namespace Enemy
{
    public class EnemyChasingState : EnemyStates
    {
        private bool canChase;
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.activeState = EnemyState.Chasing;
            Chase();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                enemyView.SetTankView(other.gameObject.GetComponent<TankView>());
                ChangeState(this);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (enemyView.activeState == EnemyState.Attacking || !canChase) return;


            if (other.gameObject.GetComponent<TankView>() != null)
                Chase();

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {

                ChangeState(enemyView.patrollingState);
            }
        }
        async private void Chase()
        {
            canChase = false;

            enemyView.navMeshAgent.isStopped = true;
            enemyView.navMeshAgent.ResetPath();
            enemyView.navMeshAgent.SetDestination(enemyView.GetTankTransform().position);
            await new WaitForSeconds(2f);

            canChase = true;
        }
    }
}