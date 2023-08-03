using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{

    public float Speed = 5f;
    public float WaitTime = 9.37f;
    public Vector3 PositionOffset = Vector3.zero;

    private Vector3 _closedPosition;
    private Vector3 _openPosition;
    void Start()
    {
        _closedPosition = transform.position;
        _openPosition = _closedPosition + PositionOffset;

        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        Vector3 goal = _openPosition;
        bool isOpenPosition = false;

        while (true)
        {

            if (Vector3.Distance(transform.position, goal) < 0.1f)
            {
                isOpenPosition = !isOpenPosition;
                if (isOpenPosition)
                {
                    goal = _closedPosition;
                }
                else
                {
                    goal = _openPosition;
                }
                yield return new WaitForSeconds(WaitTime);

            }

            transform.position = Vector3.MoveTowards(transform.position, goal, Speed * Time.deltaTime);

            yield return null;
        }
    }

}
