using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows a game object with a fixed joint component to follow the child object that contains the grabbable component

public class FollowJointGrabbable : MonoBehaviour
{
  public Transform GrabbableTransform;
  public Rigidbody Rigidbody;

  private void FixedUpdate()
  {
    Rigidbody.MovePosition(GrabbableTransform.transform.position);
  }
}
