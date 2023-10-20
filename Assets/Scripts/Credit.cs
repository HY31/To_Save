using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{
    [SerializeField] private Image background;
    private Color color;

    private void Awake()
    {
        color = background.color;
    }

    void Update()
    {
        if (color.a < 1)
        {
            color.a += Time.deltaTime;
        }
        background.color = color;
    }
}
