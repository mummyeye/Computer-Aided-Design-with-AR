using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject builder;
    public GameObject pipe;
    public GameObject elbow;
    public GameObject te_01;
    private GameObject instantiatedObject;

    private float rotateX;
    private float rotateY;
    private float rotateZ;
    private string _value;
    private int _selection;

    #region "Property"
    public int Selection
    {
        get { return _selection; }
        set { _selection = value; }
    }
    public string Value {
        get { return _value; }
        set { _value = value; }
    }
    #endregion
    public void InstantiateObject(){
        switch (_selection)
        {
            case 0:
                instantiatedObject = Instantiate(pipe, builder.transform.position , Quaternion.identity).gameObject;
                instantiatedObject.transform.localScale = new Vector3(
                                                                    instantiatedObject.transform.localScale.x,
                                                                    float.Parse(_value),
                                                                    instantiatedObject.transform.localScale.z);
                instantiatedObject.transform.eulerAngles = builder.transform.eulerAngles;
                builder.transform.position = instantiatedObject.transform.Find("Tail").gameObject.transform.position;
            break;
                
            case 1:
                instantiatedObject = Instantiate(elbow, builder.transform.position , Quaternion.identity).gameObject;
                instantiatedObject.transform.eulerAngles = builder.transform.eulerAngles;
                instantiatedObject.transform.Rotate(0,float.Parse(_value),0);
                builder.transform.position = instantiatedObject.transform.Find("Tail").gameObject.transform.position;
                builder.transform.eulerAngles = instantiatedObject.transform.Find("Tail").gameObject.transform.eulerAngles;
            break;

            case 2:
                instantiatedObject = Instantiate(te_01, builder.transform.position , Quaternion.identity).gameObject;
                instantiatedObject.transform.eulerAngles = builder.transform.eulerAngles;
                instantiatedObject.transform.Rotate(0,float.Parse(_value),0);
                builder.transform.position = instantiatedObject.transform.Find("Tail").gameObject.transform.position;
                builder.transform.eulerAngles = instantiatedObject.transform.Find("Tail").gameObject.transform.eulerAngles;
            break;
        }
        instantiatedObject.transform.parent = GameObject.Find("ImageTarget").transform;
    }

}