using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 PointA;
    public Vector3 PointB;
    public float   Speed = 2f;

    private bool _movingToB = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Determine the target point
        var target = _movingToB
                        ? PointB
                        : PointA;

        transform.position = Vector3.MoveTowards(transform.position
                                               , target
                                               , Speed * Time.deltaTime);

        // Check if we've reached the target
        if (Vector3.Distance(transform.position
                           , target) < 0.1f)
        {
            _movingToB = ! _movingToB;
        }
    }
}
