using UnityEngine;
using UnityEngine.UI;

public class EnforcadoController : MonoBehaviour
{
    private int _life = 6;

    [SerializeField]
    Image Head;

    [SerializeField]
    Image Body;

    [SerializeField]
    Image LeftArm;

    [SerializeField]
    Image RightArm;

    [SerializeField]
    Image LeftLeg;

    [SerializeField]
    Image RightLeg;

    public bool DescontarVida()
    {
        if (_life == 6)
        {
            Head.enabled = true;
        }
        else if (_life == 5)
        {
            Body.enabled = true;
        }
        else if (_life == 4)
        {
            LeftArm.enabled = true;
        }
        else if (_life == 3)
        {
            RightArm.enabled = true;
        }
        else if (_life == 2)
        {
            LeftLeg.enabled = true;
        }
        else if (_life == 1)
        {
            RightLeg.enabled = true;
        }

        _life--;
        return _life != 0;
    }
}
