using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBuilder : MonoBehaviour
{
    private GameObject[] candidates;
    public void CallCandidates(){
        candidates = GameObject.FindGameObjectsWithTag("CandidateBuilder");

        foreach (GameObject candidate in candidates)
        {
            candidate.transform.Find("Pivot").gameObject.SetActive(true);
        }
    }
}
