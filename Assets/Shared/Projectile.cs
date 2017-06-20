using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private float timeToLive;

    [SerializeField]
    private float damage;

    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {

        print("Hit: " + other.name);

        var destructable = other.transform.GetComponent<Destructable>();
        if (destructable == null)
            return;

        destructable.TakeDamage(damage);
    }
}
