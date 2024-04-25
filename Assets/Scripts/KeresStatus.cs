using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeresStatus : MonoBehaviour
{
    [SerializeField] private GameObject[] _knives = new GameObject[3];

    public int _knifeStack = 3;

    Image image;
    EachKnifeStack _eachKnife;

    public int KnifeStack
    {
        get { return _knifeStack; }
        set { if (_knifeStack == 3) return; _knifeStack = value; }
    }

    private void Awake()
    {
        _knifeStack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetKnifeStacked();
    }

    public void SetKnifeStacked()
    {
        if (_knifeStack != 0)
        {
            for (int i = 0; i < _knifeStack; ++i)
            {
                EachKnifeStack _newKnives = _knives[i].GetComponent<EachKnifeStack>();
                _newKnives.StackON = true;
            }
        }
    }

    void DecreaseKnifeStack()
    {
        if (_knifeStack > 0)
        {
            EachKnifeStack _oldKnife = _knives[_knifeStack - 1].GetComponent<EachKnifeStack>();
            _oldKnife.StackON = false;
            _knifeStack--;
        }
    }

    //public void SetKnifeColor(int value)
    //{
    //    Color newColor = new();

    //    if(value < 0)
    //    {
    //        newColor = Color.black;
    //    }
    //    else
    //    {
    //        newColor = Color.white;
    //    }

    //    for(int i = 0; i < _knifeStack; ++i)
    //    {
    //        Image newimage = _knives[i].GetComponent<Image>();
    //        newimage.color = newColor;
    //    }
    //}
}
