using TMPro;
using UnityEngine;
using ZXing;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    
    private void OnEnable()
    {
        QrDecodeManager.ReadQrResult += SetResultText;
        QrDecodeManager.LoadSprite += SetClickDecodeText;
    }

    private void OnDisable()
    {
        QrDecodeManager.ReadQrResult -= SetResultText;
        QrDecodeManager.LoadSprite -= SetClickDecodeText;
    }

    private void Start() => SetInitText();
    
    private void SetResultText(Result result)
    {
        resultText.text = result != null ? $"Decoding Successful: {result.Text}" : "Decoding failed";
        resultText.color = result != null ? Color.green : Color.red;
    }
    
    private void SetInitText()
    {
        resultText.text = $"Select correct file to decode.";
        resultText.color = Color.white;
    }

    private void SetClickDecodeText(Sprite loadedSprite)
    {
        resultText.text = loadedSprite != null ? $"Click Decode button to decode QR Code." : $"Select correct file to decode.";
        resultText.color = Color.white;
    }
}
