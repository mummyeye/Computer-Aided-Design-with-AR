using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other) {
        this.gameObject.SetActive(true);
    }
}
