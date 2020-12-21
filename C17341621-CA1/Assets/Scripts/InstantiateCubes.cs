using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    public GameObject _cylinder;

    public float rotateSpeed = 10.0f;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale = 100;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 512; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate (_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            //this.transform.eulerAngles = new Vector3 (0,-0.703125f * i,0);
            this.transform.eulerAngles = new Vector3 (0,0 + i,0);
            _instanceSampleCube.transform.position = Vector3.forward * _cylinder.transform.localScale.x;
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0;i<512;i++)
        {
            if(_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(10,10,(AudioVisualiser._samples[i] * _maxScale + 2));
               //_sampleCube[i].transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
                _sampleCube[i].transform.RotateAround(Vector3.zero,Vector3.up,rotateSpeed * Time.deltaTime);
                 _sampleCube[i].transform.LookAt(_cylinder.transform);
            }
        }
        _sampleCubePrefab.transform.Rotate(yAngle:.01f,xAngle:0,zAngle:0,relativeTo:Space.Self);
    }
}
