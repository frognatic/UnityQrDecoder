using System;
using UnityEngine;
using Result = ZXing.Result;

public class QrDecodeManager : MonoSingleton<QrDecodeManager>
{
    public static event Action<Result> ReadQrResult;
    public static event Action<Sprite> LoadSprite;

    private IQRCodeReader qrCodeReader;
    private ISpriteBrowser spriteBrowser;
    
    private void Start()
    {
        qrCodeReader = new QRCodeReader();
        spriteBrowser = new SpriteBrowser();
    }

    public Sprite GetLoadedSprite() => spriteBrowser.LoadedSprite;

    public void BrowseSprite()
    {
        spriteBrowser.BrowseFile();
        LoadSprite?.Invoke(GetLoadedSprite());
    }

    public void ReadQrCode()
    {
        qrCodeReader.ReadQrCode();
        ReadQrResult?.Invoke(qrCodeReader.Result);
    }
}