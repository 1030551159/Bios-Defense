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
           if (Camera.main.transform.position.z - center.transform.position.z > -120)
           {
                cameraMove(0, 0, -2);
           }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.transform.position.z - center.transform.position.z < -70)
            {
                cameraMove(0, 0, 2);
            }
        }
    }
    public void moveLeft()
    {
        StartCoroutine(ieMove(-0.2f,0,0,1));
    }

    public void moveRight()
    {
        StartCoroutine(ieMove(0.2f, 0,0,2));
    }

    public void moveUp()
    {
        
            StartCoroutine(ieMove(0, 0.2f,0,3));
    }

    public void moveDown()
    {
        
            StartCoroutine(ieMove(0, -0.2f,0,4));
    }

    public void stopMove()
    {
        StopAllCoroutines();
    }

    IEnumerator ieMove(float x,float y,float z,int dir)
    {
        while(true)
        {
            if (left.transform.localPosition.x - center.transform.localPosition.x < -400&&dir==1)
                break;
            if (right.transform.localPosition.x - center.transform.localPosition.x > 400&&dir==2)
                break;
            if (up.transform.localPosition.y - center.transform.localPosition.y > 250&&dir==3)
                break;
            if (down.transform.localPosition.y - center.transform.localPosition.y < -250&&dir==4)
                break;
            cameraMove(x, y, z);

            yield return 0.02f;
        }
       
    }
    void cameraMove(float x, float y, float z)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.x = cameraPos.x + x;
        cameraPos.y = cameraPos.y + y;
        cameraPos.z = cameraPos.z + z;
        Camera.main.transform.position = cameraPos;

        Vector3 lpos = left.transform.position;
        lpos.x = left.transform.position.x + x;
        lpos.y = left.transform.position.y + y;
        lpos.z = left.transform.position.z + z;
        left.transform.position = lpos;

        Vector3 rpos = right.transform.position;
        rpos.x = right.transform.position.x + x;
        rpos.y = right.transform.position.y + y;
        rpos.z = right.transform.position.z + z;
        right.transform.position = rpos;

        Vector3 upos = up.transform.position;
        upos.x = up.transform.position.x + x;
        upos.y = up.transform.position.y + y;
        upos.z = up.transform.position.z + z;
        up.transform.position = upos;

        Vector3 dpos = down.transform.position;
        dpos.x = down.transform.position.x + x;
        dpos.y = down.transform.position.y + y;
        dpos.z = down.transform.position.z + z;
        down.transform.position = dpos;
    }

}
