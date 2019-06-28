using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHeightChanger : MonoBehaviour
{
    public GameObject Plane;
    public GameObject Deposit;
    public GameObject Container;
    public GameObject DepositCylinder;
    public GameObject smoke;

    GameObject DepositCylinderInstance;

    public float height;
    public int IsCreateCylinder;
    public int IsDisableParticleSystem=0;
    public int test=0;

    // Start is called before the first frame update
    void Start()
    {
        Plane.GetComponent<Transform>().Translate(Vector3.up * height);
        Deposit.GetComponent<Transform>().Translate(Vector3.up * height);
        //开始particle system的发射
        smoke.GetComponent<ParticleSystem>().Play();


    }

    // Update is called once per frame
    void Update()
    {
        /*********************Following is create deposite function *****************/

        //Deposit.GetComponent<Transform>().Translate(Vector3.up * Time.deltaTime * 0.5F);
        //test = Deposit.transform.position.y;

        //if (Deposit.transform.position.y < 4+ Container.transform.position.y) //这里4是对应沉淀上升高度4
        if (Deposit.transform.position.y < 3 + Container.transform.position.y) //这里4是对应沉淀上升高度4
        {
            Deposit.GetComponent<Transform>().Translate(Vector3.up * Time.deltaTime * 0.5F);
            IsCreateCylinder = 0;
        }
        else
        {
            IsCreateCylinder = 1;
        }

        if (IsDisableParticleSystem == 1)
        {
            //终止particle system的发生
          
            smoke.GetComponent<ParticleSystem>().Stop();
        }

        else if (IsDisableParticleSystem == 0)
        {
            if (IsCreateCylinder == 1)
            {
            //Create the cylinder according to the height of deposit;

             DepositCylinderInstance = Instantiate(DepositCylinder) as GameObject;//change local into global gameobject
                //silverShaderInstance.transform.parent = Container.transform;

                //silverShaderInstance_2.transform.localScale = silverShader.transform.localScale;
            
           // DepositCylinderInstance.transform.SetParent(Container.transform);
            //DepositCylinderInstance.transform.localScale = DepositCylinder.transform.localScale;//

            DepositCylinderInstance.transform.position = Container.transform.position;
            DepositCylinderInstance.transform.rotation = Container.transform.rotation;



                //DepositCylinderInstance.transform.localScale = DepositCylinder.transform.localScale;
                //DepositCylinderInstance.transform.position = Container.transform.position - Container.transform.up * 2.54f; //0.54为下面的那个半球的半径
                DepositCylinderInstance.transform.position = Container.transform.position - Container.transform.up * 2.54f; //0.54为下面的那个半球的半径


                DepositCylinderInstance.transform.GetComponent<Transform>().localScale += new Vector3(0.0F, 2.5F, 0.0F); //这里add y方向的内容为3+1/2*(h-4)
                //DepositCylinderInstance.transform.GetComponent<Transform>().localScale += new Vector3(0.0F, 3.0F, 0.0F); //这里3是沉淀对应高度4-1=3
                                                                                                                            //世界坐标对应放大4倍，但是管子内在setparent操作后相当于放大0.13333倍

                DepositCylinderInstance.transform.position = Container.transform.position + Vector3.up * 0.54f; //这里试管内坐标上上升0.018，但是因为管子30倍放大，所以世界坐标*30

                DepositCylinderInstance.transform.GetComponent<Transform>().localScale -= new Vector3(0.0F, 0.135F, 0.0F); //0.135=0.54/4 ---对应的是小半球半径变化

                //DepositCylinderInstance.transform.position = Container.transform.position + Vector3.up * 0.27f; //缩放后中心点应变化2倍才能满足底盘位置不变
                //只有这个position是最后的position，有用，上面的都没用啦
                DepositCylinderInstance.transform.position = Container.transform.position + Vector3.up * 0.27f- Vector3.up * 0.45f;//这里可以看到Container.transform.position + Vector3.up * 0.27f是基本position，如果高度为h，这里就在减去Vector3.up*0.9f*（4-h）*1/2

                DepositCylinderInstance.transform.SetParent(Container.transform);

                
                //DepositCylinderInstance.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/SilverShader"); //代码控制切换shader

                //After do one time, then disable the particle system 
                IsDisableParticleSystem = 1;



            
            }
        }


        //
        //AFTER the depoiste reaches the certain height, change particle system into whit deposite with while cylinder
        //and end the particle system relatively


        /*************************** Following is dissolution part ***********************************************/
        //only need to decrease the cylinder height by h according to the time 
        //假设沉淀溶解了直到高度2（相对世界坐标），那么相对试管就是溶解0.066667=2/30 （yj你是写了传来的高度的对吧）
        //那么这样的话，cylinder一定是存在且被创建完的
        
        
        if (DepositCylinderInstance.transform.localScale.y> 0.06666667f) //2/30=0.066667
        {
            DepositCylinderInstance.transform.GetComponent<Transform>().localScale -= new Vector3(0.0F, 0.0001F, 0.0F);
            //Time.deltaTime
            //with only changing scale, the 中心点of cylinder is always 0.009 relative to tube.
            DepositCylinderInstance.transform.position -= Vector3.up * 0.003f;//0.0001F*30=003F 达到了看上去沉淀溶解的效果

            test++;
        }
    
        

    }
}
