using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    Rigidbody body;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.materials[0].color = new Color(1, 1, 1, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ãæµ¹");
        if(collision.gameObject.tag == "Player")
        {
            ObstacleManager.Instance.StartCoroutine("spawnCloud", 
            new Vector3(transform.position.x, transform.position.y, transform.position.z));
            StartCoroutine("Flicker");
        }
    }

    IEnumerator Flicker()
    {
        int count = 0;
        while (count <3)
        {
            float fadeCount = 0;
            while(fadeCount < 1f)
            {
                fadeCount += 0.1f;
                yield return new WaitForSeconds(0.01f);
                meshRenderer.materials[0].color = new Color(1, 1, 1, fadeCount);
            }

            yield return new WaitForSeconds(0.5f);

            while (fadeCount > 0f)
            {
                fadeCount -= 0.1f;
                yield return new WaitForSeconds(0.01f);
                meshRenderer.materials[0].color = new Color(1, 1, 1, fadeCount);
            }

            count++;
        }
        Destroy(gameObject);
    }

}
