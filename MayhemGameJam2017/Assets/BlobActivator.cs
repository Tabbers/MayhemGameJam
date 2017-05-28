using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobActivator : MonoBehaviour {

    GameObject[] blobs;
    int blobCount;
    int Counter = 0;

    float pastTime = 0.0f;
	// Use this for initialization
	void Start () {
        blobs = GameObject.FindGameObjectsWithTag("Blob");
        blobCount = blobs.Length;
    }
	
	// Update is called once per frame
	void Update () {
        pastTime += Time.deltaTime;

        if (pastTime > 1.0f && Counter < blobCount)
        {
            pastTime = 0.0f;

            blobs[Counter++].GetComponent<SpriteRenderer>().enabled = true;
        }

	}
}
