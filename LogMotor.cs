using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMotor : MonoBehaviour
{
   
    [System.Serializable]
    private class RotationPattern
    {
        #pragma warning disable 0649
        public float rotationSpeed;
        public float rotationDuration;
        #pragma warning restore 0649
    }

    [SerializeField]
    private RotationPattern[] rotationPatterns;

    private WheelJoint2D wheelJoint;
    private JointMotor2D jointMotor;


    private void Awake()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        jointMotor = new JointMotor2D();
        StartCoroutine(StartRotation());
    }

    IEnumerator StartRotation()
    {
        int rotationIndex = 0;
        while(true)
        {
            yield return new WaitForFixedUpdate();

            jointMotor.maxMotorTorque = 1000;
            jointMotor.motorSpeed = rotationPatterns[rotationIndex].rotationSpeed;
            wheelJoint.motor = jointMotor;

            yield return new WaitForSecondsRealtime(rotationPatterns[rotationIndex].rotationDuration);

            rotationIndex++;
            rotationIndex = rotationIndex < rotationPatterns.Length ? rotationIndex : 0;
        }
    }
    

}
