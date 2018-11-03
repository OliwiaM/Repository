package Part2;

public class Address {

	private int bldnum;
	private String bldStreet;
	private String bldTown;
	private String bldPCode;
	private String bldCountry;
	
	public Address(int bldnum, String bldStreet, String bldTown, String bldPCode, String bldCountry) {
		super();
		this.bldnum = bldnum;
		this.bldStreet = bldStreet;
		this.bldTown = bldTown;
		this.bldPCode = bldPCode;
		this.bldCountry = bldCountry;
	}
	
	
	public String getFullAddress() {
		
		String fullAddress = "\n" + "No: " + bldnum + "\n";
		fullAddress += "Street: " + bldStreet + "\n";
		fullAddress += "Town: " + bldTown+ "\n";
		fullAddress += "Post Code: " + bldPCode+ "\n";
		fullAddress += "Country: " + bldCountry;
		return fullAddress;
	}
	
	public int getBldnum() {
		return bldnum;
	}

	public void setBldnum(int bldnum) {
		this.bldnum = bldnum;
	}

	public String getBldStreet() {
		return bldStreet;
	}

	public void setBldStreet(String bldStreet) {
		this.bldStreet = bldStreet;
	}

	public String getBldTown() {
		return bldTown;
	}

	public void setBldTown(String bldTown) {
		this.bldTown = bldTown;
	}

	public String getBldPCode() {
		return bldPCode;
	}

	public void setBldPCode(String bldPCode) {
		this.bldPCode = bldPCode;
	}

	public String getBldCountry() {
		return bldCountry;
	}

	public void setBldCountry(String bldCountry) {
		this.bldCountry = bldCountry;
	}

}
