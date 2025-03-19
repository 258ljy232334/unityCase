using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPtext : MonoBehaviour
{
    private float timer = 0;
    public void SetText(string text)
    {
        GetComponent<TMP_Text>().text = text;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
