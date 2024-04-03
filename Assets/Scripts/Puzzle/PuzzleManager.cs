using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.Puzzles
{
    public class PuzzleManager : MonoBehaviour
    {
        private Dictionary<int, List<Rotatable>> rotatablePuzzles = new Dictionary<int, List<Rotatable>>();

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
            if (rotatablePuzzles.ContainsKey(puzzleId))
            {
                Debug.Log($"puzzle {puzzleId}");
                foreach (Rotatable piece in rotatablePuzzles[puzzleId])
                {
                    if (!piece.PuzzleAnswerCheck())
                    {
                        return false; //puzzle not solved
                    }
                }
                Debug.Log($"puzzle {puzzleId} sovled");
                return true;
            }
            return false;
        }

        public void InitialzeRotatablePuzzles()
        {
            foreach(Rotatable piece in FindObjectsOfType<Rotatable>())
            {
                RegisterRotatablePuzzlePiece(piece);
            }
        }
    }
}
