using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerGroundedToPlatform : MonoBehaviour
{
    public List<GameObject> myGroundedObjects = new List<GameObject>();
    
    public Vector3 myLastPosition;

    private Transform myTransorm;

    void Setup()
    {
        myTransorm = this.transform;
        myLastPosition = myTransorm.position;
    }

    private void Awake() {
        Setup();    
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        UpdateGroundedObjects();
    }

    /// <summary>
    /// OnCollisionExit is called when this collider/rigidbody has
    /// stopped touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionExit(Collision other)
    {
        //if collider's object is in the list of grounded objects, then remove it
        myGroundedObjects.Remove(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        //if collider's object is on the combatants layer then add them to the list of grounded objects
        if(other.gameObject.layer == LayerMask.NameToLayer("Battle"))
        {
            myGroundedObjects.Add(other.gameObject);
        }
    }

    void UpdateGroundedObjects()
    {
        //If the list of grounded objects is not empty:
        if(myGroundedObjects.Count > 0)
        {
            //get current position
            var current = myTransorm.position;            
            
            //find delta between last and current
            var delta = current - myLastPosition;

            //apply that move to the grounded objects
            foreach(var x in myGroundedObjects)
            {
                x.transform.position += delta;
            }
        }
    }
}
