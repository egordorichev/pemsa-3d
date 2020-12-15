using System;
using UnityEngine;

namespace emulator {
	public class AudioUnit : Unit {
		private const int SampleSize = 2048;
		private const int SampleRate = 44100;

		public AudioUnit(Emulator emulator) : base(emulator) {
			var audioConfig = AudioSettings.GetConfiguration();

			audioConfig.sampleRate = SampleRate / 2;
			audioConfig.dspBufferSize = SampleSize;

			AudioSettings.Reset(audioConfig);
			emulator.GetComponent<AudioSource>().Play();
		}

		#region Api
		public void OnAudioFilterRead(float[] data, int channels) {
			var dataLen = data.Length / channels;

			for (int i = 0; i < dataLen; i += 1) {
				for (int j = 0; j < channels; j += 1) {
					data[i * channels + j] = (float) PemsaEmulator.SampleAudio(emulator.EmulatorPointer);
				}
			}
		}
		#endregion
	}
}