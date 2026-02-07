using UnityEngine;

public class HandMovement : AffectedBySpeed
{   
    private Vector3 handPosition;
    public float amplitude;
    public float frequency;
    void Start()
    {
        handPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = handPosition + new Vector3(0, Mathf.Sin(Time.time * frequency * speedMultiplicator) * amplitude, 0);
    }
}
