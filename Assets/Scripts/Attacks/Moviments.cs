using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviments : MonoBehaviour
{

	public float speed;
	public float timeToDestroy;

	void Start()
    {
		Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
