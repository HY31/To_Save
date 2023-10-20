using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField]
    GameObject trap;
    float initPositionY;
    float distance = 0.3f;
    float turningPoint;
    float moveSpeed = 10f;
    bool onAttack = true;

    private void Awake()
    {
        initPositionY = trap.transform.position.y;
        turningPoint = trap.transform.position.y + distance;
    }
    void Start()
    {
        //trap.transform.position += new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (onAttack)
            {
                StartCoroutine("Attack");
                collision.gameObject.GetComponent<Health>().TakeDamage(100);
                //+ 플레이어에게 데미지 입히는 메서드
            }
        }
    }

    IEnumerator Attack()
    {
        float currentPositionY = trap.transform.position.y;
        onAttack = false;

        while (currentPositionY <= turningPoint)
        {
            trap.transform.position += new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
            currentPositionY = trap.transform.position.y;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(5f);

        while (currentPositionY > initPositionY)
        {
            trap.transform.position += new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
            currentPositionY = trap.transform.position.y;
            yield return new WaitForSeconds(0.01f);
        }
        onAttack = true;
    }

}
