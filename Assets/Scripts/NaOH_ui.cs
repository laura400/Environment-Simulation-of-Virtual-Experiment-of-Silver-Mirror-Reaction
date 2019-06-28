using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;
using UnityEngine.UI;

public class NaOH_ui : MonoBehaviour
{

    [Tooltip("left controller")]
    public GameObject leftController;
    [Tooltip("right controller")]
    public GameObject rightController;

    //Grab interface
    private VRTK_InteractGrab leftGrab;
    private VRTK_InteractGrab rightGrab;

    public GameObject NaOH;

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

        if (rightGrab.GetGrabbedObject() == NaOH || leftGrab.GetGrabbedObject() == NaOH) {
            textmeshPro_UI.text = "This Liquid is NaOH with 2% concentration \n You can use it in the first step of reactions";
        }
        else
        {
            textmeshPro_UI.text = " ";
        }
    }
}
