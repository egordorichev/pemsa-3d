using System;
using System.IO;
using UnityEngine;

public class CartController : MonoBehaviour {
    public string Id = "celeste";
    private Texture2D labelTexture;
    private Texture2D creditsTexture;

    public void Start() {
        var path = $"{Application.streamingAssetsPath}/carts/{Id}.p8";

        try {
            var data = File.ReadAllLines(path);
            var labelI = -1;
            var creditsI = -1;

            for (var i = 0; i < data.Length; i++) {
                var line = data[i];

                if (line.StartsWith("__label__")) {
                    labelI = i;
                } else if (line.StartsWith("__credits__")) {
                    creditsI = i;
                }
            }

            var renderer = GetComponent<MeshRenderer>();

            if (labelI != -1) {
                labelTexture = ReadTexture(data, labelI, 128, 128);
                renderer.materials[1].mainTexture = labelTexture;
            }

            if (creditsI != -1) {
                creditsTexture = ReadTexture(data, creditsI, 130, 32);
                renderer.materials[2].mainTexture = creditsTexture;
            }
        } catch (Exception e) {
            Debug.LogError(e);
        }
    }

    private Texture2D ReadTexture(string[] data, int position, int width, int height) {
        var texture = new Texture2D(width, height);
        var size = 128 * 128;
        var pixels = new Color[size];

        for (var y = 0; y < height; y++) {
            var yi = y + position + 1;

            if (yi >= data.Length) {
                break;
            }

            var line = data[yi];

            for (var x = 0; x < width && x < line.Length; x++) {
                pixels[x + (height - y - 1) * width] = Palette.standard[Util.HexToInt(line[x])];
            }
        }

        texture.filterMode = FilterMode.Point;

        texture.SetPixels(pixels);
        texture.Apply();

        return texture;
    }
}