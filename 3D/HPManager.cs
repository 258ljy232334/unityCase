using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField] private GameObject HPText;
    public void ShowText(string text)
    {
        GameObject go = Instantiate(HPText, transform);
        go.GetComponent<HPtext>().SetText(text);
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
