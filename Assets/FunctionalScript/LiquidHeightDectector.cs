using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidHeightDectector : MonoBehaviour
{
    public GameObject Liquid;

   
    public float Liquid_Height;
    // Start is called before the first frame update
    void Start()
    {
        //get the height of the liquid cylinder
        Liquid_Height = Liquid.GetComponent<MeshFilter>().mesh.bounds.size.y * Liquid.transform.localScale.y;
        Debug.Log("the height of liquid is" + Liquid_Height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
