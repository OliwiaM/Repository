package Part2;

import java.util.ArrayList;

public class Supplier {

	private int supCode;
	private String supName;
	private Address supAddress;
	private SupRegion supRegion;
	private ArrayList<Product> supProducts = new ArrayList<Product>();

	public Supplier(int supCode, String supName, Address supAddress, SupRegion supRegion,
			ArrayList<Product> supProducts) {

		this.supCode = supCode;
		this.supName = supName;
		this.supAddress = supAddress;
		this.supRegion = supRegion;
		this.supProducts = supProducts;
	}

	public void printProductsList() {
		System.out.println("Supplier name: " + getSupName());
		System.out.println(this.supName + " Makes:");
		for (Product eachProduct : supProducts) {
			System.out.println(eachProduct.getProductDetails() + "\n");
		}
	}

	public String getSuppliersDetails() {

		String productDetails = "Code: " + supCode;
		productDetails += "\nName: " + supName;
		productDetails += "\nAddress: " + supAddress.getFullAddress();
		productDetails += "\nRegion: " + supRegion;

		for (Product eachProduct : supProducts) {
			productDetails += "\nProducts:" + " " + eachProduct.getProCode() + "\n";
		}
		return productDetails;
	}

	public int getSupCode() {
		return supCode;
	}

	public void setSupCode(int supCode) {
		this.supCode = supCode;
	}

	public String getSupName() {
		return supName;
	}

	public void setSupName(String supName) {
		this.supName = supName;
	}

	public Address getSupAddress() {
		return supAddress;
	}

	public void setSupAddress(Address supAddress) {
		this.supAddress = supAddress;
	}

	public SupRegion getSupRegion() {
		return supRegion;
	}

	public void setSupRegion(SupRegion supRegion) {
		this.supRegion = supRegion;
	}

	public ArrayList<Product> getSupProducts() {
		return supProducts;
	}

	public void setSupProducts(ArrayList<Product> supProducts) {
		this.supProducts = supProducts;
	}

}
