using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool isFaceAEnable;
    public bool isFaceBEnable;
    public GameObject pipeMenu;
    public GameObject objectA;
    public GameObject objectB;
    private GameObject objectInstantiated;


    void Start(){
        isFaceAEnable = true;
        isFaceBEnable = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("d");
        if (!Simulator.selectMode)
        {
            if(isFaceAEnable){objectA.SetActive(true);}
            if(isFaceBEnable){objectB.SetActive(true);}
            Simulator.selectedObject = this.gameObject;
            Simulator.selectMode = true;
            pipeMenu.SetActive(true);
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                switch (hit.collider.name)
                {
                    case "pipeFaceA":
                        isFaceAEnable = false;
                        objectInstantiated = Instantiate(this, hit.collider.transform.position, Quaternion.identity).gameObject;
                        objectInstantiated.transform.Find("pipeFaceA").gameObject.SetActive(false);
                        objectInstantiated.transform.Find("pipeFaceB").gameObject.SetActive(false);
                        objectInstantiated.GetComponent<Pipe>().isFaceBEnable = false;
                        break;
                    case "pipeFaceB":
                        isFaceBEnable = false;
                        objectInstantiated = Instantiate(this, hit.collider.transform.position, Quaternion.identity).gameObject;
                        objectInstantiated.transform.Find("pipeFaceA").gameObject.SetActive(false);
                        objectInstantiated.transform.Find("pipeFaceB").gameObject.SetActive(false);
                        //objectInstantiated.GetComponent<Pipe>().isFaceAEnable = false;
                        objectInstantiated.transform.GetComponent<Pipe>().isFaceAEnable = false;
                        break;
                    default:
                        break;
                }
            }
            Simulator.selectMode = false;
            Simulator.selectedObject = this.gameObject;
            pipeMenu.SetActive(false);
            objectA.SetActive(false);
            objectB.SetActive(false);
        }


    }


}
