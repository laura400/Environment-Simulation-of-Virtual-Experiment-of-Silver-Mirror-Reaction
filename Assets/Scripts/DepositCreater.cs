using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DepositCreater : MonoBehaviour
{
    //import the two scripts from 
    public tube_shake_vrtk tube_shake_condition;
    public collider_test collider_script;

    //create deposit and container gameobject
    public GameObject Deposit;
    public GameObject Container;

    public int IsStartParticleSystem = 0;
    public int IsKeepParticleSystem=0; 
    //to see whether we need to keep the position of particle system instead of change it
    public int IsDisableParticleSystem = 0;
    //to see whether the deposit need to be cancel
    public int IsChangeHeightParticleSystem = 0;
    // to judge whether the deposit is changing its amount or just holding

    //for test the deposit height
   // public float test_depositHeight;

    void Start()
    {
        
        IsStartParticleSystem = 0;
        //Deposit.GetComponent<ParticleSystem>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        //for  test the deposit height
        //test_depositHeight = Deposit.transform.localPosition.z;
        //tube_shake_condition.IsShake = true; //for test



        /****************test the height of D ***************/
        /****
        if (Deposit.transform.position.y < 3 + Container.transform.position.y) //这里4是对应沉淀上升高度4
        {
            Deposit.GetComponent<Transform>().localPosition+=new Vector3(0.0f,0.0f, Time.deltaTime * 0.05F);
           
        }
        *********/

        

        //judge the deposit create condion
        //if we shake after adding NaOH to AgNo3, Then the deposit creates.
        if ((collider_script.AgNO3_2 > 0 || collider_script.AgNO3_4 > 0) && collider_script.NaOH > 0)
        {
            if (tube_shake_condition.IsShake == true)
            {
                if (collider_script.D > 0)
                {
                    //If there is deposit, then we need to create it!
                    if (IsStartParticleSystem == 0 && IsKeepParticleSystem == 0)
                    {
                        Deposit.GetComponent<ParticleSystem>().Play();
                        IsStartParticleSystem = 1;
                        //only start the particle once, other time, keep it is ok
                    }

                    if (IsStartParticleSystem == 1 || IsKeepParticleSystem == 1)
                    {
                        //D is relative with 0.05D height
                        if (Deposit.transform.localPosition.z < collider_script.D*0.05f-2.56f ) //通过D控制沉淀的量
                        {
                            Deposit.GetComponent<Transform>().localPosition += new Vector3(0.0f, 0.0f, Time.deltaTime * 0.1F);
                            IsKeepParticleSystem = 1;
                            IsChangeHeightParticleSystem = 1;
                        }
                        else
                        {
                            IsStartParticleSystem= 0;
                            IsKeepParticleSystem = 1;
                            IsChangeHeightParticleSystem = 0;
                            IsDisableParticleSystem = 0;
                            //at this else time, the deposit is arriving at the ideal height
}
                    }
                }

            }
        }

        Debug.Log("TEST DEPOSIT BEFORE");
        //judge the deposit eliminiate condition
        if ((collider_script.NH3H2O> 0)  && (collider_script.NaOH > 0) && (collider_script.AgNO3_2 > 0 || collider_script.AgNO3_4 > 0))
        {
            if (collider_script.D2 >0)
            {

                //If there is deposit remaining
                if (collider_script.D2 > 0.0f)
                {
                    //D2 is relative with 0.05D height
                    if (Deposit.transform.localPosition.z > collider_script.D2 * 0.05f - 2.56f) //这里4是对应沉淀上升高度4
                    {
                        Deposit.GetComponent<Transform>().localPosition -= new Vector3(0.0f, 0.0f, Time.deltaTime * 0.1F);
                        IsKeepParticleSystem = 1;
                        IsChangeHeightParticleSystem = 1;
                    }
                    else
                    {
                        IsKeepParticleSystem = 1;
                        IsDisableParticleSystem = 0;
                        IsChangeHeightParticleSystem = 0;
                        //at this else time, the deposit is arriving at the ideal height
                    }
                }

            }
            else
            {
                // no deposit: D2=0

                IsDisableParticleSystem = 1;
                //create relative particle phenonmen according to the label

                //if the deposit decrease totally 
                if (IsDisableParticleSystem == 1)
                {
                    Deposit.GetComponent<ParticleSystem>().Stop();
                }

            }
        }




        //create relative particle phenonmen according to the label
        

    }
}
