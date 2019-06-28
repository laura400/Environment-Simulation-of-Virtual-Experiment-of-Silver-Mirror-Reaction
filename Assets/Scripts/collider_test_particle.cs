using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_test_particle : MonoBehaviour
{

    public collider_test collider_script;

    //each liquid need to add
    /* have to arrange after the test*/
    private int AgNO3_2_need = 2;
    private int AgNO3_4_need = 2;
    private int NaOH_need = 1;
    private int NH3H2O_need = 1;
    private int C6H12O6_need = 1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnParticleCollision(GameObject obj)
    {
        Debug.Log(obj.name + "  " + obj.tag);
        Debug.Log("Particle Collision happens");
        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int numCollisionEvents = GetComponent<ParticleSystem>().GetCollisionEvents(obj, collisionEvents);

        int i = 0;

        while (i < numCollisionEvents)
        {
            Debug.Log("collsion event" + collisionEvents[i].intersection);
            i++;
        }

            //***************need to clarify the particle system here*****************
            if (gameObject.tag == "AgNO3_2")
        {

            //rigidbody.transform.localScale += new Vector3(0, -0.0001F, 0);
            //rigidbody.position += new Vector3(0, 0.0001F, 0);
            collider_script.water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, 0.01F, 0); //*10
            collider_script.water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.00025F, 0);//*10

            collider_script.AgNO3_2++;

            if (collider_script.AgNO3_2 > AgNO3_2_need)
            {
                collider_script.IsAgNO3_2 = true;
            }

            Debug.Log("add AgNO3-2");
            //obj.tag = "test";
        }

        if (gameObject.tag == "AgNO3_4")
        {

            collider_script.water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, 0.01F, 0);
            collider_script.water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.00025F, 0);

            collider_script.AgNO3_4++;

            if (collider_script.AgNO3_4 > AgNO3_4_need)
            {
                collider_script.IsAgNO3_4 = true;
            }

            Debug.Log("add AgNO3-4");

        }

        if (gameObject.tag == "NaOH")
        {

            Debug.Log("NaOH flowing");

            collider_script.water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, 0.01F, 0);
            collider_script.water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.00025F, 0);

            collider_script.NaOH++;

            if (collider_script.NaOH > NaOH_need)
            {
                collider_script.IsNaOH = true;
            }

            Debug.Log("add NaOH");

        }

        if (gameObject.tag == "NH3H2O")
        {

            collider_script.water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, 0.01F, 0);
            collider_script.water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.00025F, 0);

            collider_script.NH3H2O++;

            if (collider_script.NH3H2O > NH3H2O_need)
            {
                collider_script.IsNH3H2O = true;
            }

            Debug.Log("add NH3H2O");

        }

        if (gameObject.tag == "C6H12O6")
        {

            collider_script.water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, 0.01F, 0);
            collider_script.water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.00025F, 0);

            collider_script.C6H12O6++;

            if (collider_script.C6H12O6 > C6H12O6_need)
            {
                collider_script.IsC6H12O6 = true;
            }

            Debug.Log("add C6H12O6");

        }


    }
    
}
