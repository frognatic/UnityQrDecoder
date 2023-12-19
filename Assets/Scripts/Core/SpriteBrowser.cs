using System.IO;
using System.Linq;
using SFB;
using UnityEngine;

public class SpriteBrowser
{
    public Sprite LoadedSprite { get; private set; }

    private string path;

    public void BrowseFile()
    {
        string[] filePanelPath = StandaloneFileBrowser.OpenFilePanel("Overwrite with png", "", "png", false);
        FillPath(filePanelPath);
        LoadedSprite = !string.IsNullOrEmpty(path) ? CreateSpriteFromBytes() : null;
    }

    private Sprite CreateSpriteFromBytes()
    {
        Texture2D textureFromBytes = CreateTextureFromBytes();

        return Sprite.Create(textureFromBytes, new Rect(0, 0, textureFromBytes.width, textureFromBytes.height),
            new Vector2(textureFromBytes.width / 2f, textureFromBytes.height / 2f));
    }

    private Texture2D CreateTextureFromBytes()
    {
        byte[] fileContent = File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(1, 1); // note that the size is overridden
        tex.LoadImage(fileContent);

        return tex;
    }

    private void FillPath(string[] paths) => path = paths.Length == 0 ? string.Empty : paths.First();
}