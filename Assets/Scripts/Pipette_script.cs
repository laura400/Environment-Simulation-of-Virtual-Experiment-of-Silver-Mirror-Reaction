using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Pipette_script : MonoBehaviour
{

    GameObject liquid;
    GameObject tubePlane; //the particle collison plane

    [Tooltip("left controller")]
    public GameObject leftController;
    [Tooltip("right controller")]                                              
    public GameObject rightController;

    public GameObject pip;

    //VRTK controller events
    private VRTK_ControllerEvents leftControllerEvents;
    private VRTK_ControllerEvents rightControllerEvents;

    public bool LeftTouchPadMode = false;
    public bool RightTouchPadMode = false;

    //public VRTK_InteractableObject pip_VrtkScript;

    private VRTK_InteractGrab leftGrab;
    private VRTK_InteractGrab rightGrab;

    // Start is called before the first frame update
    void Start()
    {
        liquid = GameObject.Find("pip_Plane");
        tubePlane= GameObject.Find("tubePlane");
        //Control() ;
        //KeyControl() ;
    }


    private void Left_touchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        LeftTouchPadMode = !LeftTouchPadMode;

        //determine whether pipette is grabbed or not
        if (leftGrab.GetGrabbedObject() == pip)
        {

            Debug.Log("LEFT hand GRAB");


            if (LeftTouchPadMode)
            {
                Debug.Log("start left hand drop");
                liquid.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                Debug.Log("stop left hand drop");
                liquid.GetComponent<ParticleSystem>().Stop();
            }

        }
    }

    private void Right_touchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        RightTouchPadMode = !RightTouchPadMode;


        //determine whether pipette is grabbed or not
        if (rightGrab.GetGrabbedObject() == pip)
        {

            Debug.Log("LEFT hand GRAB");

            
            if (RightTouchPadMode)
            {
                Debug.Log("start right hand drop");
                liquid.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                Debug.Log("stop right hand drop");
                liquid.GetComponent<ParticleSystem>().Stop();
            }
        }
    }



    private void Awake() {

        if(leftController != null){

            // Init controller and regist functions on delegate events
            leftControllerEvents = leftController.GetComponent<VRTK_ControllerEvents>();
            leftGrab = leftController.GetComponent<VRTK_InteractGrab>();
            leftControllerEvents.TouchpadPressed += Left_touchpadPressed;

        }

        if(rightController != null){

            rightControllerEvents = rightController.GetComponent<VRTK_ControllerEvents>();
            rightGrab = rightController.GetComponent<VRTK_InteractGrab>();
            rightControllerEvents.TouchpadPressed += Right_touchpadPressed;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rightGrab.GetGrabbedObject());

        //stop particle system when pressed test each frame
        //if we continue playing particle system there will be some problem

        if (leftGrab.GetGrabbedObject() == pip)
        {

            //Debug.Log("LEFT hand GRAB");


            if (LeftTouchPadMode == false)
            {
                Debug.Log("stop left hand drop");
                liquid.GetComponent<ParticleSystem>().Stop();
            }

        }

        if (rightGrab.GetGrabbedObject() == pip)
        {

           // Debug.Log("LEFT hand GRAB");


            if (RightTouchPadMode == false)
            {
                Debug.Log("stop left hand drop");
                liquid.GetComponent<ParticleSystem>().Stop();
            }

        }



    }

    void OnTriggerEnter(Collider other){

        Debug.Log("Draw liquid");
        Debug.Log(other.name);
        Debug.Log(other.tag);

        //change the content of the pipette
        if (other.tag == "AgNO3_2"){
            liquid.tag = "AgNO3_2";
            
        }

        if (other.tag == "AgNO3_4"){
            liquid.tag = "AgNO3_4";
            
        }

        if (other.tag == "NaOH"){
            liquid.tag = "NaOH";
            
        }

        if (other.tag == "NH3H2O"){
            liquid.tag = "NH3H2O";
            
        }

        if (other.tag == "C6H12O6"){
            liquid.tag = "C6H12O6";
            
        }
    }
}