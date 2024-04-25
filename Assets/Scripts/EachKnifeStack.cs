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

    private void Update()
    {
        
    }

    public bool StackON
    {
        get { return _stackOn; }
        set { _stackOn = value; }
    }

    void IsStackON(bool StackON)
    {
        if(StackON == true)
        {
            _image.color = Color.white;
        }
        else
        {
            _image.color = Color.black;
        }
    }
}
