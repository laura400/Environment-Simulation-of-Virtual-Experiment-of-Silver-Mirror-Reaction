using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;
using UnityEngine.UI;

public class C6H12O6_ui : MonoBehaviour
{

    [Tooltip("left controller")]
    public GameObject leftController;
    [Tooltip("right controller")]
    public GameObject rightController;

    //Grab interface
    private VRTK_InteractGrab leftGrab;
    private VRTK_InteractGrab rightGrab;

    public GameObject C6H12O6;

    // Start is called before the first frame update
    void Start()
    {
        if(leftController != null)
        {
            leftGrab = leftController.GetComponent<VRTK_InteractGrab>();
            leftGrab = leftController.GetComponent<VRTK_InteractGrab>();
        }

        if (rightController != null)
        {
            rightGrab = rightController.GetComponent<VRTK_InteractGrab>();
            rightGrab = rightController.GetComponent<VRTK_InteractGrab>();

        }

        TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
        //textmeshPro_UI.text = "start";
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();

        if (rightGrab.GetGrabbedObject() == C6H12O6 || leftGrab.GetGrabbedObject() == C6H12O6) {
            textmeshPro_UI.text = "This Liquid is C6H12O6 with 2% concentration \n You can use it in the third step of reactions";
        }
        else
        {
            textmeshPro_UI.text = " ";
        }
    }
}
