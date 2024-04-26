using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EachKnifeStack : MonoBehaviour
{
    public bool _stackOn = false;
    private Image _image;

    [SerializeField] private float _easeXplus = 25f;
    [SerializeField] private float _easeYminus = 15f;
    [SerializeField] private float _easeDuration = 0.1f;

    private Vector3 initialPosition;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = Color.black;
        initialPosition = transform.position;
    }

    public bool StackON
    {
        get { return _stackOn; }
        set { _stackOn = value; IsStackON(value);}
    }
    void IsStackON(bool StackON)
    {
        if (StackON == true)
        {
            _image.color = Color.white;
            Vector3 beforeTransform = transform.position;
            transform.DOMove(new Vector3(transform.position.x + _easeXplus, transform.position.y - _easeYminus, 0f), _easeDuration).SetEase(Ease.InQuad);
            Debug.Log("나이프 1 충전");
        }
        else if (StackON == false)
        {
            _image.color = Color.black;
            transform.DOMove(initialPosition, _easeDuration).SetEase(Ease.InQuad);
            Debug.Log("나이프 1 소모");
        }
        
    }

}
