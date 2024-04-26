using UnityEngine;
using UnityEngine.UI;

public class EachKnifeStack : MonoBehaviour
{
    public bool _stackOn = false;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = Color.black;
    }

    public bool StackON
    {
        get { return _stackOn; }
        set { _stackOn = value; IsStackON(value);}
    }
    void IsStackON(bool StackON)
    {
        if(StackON == true)
        {
            _image.color = Color.white;
            Debug.Log("나이프 1 충전");
        }
        else if(StackON == false)
        {
            _image.color = Color.black;
            Debug.Log("나이프 1 소모");
        }
    }

}
