using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Enemy
{
    public class EnemyStates : MonoBehaviour
    {
        public EnemyView enemyView;

        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }
        public virtual void OnStateExit()
        {
            this.enabled = false;
        }


        public void ChangeState(EnemyStates newState)
        {
            if (enemyView.currentState != null)
                enemyView.currentState.OnStateExit();

            enemyView.currentState = newState;
            enemyView.currentState.OnStateEnter();
        }
    }
}
