using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeresStatus : MonoBehaviour
{
    [SerializeField] private GameObject[] _knives = new GameObject[3];

    public int _knifeStack = 0;

    private void Awake()
    {
        ZeroStack();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public int KnifeStack
    {
        get { return _knifeStack; }
        set { if (_knifeStack == 0) return; _knifeStack = value; }
    }

    void ZeroStack()
    {
        for(int i = 0; i < _knives.Length; ++i)
        {
            foreach (GameObject knife in _knives)
            {
                Image _image = knife.GetComponent<Image>();
                if (_image != null)
                {
                    _image.color = Color.black;
                }
                else
                {
                    Debug.LogWarning("I can't see it.");
                }
            }
        }
    }

    public void IncreaseStack()
    {
        if (_knifeStack < _knives.Length)
        {
            Image image = _knives[_knifeStack].GetComponent<Image>();
            if (image != null)
            {
                image.color = Color.white;
            }
            _knifeStack++;
        }
    }

    public void DecreaseStack()
    {
        if (_knifeStack > 0)
        {
            _knifeStack--;
            Image image = _knives[_knifeStack].GetComponent<Image>();
            if (image != null)
            {
                image.color = Color.black;
            }
        }
    }
}
