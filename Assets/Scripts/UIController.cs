using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private InputField _inputField;
    [SerializeField] private GameController _gameController;
    private int _amountPoint = 2;

    public void SetChangesSlider()
    {
        if (_inputField.text != "")
        {
            int amount = int.Parse(_inputField.text);
            _slider.value = amount;
            _amountPoint = amount;
        }
    }

    public void SetChangesInputField()
    {
        int amount = (int)_slider.value;
        _inputField.text = amount.ToString();
        _amountPoint = amount;
    }

    public void OnClickButtonStart()
    {
        _gameController.StartMovement(_amountPoint);
    }
}