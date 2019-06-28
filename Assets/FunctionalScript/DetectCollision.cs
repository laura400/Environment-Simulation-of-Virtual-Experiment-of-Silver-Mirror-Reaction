using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject Container;
    public LiquidHeightDectector LiquidHeightDectector_container; //quote from other script: LiquidHeightDectoctor
    public LiquidHeightDectector LiquidHeightDectector_tape;
    public GameObject silverShader;
    public GameObject silverShader_2;

    public float delay_time=5.0f;
    public float m_timer = 0.0f;
   // public int isCollision = 0;
    public float tapeLiquid_Height;
    public float containerLiquid_Height;
    public float silverCylinder_Height;
    //public float silverPosition;
    private float detHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnCollisionEnter(Collision collision){

        containerLiquid_Height = LiquidHeightDectector_container.GetComponent<LiquidHeightDectector>().Liquid_Height;
        //containerLiquid_Height = 0.1572076f / 2.0f; //fixed height of water in container.

        tapeLiquid_Height = LiquidHeightDectector_tape.GetComponent<LiquidHeightDectector>().Liquid_Height;

        if (containerLiquid_Height > tapeLiquid_Height)
        {
            silverCylinder_Height = tapeLiquid_Height;

        }else{
            silverCylinder_Height = containerLiquid_Height;
        }

        if(containerLiquid_Height > tapeLiquid_Height){

            silverShader_2.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/SilverShader"); //代码控制切换shader
            Debug.Log("container is higher");

        }
        else
        {
            GameObject silverShaderInstance_2 = Instantiate(silverShader_2) as GameObject;
            silverShaderInstance_2.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/SilverShader"); //代码控制切换shader
            silverShaderInstance_2.transform.SetParent(Container.transform);
            silverShaderInstance_2.transform.localScale = silverShader_2.transform.localScale;
            silverShaderInstance_2.transform.position = silverShader_2.transform.position;

            Debug.Log("tube is higher");
        }
    }

    private void OnCollisionStay(Collision other) {
        Debug.Log(containerLiquid_Height);
        Debug.Log(tapeLiquid_Height);
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     //Debug.Log("Enter called.");
    //     // when there is a collision ,compare the height of two liquid
    //     containerLiquid_Height = LiquidHeightDectector_container.GetComponent<LiquidHeightDectector>().Liquid_Height;
    //     containerLiquid_Height = 0.1572076f / 2.0f; //fixed height of water in container.
    //     //containerLiquid_Height = 3.0f;// for test
    //     tapeLiquid_Height = LiquidHeightDectector_tape.GetComponent<LiquidHeightDectector>().Liquid_Height;

    //     //use a compare in this script to return a value of who is much higher.
    //     if (containerLiquid_Height > tapeLiquid_Height)
    //     {
    //         silverCylinder_Height = tapeLiquid_Height;

    //     }else{
    //         silverCylinder_Height = containerLiquid_Height;
    //     }

       

    //     if (containerLiquid_Height > tapeLiquid_Height)
    //     {
    //         //Change the height of the cylinder:silverShaderInstance
    //         //silverShaderInstance.transform.localScale += new Vector3(0, 0.1F, 0);

    //         //height is height of tapeLiquid_height.

    //         //height is the height of contianerLiquid_Height
    //         //then create a cylinder according to silverCylinder_Height.
    //         //GameObject silverShader = Resources.Load("Assets/Prefabs/silverShader") as GameObject;
    //         GameObject silverShaderInstance_2 = Instantiate(silverShader_2) as GameObject;
    //         //silverShaderInstance.transform.parent = Container.transform;

    //         //silverShaderInstance_2.transform.localScale = silverShader.transform.localScale;

    //         silverShaderInstance_2.transform.SetParent(Container.transform);
    //         silverShaderInstance_2.transform.position = Container.transform.position;
    //         silverShaderInstance_2.transform.rotation = Container.transform.rotation;
    //         Debug.Log(Container.transform.position);
    //         silverShaderInstance_2.transform.position = Container.transform.position - Container.transform.up * 3.8f;

    //         //silverShaderInstance_2.transform.localScale = silverShader.transform.localScale;
    //         //silverShaderInstance_2.transform.position = Container.transform.position - Container.transform.up * 2.5f;
    //         //silverPosition = silverShaderInstance.transform.position.y;
    //         //silverShaderInstance.GetComponent<Transform>().position.x = Container.transform.position.x - 0.08f;
    //         //silverShaderInstance.transform.Translate(-Container.transform.up * 0.8f,Space.Self);

    //         silverShaderInstance_2.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/SilverShader"); //代码控制切换shader


    //     }
    //     else
    //     {
    //         //height is the height of contianerLiquid_Height
    //         //then create a cylinder according to silverCylinder_Height.
    //         //GameObject silverShader = Resources.Load("Assets/Prefabs/silverShader") as GameObject;
    //         GameObject silverShaderInstance = Instantiate(silverShader) as GameObject;
    //         //silverShaderInstance.transform.parent = Container.transform;
    //         silverShaderInstance.transform.SetParent(Container.transform);
    //         silverShaderInstance.transform.position = Container.transform.position;
    //         silverShaderInstance.transform.rotation = Container.transform.rotation;
    //         //Debug.Log(Container.transform.position);


    //         silverShaderInstance.transform.localScale = silverShader.transform.localScale;
    //         silverShaderInstance.transform.position = Container.transform.position - Container.transform.up * 2.5f;
    //         //silverPosition = silverShaderInstance.transform.position.y;
    //         //silverShaderInstance.GetComponent<Transform>().position.x = Container.transform.position.x - 0.08f;
    //         //silverShaderInstance.transform.Translate(-Container.transform.up * 0.8f,Space.Self);

    //     }

    //     //silverShaderInstance.GetComponent<Transform>().localScale = new Vector3(1.0F, 5.0F, 1.0F);


    // }

    // void OnCollisionStay(Collision collision)
    // {
    //     //Debug.Log("Stay occuring..");

    //     //if happen collision, then set the m_timer to calucalte the delay, after the delay time, we see the silver shader
       
    //         m_timer += Time.time;
    //         if (m_timer >= delay_time)
    //         {
    //         Debug.Log("it does have delay and need to show silver shader");
    //             //ShowB(); // show the cylinder of the silver shader
                
    //         }
       
    // }

    // void OnCollisionExit(Collision collision)
    // {
    //     //Debug.Log("Exit called");
    // }
}


