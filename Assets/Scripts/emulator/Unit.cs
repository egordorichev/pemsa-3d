namespace emulator {
	public class Unit {
		protected static Emulator emulator;

		public Unit(Emulator emulator) {
			Unit.emulator = emulator;
		}

		public virtual void Update() {

		}
	}
}