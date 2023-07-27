using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObject : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject moveToObject;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MoveAgentToPoint(true);
            moveToObject = null;
        }
        
        if(Input.GetMouseButton(1))
        {
            MoveAgentToPoint(false);
        }

        if(moveToObject != null)
        {
            _agent.destination = moveToObject.transform.position;
        }
    }

    void MoveAgentToPoint(bool isFollowMouse)
    {

        //create a ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //info bout the collider the ray was cast onto
        RaycastHit hitinfo;

        //cast the ray
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo))
        {
            if (isFollowMouse)
            {
                //Go to mouse position
                _agent.destination = hitinfo.point;
            }
            else
            {
                //otherwise follow gameobject
                _agent.destination = hitinfo.transform.position;
               
            }
        }

            //moveTooObject.transform.position;
    }
}
