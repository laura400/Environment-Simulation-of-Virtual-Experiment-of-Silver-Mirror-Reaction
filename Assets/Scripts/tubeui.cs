using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;
using UnityEngine.UI;

public class tubeui : MonoBehaviour
{

    [Tooltip("left controller")]
    public GameObject leftController;
    [Tooltip("right controller")]
    public GameObject rightController;

    //Grab interface
    private VRTK_InteractGrab leftGrab;
    private VRTK_InteractGrab rightGrab;

    public GameObject tube;

    // Start is called before the first frame update
    void Start()
    {
        if (leftController != null)
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

        if (rightGrab.GetGrabbedObject() == tube || leftGrab.GetGrabbedObject() == tube)
        {
            textmeshPro_UI.text = "You are now holding the tube.\n Please do the reaction experiment";
        }
        else
        {
            textmeshPro_UI.text = " ";
        }
    }
}
