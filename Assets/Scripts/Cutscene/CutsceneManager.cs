using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public bool isActivated;
    private void Awake()
    {
        StartCoroutine(DialogueSequence());
    }
    private IEnumerator DialogueSequence()
    {
        for (int i=0; i<transform.childCount; i++)
        {
            ClearTextBox();
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
        }
        GameObject.FindGameObjectWithTag("Cutscene").SetActive(false);
    }
    private void ClearTextBox()
    {
        for (int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
