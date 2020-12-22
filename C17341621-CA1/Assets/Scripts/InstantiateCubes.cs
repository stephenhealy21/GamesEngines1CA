using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    public GameObject _cylinder;

    public float rotateSpeed = 30.0f;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale = 1500;
    // Start is called before the first frame update

    int sampleSize = 72;
    int numPillars = 360;

    int hexColour = 0x000001;
    Color colour;

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
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        float r;
        float g;
        float b;

        

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
                Debug.Log("Hex:"+ hexString);
                if(ColorUtility.TryParseHtmlString(hexString, out colour))
                {
                    _sampleCube[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color",colour);
                    Debug.Log("heerio");
                }

                
                Debug.Log(hexColour);
            }
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
        }
        //_sampleCubePrefab.transform.Rotate(yAngle:.01f,xAngle:0,zAngle:0,relativeTo:Space.Self);
        
    }
}
