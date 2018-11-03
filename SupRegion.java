package Part2;

public enum SupRegion {

	UNITED_KINGDOM {
		@Override
		public String getRegionAsString() {
			// TODO Auto-generated method stub
			return "United Kingdom";
		}
	}, EUROPE {
		@Override
		public String getRegionAsString() {
			// TODO Auto-generated method stub
			return "Europe";
		}
	}, OUTSIDE_EU {
		@Override
		public String getRegionAsString() {
			// TODO Auto-generated method stub
			return "Outside Europe";
		}
	};

	public abstract String getRegionAsString();
		// TODO Auto-generated method stub
	}

