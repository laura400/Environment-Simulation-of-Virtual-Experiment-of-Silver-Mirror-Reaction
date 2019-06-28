using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;
using UnityEngine.UI;

public class object_ui : MonoBehaviour
{

    [Tooltip("left controller")]
    public GameObject leftController;
    [Tooltip("right controller")]
    public GameObject rightController;

    //Grab interface
    private VRTK_InteractGrab leftGrab;
    private VRTK_InteractGrab rightGrab;

    //define different objects for judgement
    public GameObject pip;
    public GameObject beaker_C6H12O6;
    public GameObject beaker_NH3H2O;
    public GameObject beaker_NaOH;
    public GameObject beaker_AgNO3_4;
    public GameObject beaker_AgNO3_2;
    public GameObject tube;

 

    //use collider_script to judge the type liquid in pip
    public collider_test collider_script;

    void Start()
    {

        if (leftController != null)
        {
            leftGrab = leftController.GetComponent<VRTK_InteractGrab>();
        }

        if (rightController != null)
        {
            rightGrab = rightController.GetComponent<VRTK_InteractGrab>();

        }

        TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
        textmeshPro_UI.SetText("start");


    }

    // Update is called once per frame
    void Update()
    {
        //determine what is grabbed to output different UI
        //1. if user is grabbing pipette:
        if (leftGrab.GetGrabbedObject() == pip)
        {

            Debug.Log("left hand pip GRAB");
          

            //judge the different tag to give different order
            if (collider_script.IsAgNO3_2 || collider_script.IsAgNO3_4)
            {
                TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
                textmeshPro_UI.SetText("In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding AgNO3 to the tube and needs to use the pipette to touch NaOH liquid");


                if (collider_script.IsNaOH)
                {

                    textmeshPro_UI.SetText("In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding NaOH to the tube and thus step 1 reaction \n Now you can use the pipette to touch NH3H20 liquid to start step 2 reaction");


                    if (collider_script.IsNH3H2O)
                    {

                        textmeshPro_UI.SetText("In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding enough NH3H2O to the tube for deposit to resolve\n You can follow step 3 reaction after resolvion of the deposit");


                        if (collider_script.IsC6H12O6)
                        {

                            textmeshPro_UI.SetText("In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding enough C6H12O6 to the tube for silver phenomenon");
                        }
                    }
                }
            }
        }

        if (rightGrab.GetGrabbedObject() == pip)
        {

            Debug.Log("right hand pip GRAB");
            //Text text_UI = GetComponent<Text>();
            //text_UI.SetText("You are holding the pip");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("You are now holding the pip");

            //judge the different tag to give different order
            if (collider_script.IsAgNO3_2 || collider_script.IsAgNO3_4)
            {
                //TextMeshPro textmeshPro_UI = GetComponent<TextMeshPro>();
                textmeshPro_UI.SetText("In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding AgNO3 to the tube and needs to use the pipette to touch NaOH liquid");


                if (collider_script.IsNaOH)
                {

                    textmeshPro_UI.SetText("In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding NaOH to the tube and thus step 1 reaction \n Now you can use the pipette to touch NH3H20 liquid to start step 2 reaction");


                    if (collider_script.IsNH3H2O)
                    {

                        textmeshPro_UI.SetText("In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding enough NH3H2O to the tube for deposit to resolve\n You can follow step 3 reaction after resolvion of the deposit");


                        if (collider_script.IsC6H12O6)
                        {

                            textmeshPro_UI.SetText("In order to use this pipette, you need:\n 1.Press the Touchpad to start the dropping of pip \n 2. Press the Touchpad again to stop the dropping\n Now you finished adding enough C6H12O6 to the tube for silver phenomenon");
                        }
                    }
                }
            }

        }

        //2. if user is grabbing pipette:beaker_C6H12O6;
        if (leftGrab.GetGrabbedObject() == beaker_C6H12O6)
        {

            //Debug.Log("left hand beaker_C6H12O6 GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is C6H12O6 with 2% concentration \n You can use it in the third step of reactions");

        }

        if (rightGrab.GetGrabbedObject() == beaker_C6H12O6)
        {

            Debug.Log("right hand beaker_C6H12O6 GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is C6H12O6 with 2% concentration \n You can use it in the third step of reactions");


        }

        //3. if user is grabbing pipette:beaker_NH3H2O
        if (leftGrab.GetGrabbedObject() == beaker_NH3H2O)
        {

            //Debug.Log("left hand beaker_NH3H2O GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is NH3H2O with 2% concentration \n You can use it in the second step of reactions");


        }

        if (rightGrab.GetGrabbedObject() == beaker_NH3H2O)
        {

            Debug.Log("right hand beaker_NH3H2O GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is NH3H2O with 2% concentration \n You can use it in the second step of reactions");


        }

        //4. if user is grabbing pipette:beaker_NaOH
        if (leftGrab.GetGrabbedObject() == beaker_NaOH)
        {

            //Debug.Log("left hand beaker_NaOH GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is NaOH with 2% concentration \n You can use it in the first step of reactions");


        }

        if (rightGrab.GetGrabbedObject() == beaker_NaOH)
        {

            Debug.Log("right hand beaker_NaOH GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is NaOH with 2% concentration \n You can use it in the first step of reactions");


        }

        //4. if user is grabbing pipette:beaker_AgNO3_4
        if (leftGrab.GetGrabbedObject() == beaker_AgNO3_4)
        {

            //Debug.Log("left hand beaker_AgNO3_4 GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is AgNO3 with 4% concentration \n You can use it in the first step of reactions");


        }

        if (rightGrab.GetGrabbedObject() == beaker_AgNO3_4)
        {

            Debug.Log("right hand beaker_AgNO3_4 GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is AgNO3 with 4% concentration \n You can use it in the first step of reactions");


        }

        //5. if user is grabbing pipette:beaker_AgNO3_2
        if (leftGrab.GetGrabbedObject() == beaker_AgNO3_2)
        {

            //Debug.Log("left hand beaker_AgNO3_2 GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is AgNO3 with 2% concentration \n You can use it in the first step of reactions");


        }

        if (rightGrab.GetGrabbedObject() == beaker_AgNO3_2)
        {

            Debug.Log("right hand beaker_AgNO3_2 GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("This Liquid is AgNO3 with 2% concentration \n You can use it in the first step of reactions");


        }

        //5. if user is grabbing tube
        if (leftGrab.GetGrabbedObject() == tube)
        {

            //Debug.Log("left hand beaker_AgNO3_2 GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("You are now holding the tube.\n Please do the reaction experiment");


        }

        if (rightGrab.GetGrabbedObject() == beaker_AgNO3_2)
        {

            Debug.Log("right hand tube GRAB");
            TextMeshProUGUI textmeshPro_UI = GetComponent<TextMeshProUGUI>();
            textmeshPro_UI.SetText("You are now holding the tube.\n Please do the reaction experiment");


        }

    }
}