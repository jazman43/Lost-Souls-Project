using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class ChangeScene : MonoBehaviour
{
    public Flowchart FlowchartPuzzle;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("SavingShild"))
        {
            SceneManager.LoadScene("PuzzleDialog");
        }

    }

    private void OnDialogFinished()
    {
        SceneManager.LoadScene("lvl2");
    }
}