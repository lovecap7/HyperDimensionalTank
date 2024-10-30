using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEffect : MonoBehaviour
{
    [SerializeField]
    private int _intensity = 2;
    private RenderTexture[] _renderTextures = new RenderTexture[30];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnRenderImage(RenderTexture source, RenderTexture dest)
    {

        var width = source.width;
        var height = source.height;
        var currentSource = source;

        var i = 0;
        RenderTexture currentDest = null;
        // 段階的にダウンサンプリング
        for (; i < _intensity; i++)
        {
            width /= 2;
            height /= 2;
            if (width < 2 || height < 2)
            {
                break;
            }
            currentDest = _renderTextures[i] = RenderTexture.GetTemporary(width, height, 0, source.format);
            Graphics.Blit(currentSource, currentDest);
            currentSource = currentDest;
        }

        // アップサンプリング
        for (i -= 2; i >= 0; i--)
        {
            currentDest = _renderTextures[i];
            Graphics.Blit(currentSource, currentDest);
            _renderTextures[i] = null;
            RenderTexture.ReleaseTemporary(currentSource);
            currentSource = currentDest;
        }

        // 最後にdestにBlit
        Graphics.Blit(currentSource, dest);
        RenderTexture.ReleaseTemporary(currentSource);
    }
}
