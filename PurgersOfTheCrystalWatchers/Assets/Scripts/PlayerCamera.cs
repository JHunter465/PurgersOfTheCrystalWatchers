using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject cmCam;
    [SerializeField] private float lookSpeedVertical;
    [SerializeField] private float lookSpeedHorizontal;

    private CinemachineFreeLook vCam;

    private void Awake()
    {
        vCam = cmCam.GetComponent<CinemachineFreeLook>();
    }
    public void Look(float _horizontal, float _vertical, float _horizontalMouse, float _verticalMouse, bool _inputFlag)
    {
        float _yValue;
        float _xValue;
        if (!_inputFlag)
        {
            _yValue = (_verticalMouse / Screen.height).Remap(0, 1, 1, 0);
            _xValue = _horizontalMouse.Remap(0, Screen.width, -180, 180);
            vCam.m_YAxis.Value = _yValue;
            vCam.m_XAxis.Value = _xValue;
        }
        else
        {
            vCam.m_YAxis.Value += _vertical * lookSpeedVertical;
            vCam.m_XAxis.Value += _horizontal * lookSpeedHorizontal;
        }


    }
}

public static class ExtensionMethods
{
    public static float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }
}
