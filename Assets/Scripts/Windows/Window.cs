using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    List<GameObject> barriers = new List<GameObject>();

    [SerializeField]
    List<Vector3> barriersPositions = new List<Vector3>();
    List<Quaternion> barriersRotations = new List<Quaternion>();

    void Start()
    {
        foreach(GameObject g in barriers)
        {
            barriersPositions.Add(g.transform.position);
            barriersRotations.Add(g.transform.rotation);

            g.GetComponent<Rigidbody>().isKinematic = true; 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject g in barriers)
            {
                g.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        if(Input.GetKey(KeyCode.W))
        {
            for(int i = 0; i < barriers.Count; i++)
            {
                var b = barriers[i].GetComponent<Rigidbody>();
                //b.isKinematic = true;

                if (b.position != barriersPositions[i])
                {
                    Debug.Log("FUC");
                    Vector3.Lerp(b.position, barriersPositions[i], Time.deltaTime * 5);
                }

                if (b.rotation != barriersRotations[i])
                    Quaternion.Lerp(b.rotation, barriersRotations[i], Time.deltaTime * 5);

            }
        }
    }

    void OnTriggerEnter(Collider col)
    {

    }
}
