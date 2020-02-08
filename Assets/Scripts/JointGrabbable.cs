using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointGrabbable : OVRGrabbable
{
  public Transform FixedJointTransform;
  public float ReleaseThreshold;

  public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
  {
    base.GrabEnd(Vector3.zero, Vector3.zero);
    transform.position = FixedJointTransform.transform.position;
    transform.rotation = FixedJointTransform.transform.rotation;

    Rigidbody fixedJointRb = FixedJointTransform.GetComponent<Rigidbody>();
    fixedJointRb.velocity = Vector3.zero;
    fixedJointRb.angularVelocity = Vector3.zero;
  }

  private void Update()
  {
    if (Vector3.Distance (FixedJointTransform.position, this.transform.position) > ReleaseThreshold)
    {
      grabbedBy.ForceRelease(this);
    }
  }
}