using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCloudController : MonoBehaviour
{
    [SerializeField] private GameObject Cloud1;
    [SerializeField] private GameObject Cloud2;
    [SerializeField] private GameObject Cloud3;

    private bool _isShow = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _funShowCloud1();
    }
    private void _funShowCloud1()
    {
        if(!GlobalVariables.isLevel && !_isShow)
        {
            _isShow = true;
            Cloud1.SetActive(true);
            LeanTween.scale(Cloud1, new Vector3(1f, 1f), 0.7f).setEaseInBounce().setOnComplete(_funShowCloud2);
        }
        else if(GlobalVariables.isLevel && _isShow)
        {
            _isShow = false;
            LeanTween.scale(Cloud3, new Vector3(0f, 0f), 0.7f).setEaseInSine().setOnComplete(_funHideCloud2);
        }
    }
    private void _funShowCloud2()
    {
        Cloud2.SetActive(true);
        LeanTween.scale(Cloud2, new Vector3(1f, 1f), 0.7f).setEaseInBounce().setOnComplete(_funShowCloud3);
    }
    private void _funHideCloud2()
    {
        LeanTween.scale(Cloud2, new Vector3(0f, 0f), 0.7f).setEaseInSine().setOnComplete(_funHideCloud3);
    }

    private void _funShowCloud3()
    {
        Cloud3.SetActive(true);
        LeanTween.scale(Cloud3, new Vector3(1.3f, 1.3f), 0.7f).setEaseInBounce();
    }
    private void _funHideCloud3()
    {
        LeanTween.scale(Cloud1, new Vector3(0f, 0f), 0.7f).setEaseInSine();
        Cloud1.SetActive(false);
        Cloud2.SetActive(false);
        Cloud3.SetActive(false);
    }
}