using UnityEngine;
using UnityEngine.UI;

public class DecodeDisplay : MonoBehaviour
{
    [SerializeField] private Image qrCodeImage;

    [SerializeField] private Button browseButton;
    [SerializeField] private Button decodeButton;
    
    private void OnEnable() => QrDecodeManager.LoadSprite += OnLoadSprite;

    private void OnDisable() => QrDecodeManager.LoadSprite -= OnLoadSprite;

    private void Awake() => InitListeners();

    private void Start() => SetDecodeButtonInteractableStatus(false);

    private void InitListeners()
    {
        browseButton.onClick.AddListener(QrDecodeManager.Instance.BrowseSprite);
        decodeButton.onClick.AddListener(QrDecodeManager.Instance.ReadQrCode);
    }
    
    private void OnLoadSprite(Sprite loadedSprite) => LoadSprite(loadedSprite);

    private void LoadSprite(Sprite qrCodeSprite)
    {
        qrCodeImage.sprite = qrCodeSprite;
        qrCodeImage.preserveAspect = true;
        SetDecodeButtonInteractableStatus(qrCodeSprite != null);
    }

    private void SetDecodeButtonInteractableStatus(bool isInteractable) => decodeButton.interactable = isInteractable;
}