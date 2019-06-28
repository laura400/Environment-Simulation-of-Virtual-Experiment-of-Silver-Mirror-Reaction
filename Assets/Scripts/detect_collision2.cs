using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_collision2 : MonoBehaviour
{
    public GameObject tube;
    public LiquidHeightDectector LiquidHeightDectector_container; //quote from other script: LiquidHeightDectoctor
    public LiquidHeightDectector LiquidHeightDectector_tape;
    public GameObject silverShader;

    public float tapeLiquid_Height;
    public float containerLiquid_Height;

    public bool IsTubeInWater = false;

    // Start is called before the first frame update
    void Start()
    {
        silverShader.transform.position = new Vector3 (10F,10F,10F);//initiate silver position to far far away
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnCollisionEnter(Collision collision){

        Debug.Log(collision.gameObject.tag);

        if(collision.gameObject.tag.Equals("test tube")){

            Debug.Log("enter!!");

            IsTubeInWater = true;

            containerLiquid_Height = LiquidHeightDectector_container.GetComponent<LiquidHeightDectector>().Liquid_Height;
            //containerLiquid_Height = 0.1572076f / 2.0f; //fixed height of water in container.

            tapeLiquid_Height = LiquidHeightDectector_tape.GetComponent<LiquidHeightDectector>().Liquid_Height;


            if(containerLiquid_Height > tapeLiquid_Height){

                silverShader.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/SilverShader"); //代码控制切换shader
                silverShader.transform.localScale = tube.transform.localScale;
                silverShader.transform.localScale += new Vector3 ( 0.01F, 0.01F, 0.01F);
                silverShader.transform.position = tube.transform.position;
                Debug.Log("container is higher");

            }
            else
            {
                silverShader.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/SilverShader"); //代码控制切换shader
                silverShader.transform.localScale = tube.transform.localScale;
                silverShader.transform.localScale += new Vector3 ( 0.01F, 0.00F, 0.01F);
                silverShader.transform.localScale = new Vector3 ( silverShader.transform.localScale.x, silverShader.transform.localScale.y * (containerLiquid_Height/tapeLiquid_Height), silverShader.transform.localScale.z);
                silverShader.transform.position = tube.transform.position;
                //silverShader.transform.localScale = new Vector3 ( tube.transform.position.x, ( tapeLiquid_Height / tube.transform.position.y) * containerLiquid_Height, tube.transform.position.z);

                Debug.Log("tube is higher");
            }
        }
    }

 
}


