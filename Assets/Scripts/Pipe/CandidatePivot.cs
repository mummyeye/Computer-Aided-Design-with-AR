using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandidatePivot : MonoBehaviour
{
    private GameObject[] candidates;
    private GameObject pivot;
    private void OnMouseDown()
    {
        pivot = this.gameObject.transform.parent.gameObject;

        GameObject.Find("Builder").gameObject.transform.position = pivot.transform.position;
        GameObject.Find("Builder").gameObject.transform.eulerAngles = pivot.transform.eulerAngles;

        UnableCandidatePivot();
    }

    private void UnableCandidatePivot()
    {
        candidates = GameObject.FindGameObjectsWithTag("CandidateBuilder");

        foreach (GameObject candidate in candidates)
        {
            candidate.transform.Find("Pivot").gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other) {
        this.gameObject.SetActive(false);
    }
}
