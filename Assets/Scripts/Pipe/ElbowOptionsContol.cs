using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowOptionsContol : MonoBehaviour
{
    private float rotationValue = 45f;
    private void OnMouseDown() {
        this.gameObject.transform.Rotate(0,rotationValue,0);

        GameObject.Find("Builder").transform.position = this.gameObject.transform.Find("Tail").gameObject.transform.position;
        GameObject.Find("Builder").transform.eulerAngles = this.gameObject.transform.Find("Tail").gameObject.transform.eulerAngles;
    }
}
