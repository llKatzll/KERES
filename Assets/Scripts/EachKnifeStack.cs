using UnityEngine;
using UnityEngine.UI;

public class EachKnifeStack : MonoBehaviour
{
    [SerializeField] private bool _stackON = false;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        image.color = Color.black;
    }

    private void Update()
    {
        CheckStacked();
    }

    public bool StackON
    {
        get { return _stackON; } 
        set { _stackON = value; }
    }

    void CheckStacked()
    {
        Transform parentObj = transform.parent;

        if (parentObj != null)
        {
            KeresStatus _keresStatus = parentObj.GetComponent<KeresStatus>();
            if (_keresStatus != null)
            {
                if (StackON == true)
                {
                    image.color = Color.white;
                }
            }
        }
    }
}
