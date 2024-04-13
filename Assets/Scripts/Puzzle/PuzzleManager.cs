using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Saving;



namespace LostSouls.Puzzles
{
    public class PuzzleManager : MonoBehaviour , ISaveable
    {
        private Dictionary<int, List<Rotatable>> rotatablePuzzles = new Dictionary<int, List<Rotatable>>();

        private int isSolved;
        

        private void Awake()
        {
            InitialzeRotatablePuzzles();
        }

        public void RegisterRotatablePuzzlePiece(Rotatable rotatable)
        {
            if (!rotatablePuzzles.ContainsKey(rotatable.puzzleNumber))
            {
                rotatablePuzzles[rotatable.puzzleNumber] = new List<Rotatable>();
            }
            rotatablePuzzles[rotatable.puzzleNumber].Add(rotatable);
        }

        
        //call me on door to open
        public bool IsRotatablePuzzleSolved(int puzzleId)
        {
            Debug.Log(isSolved + " is solved Manager");
            if (rotatablePuzzles.ContainsKey(puzzleId))
            {
                if(isSolved == 1)
                {
                    return true;
                }
                Debug.Log($"puzzle {puzzleId}");
                foreach (Rotatable piece in rotatablePuzzles[puzzleId])
                {
                    if (!piece.PuzzleAnswerCheck())
                    {
                        isSolved = 0;
                        return false; //puzzle not solved
                    }
                }
                Debug.Log($"puzzle {puzzleId} sovled");
                isSolved = 1;
                return false;
            }
            isSolved = 0;
            return false;
        }

        public void InitialzeRotatablePuzzles()
        {
            foreach(Rotatable piece in FindObjectsOfType<Rotatable>())
            {
                RegisterRotatablePuzzlePiece(piece);
            }
        }

        public void RestoreState(object state)
        {
            Debug.Log("Loading Restore State" + state);
            isSolved = (int)state;            
        }

        public object CaptureState()
        {
            Debug.Log(isSolved + " is solved saved");
            return isSolved;
        }

        
    }
}
