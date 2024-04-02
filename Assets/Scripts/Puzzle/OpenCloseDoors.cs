using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.Puzzles
{
    public class OpenCloseDoors : MonoBehaviour
    {
        public void OpenDoorDropDown(float speed)
        {
            Vector3 doorMovement = new Vector3(0, -1 * speed * Time.deltaTime, 0);
            transform.Translate(doorMovement);
        }

        public void OpenDoorUp(float speed)
        {
            Vector3 doorMovement = new Vector3(0, 1 * speed * Time.deltaTime, 0);
            transform.Translate(doorMovement);
        }
    }
}

