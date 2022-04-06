using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : EnemyMovement
{
    Transform skeleton;

    override protected void Awake()
    {
        base.Awake();
        skeleton = GameObject.FindGameObjectWithTag("Skeleton").transform;
    }

    override protected void Update()
    {
        Turning();
    }

    void Turning()
    {
        var point = player.position;
        point.y = transform.position.y;
        transform.LookAt(point);
    }

}
