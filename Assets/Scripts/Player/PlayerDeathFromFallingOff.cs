using System;
using UnityEngine;

public class PlayerDeathFromFallingOff : MonoBehaviour
{
    public static event Action FallOff;
    private const float DEATH_THRESHOLD = -0.2f;
    private bool _eventWasRaised;

    private Rigidbody _rb;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < DEATH_THRESHOLD && !_eventWasRaised)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            FallOff?.Invoke();
            _eventWasRaised = true;
        }
    }
}
