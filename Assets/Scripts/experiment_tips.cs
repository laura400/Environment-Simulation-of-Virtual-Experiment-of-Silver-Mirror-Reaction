using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class experiment_tips : MonoBehaviour
{

    public collider_test collider_script;
    public tube_shake_vrtk tubeshake_script;
    public detect_collision2 water_script;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.SetText("This board will show you the Silver mirror reaction experiment tips.\n\nThe board on the right side shows all chemical reaction formula in this experiment.\n\nStep 1 :\n 1. use the pipette to touch AgNO3 liquid \n 2. drop it into the tube. (About 1 ml)\n 3. you can use either 2% or 4%");

        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        //determine whether the player finish step 1
        if(collider_script.IsAgNO3_2 || collider_script.IsAgNO3_4){
            textmeshPro.SetText("Step 2 :\n 1. use the pipette to touch NaOH liquid \n 2. drop it into the tube\n 3. After adding NaOH, shake the tube until there is precipitation in the tube");
        
            if(tubeshake_script.IsShake){
                textmeshPro.SetText("Step 3 :\n1. use the pipette to touch NH3H20 liquid \n 2. drop it into the tube until the precipitation disappear");

                /* have to change here , when the  precipitation done then this condition will be true*/
                if(collider_script.IsNH3H2O){
                    textmeshPro.SetText("Step 4 :\n When you see the deposit all dissolve\n 1. use the pipette to touch C6H12O6 liquid \n 2. drop it into the tube\n 3. put the tube into hot water");
                
                    if(water_script.IsTubeInWater){
                        textmeshPro.SetText("Step 5: The silver mirror will appear in the tube");
                    }
                
                }

            }
        
        }

        

        


    }
}
