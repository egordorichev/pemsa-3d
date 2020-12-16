using System;
using UnityEngine;

namespace emulator {
	public class AudioUnit : Unit {
		private const int SampleSize = 2048;
		private const int SampleRate = 44100;

		private double[] audioSamples;

		public AudioUnit(Emulator emulator) : base(emulator) {
			var audioConfig = AudioSettings.GetConfiguration();

			audioConfig.sampleRate = SampleRate;
			audioConfig.dspBufferSize = SampleSize;

			audioSamples = new double[SampleSize];

			AudioSettings.Reset(audioConfig);
			emulator.GetComponent<AudioSource>().Play();
		}

		#region Api
		public void OnAudioFilterRead(float[] data, int channels) {
			PemsaEmulator.SampleAudioMultiple(emulator.EmulatorPointer, audioSamples, SampleSize);
			for (int i = 0; i < SampleSize; i += 1)
			{
				for (int j = 0; j < channels; j += 1)
				{
					data[i * channels + j] = (float)audioSamples[i];
				}
			}
		}
		#endregion
	}
}