using System;
using DG.Tweening;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int Id { get; set; }
    public bool Detouched { get; private set; }

    [ContextMenu("Detouch cube")]
    public void Detouch()
    {
        if (Detouched)
            return;

        Detouched = true;
        GetComponentInParent<Entity>().DetouchCube(this);
    }

    public void Destroy()
    {
        Detouch();

        Destroy(gameObject);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            Destroy();
        }
    }
}