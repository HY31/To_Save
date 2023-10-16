using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private static ObstacleManager instance = null;
    [SerializeField] GameObject cloud;

    private void Awake()
    {
        if (null == instance) //DontDestroyOnload 중복검사
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    public static ObstacleManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator spawnCloud(Vector3 spwanPos)
    {
        yield return new WaitForSeconds(10f);
        Instantiate(cloud, spwanPos, cloud.transform.rotation);
    }
}
