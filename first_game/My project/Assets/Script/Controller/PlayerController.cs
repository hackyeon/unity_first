using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;

    private Vector3 mDestination;
    
    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        Managers.Resources.Instantiate("UI/UI_Button");
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle
    }

    private PlayerState mState = PlayerState.Idle;

    void UpdateDie()
    {
        
    }

    void UpdateMoving()
    {
        Vector3 dir = mDestination - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            mState = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
                
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }
        
        // 애니메이션 처리
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", speed);
    }

    void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
    }
    
    void Update()
    {
        switch (mState)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (mState == PlayerState.Die)
        {
            return;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1.0f);
        LayerMask mask = LayerMask.GetMask("Wall");
            
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, mask))
        {
            mDestination = hit.point;
            mState = PlayerState.Moving;
        }
        
    }
}
