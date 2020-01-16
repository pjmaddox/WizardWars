using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicCameraController : MonoBehaviour
{
    public GameObject objectToFollow;


    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = objectToFollow.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.transform.position - offset;
    }
}
