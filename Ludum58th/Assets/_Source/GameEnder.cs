using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private RectTransform _photoPanel;
    [SerializeField] private float _scaleSpeedFactor;
    [SerializeField] private float _targetScale;
    private Vector3 _targetScaleVector;

    [SerializeField] private bool isPhotoDone = false;

    private float currTime;
    [SerializeField] private float delay;

    [field:SerializeField]
    public List<Slot> photoSlots { get; private set; } = new();

    [SerializeField] private ThroughScenes _sceneManager;
    [SerializeField] private InputListener _inputListener;

    private void Start()
    {
        _targetScaleVector = _photoPanel.localScale * _targetScale;
    }

    private void FixedUpdate()
    {
        if (isPhotoDone)
        {
            _photoPanel.localScale = Vector3.Lerp(_photoPanel.localScale, _targetScaleVector, _scaleSpeedFactor * Time.deltaTime);
            _inputListener.DisableInputs();
            if (_photoPanel.localScale.x >= _targetScaleVector.x - 0.05f)
            {
                currTime += Time.deltaTime;
                if (delay <= currTime)
                {
                    _sceneManager.GoToMenuScene();
                }
            }
        }
    }

    public void ConstructPhotoDone() => isPhotoDone = true;
}
