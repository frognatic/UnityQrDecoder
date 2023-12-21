using UnityEngine;
using ZXing;

public class QRCodeReader: IQRCodeReader
{
    private QrDecodeManager QrDecodeManager => QrDecodeManager.Instance;
    public Result Result { get; private set; }

    public void ReadQrCode()
    {
        IBarcodeReader reader = new BarcodeReader();

        Sprite spriteToConvert = QrDecodeManager.GetLoadedSprite();
        if (spriteToConvert == null)
            return;

        Texture2D inputTexture = ConvertSpriteToTexture2D(spriteToConvert);
        Color32[] barcodeBitmap = inputTexture.GetPixels32();

        Texture2D snap = new Texture2D(inputTexture.width, inputTexture.height, TextureFormat.RGBA32, false);
        snap.SetPixels32(barcodeBitmap);

        Result = reader.Decode(snap.GetRawTextureData(), inputTexture.width, inputTexture.height,
            RGBLuminanceSource.BitmapFormat.RGBA32);
    }

    public Texture2D ConvertSpriteToTexture2D(Sprite sprite)
    {
        Texture2D croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);

        Color[] pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
            (int)sprite.textureRect.y,
            (int)sprite.textureRect.width,
            (int)sprite.textureRect.height);

        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        return croppedTexture;
    }
}

public interface IQRCodeReader
{
    void ReadQrCode();
    Texture2D ConvertSpriteToTexture2D(Sprite sprite);
    Result Result { get; }
}