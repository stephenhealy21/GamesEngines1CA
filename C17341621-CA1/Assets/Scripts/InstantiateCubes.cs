using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    public GameObject _cylinder;

    public float rotateSpeed = 300.0f;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale = 1500;
    // Start is called before the first frame update

    int sampleSize = 72;
    int numPillars = 360;
    static int colourShiftMult = 6;
    float colourShift = 0.00277777777f * colourShiftMult;

    int hexColour = 0x000001;
    Color colour;

        int redInt = 0;
        int greenInt = 255;
        int blueInt = 0;
        
        
        float red;
        float green;
        float blue;

    void Start()
    {
        Vector3 tempVector;
        for(int i = 0;i < numPillars; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate (_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3 (0,(-(360/360)) * i,0);
            //this.transform.eulerAngles = new Vector3 (0,0 + i,0);
            _instanceSampleCube.transform.position = Vector3.forward * (_cylinder.transform.localScale.x) / 2;
            _sampleCube[i] = _instanceSampleCube;
            //_sampleCube[i].transform.GetChild(0).AddComponent<Renderer>();
            


            tempVector = _sampleCube[i].transform.localScale;
            //tempVector.x = (sampleSize/360);
            _sampleCube[i].transform.localScale = tempVector;
            _sampleCube[i].transform.LookAt(_cylinder.transform);

            red = (float)redInt * (1f / 255);
            green = (float)blueInt * (1f / 255);
            blue = (float)greenInt * (1f / 255);

            //string hexString = "#" +hexColour.ToString("X");
            //Debug.Log("Hex:"+ hexString);
            /*if(ColorUtility.TryParseHtmlString(hexString, out colour))
            {
                _sampleCube[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color",new Color(r:red,g:green,b:blue,a:0.3f));
                Debug.Log("heerio");
            }*/

            colour = new Color(r:red,g:green,b:blue);
            Debug.Log(colour);
            _sampleCube[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color",colour);
            //green += colourShift;

            int mod3 = i % 3;
            
            if(i < numPillars /2)
            {
                hexColour+=10;
                
                
                //b += colourShift;
                if(mod3 == 0)
                {
                    redInt += colourShiftMult;
                }
                else if(mod3 == 1)
                {
                    greenInt -= colourShiftMult;
                }
                else if(mod3 == 2)
                {
                    blueInt += colourShiftMult;
                }


            }
            else
            {
                if(mod3 == 0)
                {
                    redInt -= colourShiftMult;
                }
                else if(mod3 == 1)
                {
                    greenInt += colourShiftMult;
                }
                else if(mod3 == 2)
                {
                    blueInt -= colourShiftMult;
                }
            }
            //Debug.Log(r+" "+g+" "+b);

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        

        this.transform.RotateAround(Vector3.zero,Vector3.up,rotateSpeed * Time.deltaTime);
        
        Vector3 tempVector;
        bool colourUp = true;
        int colourCounter = 0;
        for (int i = 0;i<numPillars;i++)
        {
            if(_sampleCube != null)
            {
                tempVector = _sampleCube[i].transform.localScale;
                tempVector.z = (AudioVisualiser._samples[i % sampleSize] * _maxScale + 2);
               _sampleCube[i].transform.localScale = tempVector;
               
                
                string hexString = "#" +hexColour.ToString("X");
                //Debug.Log("Hex:"+ hexString);
             

                
               // Debug.Log(hexColour);
            }
            /*
            if(colourUp)
            {
                hexColour+=  1;
                Debug.Log("Up:" + hexColour);
            }
            else
            {
                hexColour-=1;
                Debug.Log("Down:" + hexColour);
            }
            if(hexColour >= 16777215 || hexColour <= 0)
            {
                colourUp = !(colourUp);
                Debug.Log("pog");
            }
            */
        }
        //_sampleCubePrefab.transform.Rotate(yAngle:.01f,xAngle:0,zAngle:0,relativeTo:Space.Self);
        
    }
}
