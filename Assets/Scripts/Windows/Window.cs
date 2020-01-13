using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    List<GameObject> barriers = new List<GameObject>();

    List<Vector3> barriersPositions = new List<Vector3>();
    List<Quaternion> barriersRotations = new List<Quaternion>();

    int barriersRemaining;

    public bool windowClear; 

    [SerializeField]
    Transform enterPoint;
    public Transform EnterPoint { get { return enterPoint; } }

    void Start()
    {
        windowClear = false; 
        barriersRemaining = barriers.Count - 1; 

        foreach(GameObject g in barriers)
        {
            barriersPositions.Add(g.transform.position);
            barriersRotations.Add(g.transform.rotation);

            g.GetComponent<Rigidbody>().isKinematic = true; 
        }
    }

    public void RemoveBarrier()
    {
        barriers[barriersRemaining].GetComponent<Rigidbody>().isKinematic = false;
        if (barriersRemaining != 0)
            barriersRemaining--;
        else
            windowClear = true; 
    }

    public void ReplaceBarrier()
    {
        windowClear = false; 
        barriers[barriersRemaining].GetComponent<Rigidbody>().isKinematic = true;

        barriers[barriersRemaining].transform.position = barriersPositions[barriersRemaining];
        barriers[barriersRemaining].transform.rotation = barriersRotations[barriersRemaining];

        if (barriersRemaining < barriers.Count - 1)
        {
            barriersRemaining++;
        }
    }
}
