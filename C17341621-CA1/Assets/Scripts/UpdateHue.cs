using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UpdateHue : MonoBehaviour
{
    public float shiftRate = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var PostProcessingVolume = this.GetComponent<PostProcessVolume>();
        Debug.Log("pogggg");
        if (PostProcessingVolume.profile.TryGetSettings<ColorGrading>(out var ColorGrading))
        {
            if(ColorGrading.hueShift.value >= 180)
            {
                ColorGrading.hueShift.value = -180;
            }
            ColorGrading.hueShift.value += shiftRate;
        }
    }
}
