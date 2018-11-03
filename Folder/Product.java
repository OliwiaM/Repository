package Part2;

public class Product {
	
	private int proCode;
	private String proMake;
	private String proModel;
	private double proPrice;
	private int proQtyAvailable;
	private boolean proDiscontinued;
	
	public Product(int proCode, String proMake, String proModel, double proPrice, int proQtyAvailable,
			boolean proDiscontinued) {
		super();
		this.proCode = proCode;
		this.proMake = proMake;
		this.proModel = proModel;
		this.proPrice = proPrice;
		this.proQtyAvailable = proQtyAvailable;
		this.proDiscontinued = proDiscontinued;
	}

	
	public String getProductDetails()	{
		
		String productDetails = "Code: " + proCode;
		productDetails += "\nMake: " + proMake;
		productDetails += "\nModel: " + proModel;
		productDetails += "\nPrice: " + proPrice;
		productDetails += "\nQuantity Available: " + proQtyAvailable;
		productDetails += "\nDiscontinued: " + proDiscontinued;
		return productDetails;
	}
	
	public int getProCode() {
		return proCode;
	}

	public void setProCode(int proCode) {
		this.proCode = proCode;
	}

	public String getProMake() {
		return proMake;
	}

	public void setProMake(String proMake) {
		this.proMake = proMake;
	}

	public String getProModel() {
		return proModel;
	}

	public void setProModel(String proModel) {
		this.proModel = proModel;
	}

	public double getProPrice() {
		return proPrice;
	}

	public void setProPrice(double proPrice) {
		this.proPrice = proPrice;
	}

	public int getProQtyAvailable() {
		return proQtyAvailable;
	}

	public void setProQtyAvailable(int proQtyAvailable) {
		this.proQtyAvailable = proQtyAvailable;
	}

	public boolean isProDiscontinued() {
		return proDiscontinued;
	}

	public void setProDiscontinued(boolean proDiscontinued) {
		this.proDiscontinued = proDiscontinued;
	}
	
	
}
