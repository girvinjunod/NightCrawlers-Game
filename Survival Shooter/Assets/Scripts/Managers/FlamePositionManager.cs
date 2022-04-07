using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePositionManager : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 2, transform.position.z);
    }
}
