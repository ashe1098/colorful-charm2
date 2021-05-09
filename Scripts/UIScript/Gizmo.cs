using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public float Gizmo_Size = 0.3f;
    public Color Gizmo_Color = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Gizmo_Color;
        Gizmos.DrawWireSphere(transform.position, Gizmo_Size);
    }
}
