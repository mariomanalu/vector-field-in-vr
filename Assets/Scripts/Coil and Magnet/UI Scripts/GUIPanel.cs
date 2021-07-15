using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GUIPanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI display;
    [SerializeField]
    VectorField field;
    [SerializeField]
    GameObject magnet;
    [SerializeField]
    Slider slider;
    public void PlayMagnet()
    {   
        if (magnet.GetComponent<MoveMagnet>().isPaused){
            magnet.GetComponent<MoveMagnet>().isPaused = false;
        }
    }

    public void PauseMagnet()
    {
        if(!magnet.GetComponent<MoveMagnet>().isPaused)
        {   
             magnet.GetComponent<MoveMagnet>().isPaused = true;
        }
    }

    public void SlideMagnet()
    {
        if(magnet.GetComponent<MoveMagnet>().isPaused){ 
            magnet.transform.position = new Vector3(slider.value, 1.467f, 0.345f);
        }   
    }

    void Update(){
        
        // Max of magnet.transform.position.x = 2 * max(Mathf.Cos(Mathf.PI * slider.value * .1f) - .138f) = 1.862
        // Min of magnet.transform.position.x = 2 * min(Mathf.Cos(Mathf.PI * slider.value * .1f) - .138f) = -2.138
        // Refactor magnet.transform.position.x later such that we don't need any offset
        if (!magnet.GetComponent<MoveMagnet>().isPaused)
        {   
            magnet.GetComponent<MoveMagnet>().sliderValue += 0.05f;
            slider.value = magnet.transform.position.x;
        }
        
        
        //Debug.Log("Slider value is" + slider.value);
        int identifier = (int)(field.fieldType);

        switch(identifier)
        {
            case 0:
                display.SetText($"This is an Outwards field. All of the vectors are pointing outwards");
                break;
            case 1:
                display.SetText($"This is an Swirl field. All of the vectors are swirling");
                break;
            case 2:
                display.SetText($"This is the Magnetic field generated by the magnet. The field can be computed with a formula. Can you guess what it is?");
                break;
            case 3:
                display.SetText($"This is the DeltaB/DeltaT field generated by the magnet.");
                break;
            case 4:
                display.SetText($"This is the Integrand field. Nothing to see here.");
                break;
            case 5:
                display.SetText($"This is the Electric field. It is computed using the Faraday-Maxwell formula for Electric field.");
                break;   
        }
        
    }
}