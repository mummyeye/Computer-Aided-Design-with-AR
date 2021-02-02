using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject builder;
    public List<GameObject> components = new List<GameObject>();
    public Dropdown dropdown;
    private GameObject instantiatedObject;
    private float rotateX;
    private float rotateY;
    private float rotateZ;
    private string _value;
    private int _inputType;
    private int _selection;

    #region "Property"
    public int Selection
    {
        get { return _selection; }
        set { _selection = value; }
    }
    public string Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public int InputType
    {
        get { return _inputType; }
        set { _inputType = value; }
    }

    #endregion
    
    private void Awake() {
        SetDropDownValues();
    }

    public void InstantiateObject()
    {
        components.ForEach(component =>
        {
            if (component.name == dropdown.options[_selection].text)
            {
                instantiatedObject = Instantiate(component, builder.transform.position, Quaternion.identity).gameObject;

                if (InputType == 0)
                {
                    instantiatedObject.transform.localScale = new Vector3(
                                                                    instantiatedObject.transform.localScale.x,
                                                                    float.Parse(_value),
                                                                    instantiatedObject.transform.localScale.z);
                    instantiatedObject.transform.eulerAngles = builder.transform.eulerAngles;
                }

                if (InputType == 1)
                {
                    instantiatedObject.transform.eulerAngles = builder.transform.eulerAngles;
                    instantiatedObject.transform.Rotate(0, float.Parse(_value), 0);
                }

                builder.transform.position = instantiatedObject.transform.Find("Tail").gameObject.transform.position;
                builder.transform.eulerAngles = instantiatedObject.transform.Find("Tail").gameObject.transform.eulerAngles;
            }
        });

        instantiatedObject.transform.parent = GameObject.Find("ImageTarget").transform;
    }

    private void SetDropDownValues(){
        components.ForEach(component => {
            dropdown.options.Add(new Dropdown.OptionData(component.name));
        });
    }
}