using System;
using System.IO;
using UnityEngine;

public class CartController : MonoBehaviour {
    public string Id = "celeste";
    private Texture2D labelTexture;

    public void Start() {
        var path = $"{Application.streamingAssetsPath}/{Id}.p8";

        try {
            var data = File.ReadAllLines(path);
            var labelI = -1;

            for (var i = 0; i < data.Length; i++) {
                if (data[i].StartsWith("__label__")) {
                    labelI = i;
                    break;
                }
            }

            if (labelI < 0) {
                return;
            }

            var texture = new Texture2D(128, 128);
            var size = 128 * 128;
            var pixels = new Color[size];

            for (var y = 0; y < 128; y++) {
                var line = data[y + labelI + 1];

                for (var x = 0; x < 128; x++) {
                    pixels[x + (127 - y) * 128] = Palette.standard[Util.HexToInt(line[x])];
                }
            }

            texture.filterMode = FilterMode.Point;

            texture.SetPixels(pixels);
            texture.Apply();

            labelTexture = texture;

            GetComponent<MeshRenderer>().materials[1].mainTexture = texture;
        } catch (Exception e) {
            Debug.LogError(e);
        }
    }
}