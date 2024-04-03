using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.core
{
    public abstract class State
    {
        public abstract void Enter();

        public abstract void Tick(float daltaTime);

        public abstract void Exit();

    }
}
