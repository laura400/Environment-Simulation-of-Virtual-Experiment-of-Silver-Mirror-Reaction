using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using VRTK;

public class tube_shake_vrtk : MonoBehaviour
{

    [Tooltip("left controller")]
    public Transform leftController;
    [Tooltip("right controller")]                                              
    public Transform rightController;

    public GameObject tube;

    //VRTK controller events
    private VRTK_ControllerEvents leftControllerEvents;
    private VRTK_ControllerEvents rightControllerEvents;

    private VRTK_InteractGrab leftGrab;
    private VRTK_InteractGrab rightGrab;

    public collider_test collider_script;

    private float rotate_rx, rotate_ry, rotate_rz, rotate_lx, rotate_ly, rotate_lz;

    //when IsShake is true, the liquid start deposite
    public bool IsShake = false ;

    private int count = 0;

    // Start is called before the first frame update
    private void Awake() {

        if(leftController != null){

            // Init controller and regist functions on delegate events
            leftControllerEvents = leftController.GetComponent<VRTK_ControllerEvents>();
            leftGrab = leftController.GetComponent<VRTK_InteractGrab>();
            //leftControllerEvents.TriggerAxisChanged += OnLeftTriggerAxisChanged;


        }

        if(rightController != null){

            rightControllerEvents = rightController.GetComponent<VRTK_ControllerEvents>();
            rightGrab = rightController.GetComponent<VRTK_InteractGrab>();
            //rightControllerEvents.TriggerAxisChanged += OnRightTriggerAxisChanged;


        }


        
    }

    // Update is called once per frame
    void Update()
    {
        if( (collider_script.AgNO3_2 > 0 || collider_script.AgNO3_4 >0 ) && collider_script.NaOH > 0 ){

            //Debug.Log("0");

            if (rightGrab.GetGrabbedObject() == tube) {
                
                
                Debug.Log(rotate_rx);

                Thread.Sleep(50);

                Debug.Log(rightController.rotation.x);

                if (Mathf.Abs(rotate_lx - leftController.rotation.x) > 0.01 || Mathf.Abs(rotate_ly - leftController.rotation.y) > 0.01 || Mathf.Abs(rotate_lz - leftController.rotation.z) > 0.01) {
                    count++;
                }
             

                Debug.Log("coUNT?");
                Debug.Log(count);

                if (count >= 150)
                {
                    IsShake = true;
                }

                Debug.Log(IsShake);

                rotate_rx = rightController.rotation.x;
                rotate_ry = rightController.rotation.y;
                rotate_rz = rightController.rotation.z;

            }

            if(leftGrab.GetGrabbedObject() == tube ){
                


                    Thread.Sleep(50); 

                    if( Mathf.Abs(rotate_lx - leftController.rotation.x) > 0.01 || Mathf.Abs(rotate_ly - leftController.rotation.y) > 0.01 || Mathf.Abs(rotate_lz - leftController.rotation.z) > 0.01){
                        count++;
                    }
                //}//have to shake for 3 sec

                if (count >= 150)
                {
                    IsShake = true;
                }

                rotate_lx = leftController.rotation.x;
                rotate_ly = leftController.rotation.y;
                rotate_lz = leftController.rotation.z;

            }

            

            


        }
        
    }
}
