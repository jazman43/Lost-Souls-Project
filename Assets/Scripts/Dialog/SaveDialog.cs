using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Saving;


namespace LostSouls.Dialog
{
    public class SaveDialog : MonoBehaviour , ISaveable
    {

        private bool isAlreadySaid;
        
        public bool IsAlreadySaid(bool isAlreadySaid)
        {
            
            if (this.isAlreadySaid)
            {
                //returns false then no play
                return false;
            }
            this.isAlreadySaid = isAlreadySaid;

            return true;
        }


        public object CaptureState()
        {
            return isAlreadySaid;
        }

        public void RestoreState(object state)
        {
            isAlreadySaid = (bool)state;
        }
    }
}

