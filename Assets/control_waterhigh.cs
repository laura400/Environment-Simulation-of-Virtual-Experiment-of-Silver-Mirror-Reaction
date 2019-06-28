using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_waterhigh : MonoBehaviour
{
    public GameObject water_cylinder;
    public GameObject dropper_t1; // the rigidbody which has calculate "t1"
    public Transform c_transform;
    //new Rigidbody rigidbody;

    private float mytime;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //mytime = dropper_t1.GetComponent<Bb>().t1; //<Bb> Bb inside put the script that have public t1
        //rigidbody.GetComponent<Transform>().localScale += new Vector3(0, -0.0001F, 0);
        //rigidbody.GetComponent<Transform>().position += new Vector3(0, 0.0001F, 0);
        // water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, -0.0001F, 0);
        // water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.0001F, 0);
        //GameObject mycylinder;
        //c_transform.localScale += new Vector3(0, -0.0001F, 0);
        //c_transform.transform.position += new Vector3(0, 0.0001F, 0);
    }

   void  OnParticleCollision(GameObject obj){
      if(obj.tag=="dropping"){
      
        //rigidbody.transform.localScale += new Vector3(0, -0.0001F, 0);
        //rigidbody.position += new Vector3(0, 0.0001F, 0);
        water_cylinder.GetComponent<Transform>().localScale += new Vector3(0, -0.0001F, 0);
        water_cylinder.GetComponent<Transform>().position += new Vector3(0, 0.0001F, 0);
        Debug.Log("例子碰撞到了");
        }
    }     

    
}
