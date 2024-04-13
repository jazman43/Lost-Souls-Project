using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Saving;



namespace LostSouls.Puzzles
{
    public class OpenCloseDoors : MonoBehaviour ,ISaveable
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float stopHight = 1f;
        [SerializeField] private int puzzleID;
        [SerializeField] private bool isSovled = false;
        [SerializeField] private int howDoorOpen = 0; //0 = door down, 1 = door up, 2 = door normail.
        [SerializeField] private PuzzleManager puzzleManager;

        private void Awake()
        {
            //isSovled = puzzleManager.IsRotatablePuzzleSolved(puzzleID);
        }

        private void Update()
        {
            IsSolved();
        }

        private void IsSolved()
        {
            Debug.Log(isSovled + " is sovled" );
            if (puzzleManager.IsRotatablePuzzleSolved(puzzleID) || isSovled)
            {
                isSovled = true;
                switch (howDoorOpen)
                {
                    case 0:
                        OpenDoorDropDown();
                        break;
                    case 1:
                        OpenDoorUp();
                        break;
                    case 2:
                        //door open normal
                        break;
                }
            }
        }

        private void OpenDoorDropDown()
        {
            Vector3 doorMovement = new Vector3(0, -1 * speed * Time.deltaTime, 0);
           
            transform.Translate(doorMovement);

            Destroy(gameObject, 8f);
        }

        private void OpenDoorUp()
        {
            Vector3 doorMovement = new Vector3(0, 1 * speed * Time.deltaTime, 0);
            
            transform.Translate(doorMovement);

            Destroy(gameObject, 8f);
        }

        public object CaptureState()
        {
            return isSovled;
        }

        public void RestoreState(object state)
        {
            Debug.Log("Load is Sovled bool " + isSovled + " " + state);
            isSovled = (bool)state;
            
        }
    }
}

