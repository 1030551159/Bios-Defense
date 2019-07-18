using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraControllerr : MonoBehaviour
{
    public Image left;
    public Image right;
    public Image up;
    public Image down;
    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("hua");
            cameraMove(0, -2, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cameraMove(0, 2, 0);
        }
    }
    public void moveLeft()
    {
        StartCoroutine(ieMove(-2f,0,0,1));
    }

    public void moveRight()
    {
        StartCoroutine(ieMove(2f, 0,0,2));
    }

    public void moveUp()
    {
        
            StartCoroutine(ieMove(0, 0, 2f, 3));
    }

    public void moveDown()
    {
        
            StartCoroutine(ieMove(0, 0, -2f, 4));
    }

    public void stopMove()
    {
        StopAllCoroutines();
    }

    IEnumerator ieMove(float x,float y,float z,int dir)
    {
        while(true)
        {
            cameraMove(x, y, z);
            yield return new WaitForSeconds(0.02f);
        }
       
    }
    void cameraMove(float x, float y, float z)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.x = cameraPos.x + x;
        cameraPos.y = cameraPos.y + y;
        cameraPos.z = cameraPos.z + z;
        Camera.main.transform.position = cameraPos;

    }

}
