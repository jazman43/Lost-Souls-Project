using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Saving;




namespace LostSouls.Puzzles
{
    public class PuzzleManager : MonoBehaviour , ISaveable
    {
        private Dictionary<int, List<Rotatable>> rotatablePuzzles = new Dictionary<int, List<Rotatable>>();

        private int puzzleIDNum;
        private bool isSolved;

        private Rotatable rotatable1;

        private void Awake()
        {
            InitialzeRotatablePuzzles();
        }

        public void RegisterRotatablePuzzlePiece(Rotatable rotatable)
        {
            rotatable1 = rotatable;
            if (!rotatablePuzzles.ContainsKey(rotatable.puzzleNumber))
            {
                rotatablePuzzles[rotatable.puzzleNumber] = new List<Rotatable>();
            }
            rotatablePuzzles[rotatable.puzzleNumber].Add(rotatable);
        }

        
        //call me on door to open
        public bool IsRotatablePuzzleSolved(int puzzleId)
        {
            Debug.Log(puzzleIDNum + " is solved Manager");
            if (rotatablePuzzles.ContainsKey(puzzleId))
            {
                Debug.Log("is open " + isSolved + " " + puzzleId);
                
                
                Debug.Log("puzzle " + puzzleId);
                foreach (Rotatable piece in rotatablePuzzles[puzzleId])
                {
                    if (piece.PuzzleAnswerCheck() && isSolved)
                    { 
                        return true; 
                    }
                    if (!piece.PuzzleAnswerCheck())
                    {
                        isSolved = false;
                        return false; //puzzle not solved
                    }
                }
                Debug.Log("puzzle " + puzzleId + " sovled");
                puzzleIDNum = puzzleId;
                isSolved = true;
                return true;
            }
            isSolved = false;
            return false;
        }

        public int getPuzzleId()
        {
            return puzzleIDNum;
        }

        public void InitialzeRotatablePuzzles()
        {
            foreach(Rotatable piece in FindObjectsOfType<Rotatable>())
            {
                RegisterRotatablePuzzlePiece(piece);
            }
        }

        public object CaptureState()
        {
            return isSolved;
        }

        public void RestoreState(object state)
        {
            isSolved = (bool)state;
        }
    }
}
