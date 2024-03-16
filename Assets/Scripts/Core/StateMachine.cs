using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.core
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State currentState;

        //the ? is for null checking only works with state as state is not a MonoBehaviour
        
        private void Update()
        {            
            currentState?.Tick(Time.deltaTime);
        }


        public void SwitchState(State newState)
        {
            //? to prefom null checks
            //exit old state
            currentState?.Exit();
            //set new state
            currentState = newState;
            //enter new state
            currentState?.Enter();
        }
    }

}