using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _lifeTime = 5f;

    private void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
            {
                Destroy(gameObject);
            }
    }

    public void SetColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = randomColor;
    }
}
