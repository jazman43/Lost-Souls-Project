using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.Puzzles
{
    public class OpenCloseDoors : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private int puzzleID;
        [SerializeField] private int howDoorOpen = 0; //0 = door down, 1 = door up, 2 = door normail.
        [SerializeField] private PuzzleManager puzzleManager;

        private void Update()
        {
            isSolved();
        }

        private void isSolved()
        {
            Debug.Log(puzzleManager.IsRotatablePuzzleSolved(puzzleID));
            if (puzzleManager.IsRotatablePuzzleSolved(puzzleID))
            {
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
        }

        private void OpenDoorUp()
        {
            Vector3 doorMovement = new Vector3(0, 1 * speed * Time.deltaTime, 0);
            transform.Translate(doorMovement);
        }
    }
}

