using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public GameObject pipe;
    private GameObject instantiated;
    private GameObject face;
    // Start is called before the first frame update
    private void OnMouseDown() {
        instantiated = Instantiate(pipe, this.transform.position, Quaternion.identity);
        //pessoa selecionou a face A
        face = instantiated.transform.Find("faceA").gameObject;
        face.transform.position = this.transform.position;
        face.transform.rotation = this.transform.rotation;


        face.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 90,this.transform.eulerAngles.y,this.transform.eulerAngles.z);
    }
}
