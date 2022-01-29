using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode mode = Define.CameraMode.QuarterView;
    [SerializeField]
    Vector3 mDelta = new Vector3(0f, 6f, -5f);
    [SerializeField]
    GameObject mPlayer = null;
    
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(mPlayer.transform.position, mDelta, out hit, mDelta.magnitude,
                    LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - mPlayer.transform.position).magnitude * 0.8f;
                transform.position = mPlayer.transform.position + mDelta.normalized * dist;
            }
            else
            {
                transform.position = mPlayer.transform.position + mDelta;
                transform.LookAt(mPlayer.transform); 
            }


  
        }

    }

    public void SetQuarterView(Vector3 delta)
    {
        mode = Define.CameraMode.QuarterView;
        mDelta = delta;
    }
}
