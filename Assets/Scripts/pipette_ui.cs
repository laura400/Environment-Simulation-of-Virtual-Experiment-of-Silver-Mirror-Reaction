using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;
using UnityEngine.UI;

public class pipette_ui : MonoBehaviour
{

    [Tooltip("left controller")]
    public GameObject leftController;
    [Tooltip("right controller")]
    public GameObject rightController;

    //Grab interface
    private VRTK_InteractGrab leftGrab;
    private VRTK_InteractGrab rightGrab;

    public GameObject pipette;

    //use collider_script to judge the type liquid in pip
    public collider_test collider_script;

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

        if (rightGrab.GetGrabbedObject() == pipette || leftGrab.GetGrabbedObject() == pipette) {
            textmeshPro_UI.text = "You are now holding the pipette";

            //judge the different tag to give different order
            if (collider_script.IsAgNO3_2 || collider_script.IsAgNO3_4)
            {
                
                textmeshPro_UI.text = "In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding AgNO3 to the tube and needs to use the pipette to touch NaOH liquid";


                if (collider_script.IsNaOH)
                {

                    textmeshPro_UI.text = "In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding NaOH to the tube and thus step 1 reaction \n Now you can use the pipette to touch NH3H20 liquid to start step 2 reaction";


                    if (collider_script.IsNH3H2O)
                    {

                        textmeshPro_UI.text = "In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding enough NH3H2O to the tube for deposit to resolve\n You can follow step 3 reaction after resolvion of the deposit";


                        if (collider_script.IsC6H12O6)
                        {

                            textmeshPro_UI.text = "In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding enough C6H12O6 to the tube for silver phenomenon";
                        }
                    }
                }
            }

        }
        else
        {
            textmeshPro_UI.text = " ";
        }
    }
}
