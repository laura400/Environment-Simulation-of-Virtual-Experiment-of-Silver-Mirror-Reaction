using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_test : MonoBehaviour
{
    public GameObject water_cylinder;
    public float k=1.0f;

    public int AgNO3_2 = 0;
    public int AgNO3_4 = 0;
    public int NaOH = 0;
    public int NH3H2O = 0;
    public int C6H12O6 = 0;
    public float D = 0;
    public float D2 = 0;

    public bool IsAgNO3_2 = false;
    public bool IsAgNO3_4 = false;
    public bool IsNaOH = false;
    public bool IsNH3H2O = false;
    public bool IsC6H12O6 = false;

    //each liquid need to add
    /* have to arrange after the test*/
    private int AgNO3_2_need = 10;
    private int AgNO3_4_need = 5;
    private int NaOH_need = 2;
    private int NH3H2O_need = 20;
    private int C6H12O6_need = 2;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // deposit create reaction
        
        if( NaOH > 0 ){
            if( AgNO3_2 > 0 ){

                if( AgNO3_2 >= 5 * NaOH){
                    D = 5 * NaOH * k;
                }
                else{
                    D = AgNO3_2 * k;
                }

            }
            else
            {
                if( 2 * AgNO3_4 >= 5 * NaOH){
                    D = 5 * NaOH * k;
                }
                else{
                    D = (5/2) * AgNO3_4 * k;
                }
            }
        }

        // deposit eliminiate reaction
       
        if (NH3H2O > 0){
            //AgNO3 2%
            if (AgNO3_2 > 0.0f)
            {
                if (AgNO3_2 >= 5 * NaOH)
                {
                    if (10 * NaOH >= NH3H2O)
                    {
                        D2 = D - 0.5f * NH3H2O * k;
                    }
                    else
                    {
                        D2 = 0.0f; //all deposit disappear
                    }
                }
                else
                {
                    if (2 * AgNO3_2 >= NH3H2O)
                    {
                        D2 = D - 0.5f * NH3H2O * k;
                    }
                    else
                    {
                        D2 = 0.0f; //all deposit disappear
                    }
                }
            }
            
            //AgNO3 4%
            if(AgNO3_4>0.0f)
            {
                if (AgNO3_4 >= 5 * NaOH)
                {
                    if (10 * NaOH >= NH3H2O)
                    {
                        D2 = D - 0.5f * NH3H2O * k;
                    }
                    else
                    {
                        D2 = 0.0f; //all deposit disappear
                    }
                }
                else
                {
                    if (2 * AgNO3_4 >= NH3H2O)
                    {
                        D2 = D - 0.5f * NH3H2O * k;
                    }
                    else
                    {
                        D2 = 0.0f; //all deposit disappear
                    }
                }
            }

            


        }
        

    }
    // tubeplane
    
        /******
    void  OnParticleCollision(GameObject obj){
        
        Debug.Log("Particle Collision happens" + gameObject.tag);
        //***************need to clarify the particle system here*****************
        if (obj.tag=="AgNO3_2"){
      
        //rigidbody.transform.localScale += new Vector3(0, -0.0001F, 0);
        //rigidbody.position += new Vector3(0, 0.0001F, 0);
        water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, 0.001F, 0);
        water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.000025F, 0);

        AgNO3_2++;

        if(AgNO3_2 > AgNO3_2_need){
            IsAgNO3_2 = true;
        }

        Debug.Log("add AgNO3-2");
        //obj.tag = "test";
        }

        if(obj.tag=="AgNO3_4"){
      
        water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, -0.0001F, 0);
        water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.0001F, 0);

        AgNO3_4++;

        if(AgNO3_4 > AgNO3_4_need){
            IsAgNO3_4 = true;
        }

        Debug.Log("add AgNO3-4");

        }

        if(obj.tag=="NaOH"){
      
            Debug.Log("NaOH flowing");

        water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, -0.0001F, 0);
        water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.0001F, 0);

        NaOH++;

        if( NaOH > NaOH_need){
            IsNaOH = true;
        }

        Debug.Log("add NaOH");

        }

        if(obj.tag=="NH3H2O"){
      
        water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, -0.0001F, 0);
        water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.0001F, 0);

        NH3H2O++;

        if(NH3H2O > NH3H2O_need){
            IsNH3H2O = true;
        }

        Debug.Log("add NH3H2O");

        }

        if(obj.tag=="C6H12O6"){
      
        water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, -0.0001F, 0);
        water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.0001F, 0);

        C6H12O6++;

        if(C6H12O6 > C6H12O6_need){
            IsC6H12O6 = true;
        }

        Debug.Log("add C6H12O6");

        }
    

    }
    **********/
    
}
