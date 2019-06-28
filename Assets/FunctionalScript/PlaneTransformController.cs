using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTransformController : MonoBehaviour
{
    public GameObject Plane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane.GetComponent<Transform>().Translate(Vector3.up * Time.deltaTime * 1*0.05f);
    }
}
