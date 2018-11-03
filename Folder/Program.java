package Part2;

import java.util.ArrayList;
import java.util.EnumSet;
import java.util.InputMismatchException;
import java.util.Scanner;

public class Program {

	public static Scanner sc = new Scanner(System.in);
	public static ArrayList<Supplier> Suppliers = new ArrayList<Supplier>();

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ArrayList<Product> Products1 = new ArrayList<Product>();
		ArrayList<Product> Products2 = new ArrayList<Product>();
		ArrayList<Product> Products3 = new ArrayList<Product>();
		Address A1 = new Address(27, "Pier Road", "Stanton John", "OX33 5UW", "Sweden");
		Address A2 = new Address(1, "105 Boucher Rd", "Belfast,", "BT12 6UA", "Northern Ireland");
		Address A3 = new Address(164, "Sunburst Drive", "Marco Island", "33937", "United States");
		Product P1 = new Product(1, "MALM", "Storage Bed", 499.00, 15, false);
		Product P2 = new Product(2, "ProAction", "Dome Tent", 39.99, 50, false);
		Product P3 = new Product(3, "295W Honey M", "Solar Module", 157.98, 1000, true);
		Products1.add(P1);
		Products2.add(P2);
		Products3.add(P3);
		Supplier S1 = new Supplier(1, "Ikea", A1, SupRegion.EUROPE, Products1);
		Supplier S2 = new Supplier(2, "Argos", A2, SupRegion.UNITED_KINGDOM, Products2);
		Supplier S3 = new Supplier(3, "Crawford", A3, SupRegion.OUTSIDE_EU, Products3);
		Suppliers.add(S1);
		Suppliers.add(S2);
		Suppliers.add(S3);

		Program.MainMenu();
	}

	// Console menu with input type validated by a try catch and range validated
	// with a switch
	public static void MainMenu() {
		System.out.println("---------Main Menu---------");
		System.out.println("Please Enter A Number In Range 1-9:");
		System.out.println("1.Print All Products");
		System.out.println("2.Print All Suppliers");
		System.out.println("3.Add New Supplier");
		System.out.println("4.Add New Product");
		System.out.println("5.Order Product");
		System.out.println("6.Search Product By Price");
		System.out.println("7.Edit Product Details");
		System.out.println("8.Delete Supplier");
		System.out.println("9.Exit Application");

		int choice = 0;
		try {
			choice = sc.nextInt();
			sc.nextLine();

		} catch (InputMismatchException e) {
			System.out.println("Error. A whole number must be entered. \n");
			sc.nextLine();
			MainMenu();

		}

		switch (choice) {

		case 1:
			Program.PrintAllProducts();
			break;
		case 2:
			Program.PrintAllSuppliers();
			break;
		case 3:
			Program.AddNewSupplier(Suppliers);
			break;
		case 4:
			Program.AddNewProduct();
			break;
		case 5:
			Program.OrderProduct(sc, Suppliers);
		case 6:
			Program.searchProductByPrice(sc, Suppliers);
			break;
		case 7:
			Program.editProductDetails(sc);
			break;
		case 8:
			Program.deleteSupplier(sc, Suppliers);
			break;
		case 9:
			System.exit(0);
			break;
		default:
			System.out.println("Error. Enter a number ranging from 1-9. \n");
			MainMenu();
		}

	}

	// prints all products for each supplier within the supplier array
	public static void PrintAllProducts() {
		System.out.println("---Product Details---");
		for (Supplier eachSupplier : Suppliers) {
			eachSupplier.printProductsList();
		}

		MainMenu();
	}

	// adds new address by getting user input from the scanner and using it to
	// create a new address object
	public static void PrintAllSuppliers() {
		System.out.println("---Supplier Details---");
		for (Supplier eachSupplier : Suppliers) {
			System.out.println(eachSupplier.getSuppliersDetails());
		}

		MainMenu();
	}

	// method which checks if the string contains letters without invalid characters
	public static String ValidatingString() {
		String input = null;
		boolean valid;
		do {
			valid = false;
			if (sc.hasNext(".*[a-zA-Z]+.*[a-zA-Z]")) {
				input = sc.nextLine();
				valid = true;
			}
			if (!valid) {
				System.out.println("Error. Your input should only contain letters." + "\nTry again:");
				sc.nextLine();
			}
		} while (!valid);
		return input;
	}

	// method which checks whether the input is an integer larger than 0
	public static int ValidatingInt() {
		int input = 0;
		boolean valid;
		do {
			valid = false;
			if (sc.hasNextInt()) {
				input = sc.nextInt();
				sc.nextLine();
				valid = true;
				if (input <= 0) {
					System.out.println("Error. The input should be larger than 0." + "\nTry again:");
					valid = false;
				}
			} else {
				System.out.println("Error. Your input should only contain numbers." + "\nTry again:");
				sc.nextLine();
			}
		} while (!valid);
		return input;
	}

	// method which checks whether the input is a double larger than 0
	public static double ValidatingDouble() {
		double input = 0.0;
		boolean valid;
		do {
			valid = false;
			if (sc.hasNextDouble()) {
				input = sc.nextDouble();
				valid = true;
				if (input <= 0.0) {
					System.out.println("Error. The input should be larger than 0." + "\nTry again:");
					valid = false;
				}
			} else {
				System.out.println("Error. Your input should only contain numbers." + "\nTry again:");
				sc.nextLine();
			}
		} while (!valid);
		return input;
	}

	// method which checks whether the input is a non negative integer
	public static int ValidatingQuantity() {
		int input = 0;
		boolean valid;
		do {
			valid = false;
			if (sc.hasNextInt()) {
				input = sc.nextInt();
				sc.nextLine();
				valid = true;
				if (input < 0) {
					System.out.println("Error. The input should be larger than 0." + "\nTry again:");
					valid = false;
				}
			} else {
				System.out.println("Error. Your input should only contain numbers." + "\nTry again:");
				sc.nextLine();
			}
		} while (!valid);
		return input;
	}

	// adds new address by getting user input from the scanner and using it to
	// create a new address object
	public static Address AddNewAddress() {

		System.out.println("Enter the building number:");
		int bldnum = ValidatingInt();
		System.out.println("Enter the street:");
		String bldStreet = ValidatingString();
		System.out.println("Enter the town:");
		String bldTown = ValidatingString();
		System.out.println("Enter the post code:");
		String bldPCode = sc.nextLine();
		System.out.println("Enter the country:");
		String bldCountry = ValidatingString();
		Address address = new Address(bldnum, bldStreet, bldTown, bldPCode, bldCountry);
		return address;

	}

	// adds new supplier by getting user input from the scanner and using it to
	// create a new supplier object
	public static void AddNewSupplier(ArrayList<Supplier> Suppliers) {
		int supCode = 0;
		boolean valid;
		SupRegion supRegion = null;
		System.out.println("----Adding New Supplier----");

		// validates the code
		do {
			System.out.println("Enter the supplier code:");
			valid = false;
			// checks if input is an integer
			if (sc.hasNextInt()) {
				supCode = sc.nextInt();
				sc.nextLine();
				valid = true;
				// checks if supCode is larger than 0
				if (supCode <= 0) {
					System.out.println("Error. The supplier code should be larger than 0.");
					valid = false;
				}
				// checks if supCode already exists within Suppliers array
				for (Supplier eachSupplier : Suppliers) {
					if (supCode == eachSupplier.getSupCode()) {
						System.out.println("Error. This supplier code already exists.");
						valid = false;
					}
				}

			} else {
				System.out.println("Error. Your input should only contain numbers.");
				sc.nextLine();
			}
		} while (!valid);

		System.out.println("Enter the supplier name:");
		String supName = ValidatingString();
		System.out.println("---Entering Supplier Address---");
		Address supAddress = AddNewAddress();
		System.out.println("---Entering Supplier Region---");
		System.out.println("Region choices: ");
		// Prints out all available region choices
		for (int i = 0; i < EnumSet.allOf(SupRegion.class).size(); i++) {
			System.out.println((i + 1) + ". " + SupRegion.values()[i].getRegionAsString());
		}

		do {
			System.out.println("Please type the number corresponding to supplier's region:");
			// checks if input is an integer
			if (sc.hasNextInt()) {
				int temp = sc.nextInt();
				sc.nextLine();
				// checks if input is within range
				if ((temp >= 1) && (temp <= 3)) {
					valid = true;
					supRegion = SupRegion.values()[temp - 1];
				}

				else {
					System.out.println("Error. The region number is outside the range.");
					valid = false;
				}
			}

			else {
				System.out.println("Error. Your input should only contain numbers.");
				sc.nextLine();
			}

		} while (!valid);

		ArrayList<Product> supProduct = new ArrayList<Product>();
		// Runs the method AddNewProductToSupplier if the user wants to add products to
		// the supplier immediately
		System.out.println("Do you wish to add any products to the supplier? Enter 'y' for yes and 'n' for no:");
		char input = sc.next().charAt(0);
		if (input == 'y') {
			System.out.println("---Entering supplier's products.---");
			supProduct = AddNewProductToSupplier();
		}
		Supplier supplier = new Supplier(supCode, supName, supAddress, supRegion, supProduct);
		Suppliers.add(supplier);

		MainMenu();
	}

	// adds product to the newly created supplier
	public static ArrayList<Product> AddNewProductToSupplier() {
		ArrayList<Product> supProduct = new ArrayList<Product>();
		System.out.println("Enter the number of products you wish to add:");
		int productNo = ValidatingInt();
		int proCode = 0;
		// loops through the number of products to add
		for (int i = 0; i < productNo; i++) {
			System.out.println("Enter the product code:");
			proCode = ValidatingInt();
			System.out.println("Enter the make:");
			String proMake = sc.nextLine();
			System.out.println("Enter the model:");
			String proModel = sc.nextLine();
			System.out.println("Enter the price:");
			Double proPrice = ValidatingDouble();
			System.out.println("Enter the quantity available:");
			int proQtyAvailable = ValidatingQuantity();
			System.out.println("Is the product discontinued? Enter 'y' for yes and 'n' for no: ");
			char input = sc.next().charAt(0);
			// sets discontinued to true if input is y, leaves it false otherwise
			boolean proDiscontinued = false;
			if (input == 'y') {
				proDiscontinued = true;
			}
			// adds product to the supProduct array
			supProduct.add(new Product(proCode, proMake, proModel, proPrice, proQtyAvailable, proDiscontinued));
		}
		MainMenu();
		return supProduct;

	}

	// Adds new product to an existing supplier
	public static void AddNewProduct() {

		System.out.println("---Adding Product---");
		System.out.println("Enter the product code:");
		int proCode = ValidatingInt();
		System.out.println("Enter the product make:");
		String proMake = sc.nextLine();
		System.out.println("Enter the model:");
		String proModel = sc.nextLine();
		System.out.println("Enter the price:");
		Double proPrice = ValidatingDouble();
		System.out.println("Enter the quantity available:");
		int proQtyAvailable = ValidatingQuantity();
		boolean proDiscontinued = false;
		char input = sc.next().charAt(0);
		if (input == 'y') {
			proDiscontinued = true;
		}

		System.out.println("---Add Product To A Supplier---");
//prints out all the suppliers within Suppliers array
		for (int i = 0; i < Suppliers.size(); i++) {
			System.out.println((i + 1) + ". " + Suppliers.get(i).getSupName());
		}

		Product product = new Product(proCode, proMake, proModel, proPrice, proQtyAvailable, proDiscontinued);
		System.out.println("");
		System.out.println("Enter supplier number: ");

		int supNum = sc.nextInt() - 1;
		//gets the supplier with the code entered
		Supplier supplier = Suppliers.get(supNum);
		//adds the product to the chosen supplier
		supplier.getSupProducts().add(product); 

		MainMenu();

	}

	//method producing a product quote
	public static void OrderProduct(Scanner sc, ArrayList<Supplier> Suppliers) {
		System.out.println("----Product quote----");
		double Price = 0;
		System.out.println("Enter the product code: ");
		int proCode = ValidatingInt();
		System.out.println("Enter the supplier code: ");
		int supCode = ValidatingInt();
		//loops though the suppliers array and proceeds iff there exists a supplier with chosen supCode
		for (int i = 0; i < Suppliers.size(); i++) {
			if (supCode == Suppliers.get(i).getSupCode()) {
		//loops though the products array  of the supplier and proceeds iff there exists a supplier with chosen supCode
				for (int x = 0; x < Suppliers.get(i).getSupProducts().size(); x++) {
					if (proCode == Suppliers.get(i).getSupProducts().get(x).getProCode()) {
						System.out.println("Enter the quantity: ");
						int orderQuantity = ValidatingInt();
						//gets quantity available
						int Quantity = Suppliers.get(i).getSupProducts().get(x).getProQtyAvailable();
						//subtracts quantity required by the user from quantity available 
						int updateQuantity = Quantity - orderQuantity;
						//if remaining quantity is less than 0 a message is displayed
						if (updateQuantity < 0) {
							System.out.println("The quantity of product "
									+ Suppliers.get(i).getSupProducts().get(x).getProCode() + " is unavailable");
						}
                        //otherwise the quantity left in stock is shown
						else {
							System.out.println("Quantity left in stock: " + updateQuantity);

						}
						//gets price of the quote by multiplying quantity by the price of the product
						Price = orderQuantity * Suppliers.get(i).getSupProducts().get(x).getProPrice();

					}

				}

			}
		}
		System.out.printf("The total price is: " + "%.2f\n", Price); 
		MainMenu();
	}

	public static void searchProductByPrice(Scanner sc, ArrayList<Supplier> Suppliers) {
		System.out.println("----Searching Product By Price----");
		System.out.println("Please enter the min value of the product:");
		double minValue = ValidatingDouble();
		System.out.println("Please enter the max value of the product:");
		double maxValue = ValidatingDouble();
		//loops through all suppliers
		for (int i = 0; i < Suppliers.size(); i++) {
			//loops through all products
			for (int j = 0; j < Suppliers.get(i).getSupProducts().size(); j++) {
				//gets prices of products
				double value = Suppliers.get(i).getSupProducts().get(j).getProPrice();
				//if the price is within specified range the products are printed
				if ((value >= minValue) && (value <= maxValue)) {
					System.out.println("The products within this price range are: "
							+ Suppliers.get(i).getSupProducts().get(j).getProductDetails());
				}
			}
		}

		MainMenu();
	}

	//deletes a supplier by a supplier code
	public static void deleteSupplier(Scanner sc, ArrayList<Supplier> Suppliers) {
		System.out.println("----Deleting Supplier----");
		System.out.println("Please enter the code of supplier to delete:");
		int searchCode = ValidatingInt();
		//loops through all suppliers
		for (int i = 0; i < Suppliers.size(); i++) {
			//checks if the code entered matches any supplier within suppliers array
			if (searchCode == Suppliers.get(i).getSupCode()) {
				//removes address of the supplier
				Suppliers.remove(i).getSupAddress(); 
			}
         //loops through the product array
			for (int x = 0; x < Suppliers.get(i).getSupProducts().size(); x++) {
				//removes the product array
				Suppliers.get(i).getSupProducts().remove(x);
			}
            //removes the supplier
			Suppliers.remove(i);
		}

		MainMenu();
	}


	public static void editProductDetails(Scanner sc) {
		System.out.println("----Editing Product----");
		System.out.println("Enter the code of product you wish to edit:");
		int searchCode = ValidatingInt();
		System.out.println("Enter the code of the product supplier:");
		int supplierSearchCode = ValidatingInt();
		//loops through the existing supplier 
		for (int i = 0; i < Suppliers.size(); i++) {
			//if the supplier exists
			if (supplierSearchCode == Suppliers.get(i).getSupCode())
				//loops through the product array
				for (int x = 0; x < Suppliers.get(i).getSupProducts().size(); x++) {
                  //checks if product exists within selected supplier
					if (searchCode == Suppliers.get(i).getSupProducts().get(x).getProCode()) {
						System.out.println(Suppliers.get(i).getSupProducts().get(x).getProductDetails());
						System.out.println("");
						System.out.println("Enter the number of detail to edit: " + "\n 1.Make" + "\n 2.Model"
								+ "\n 3.Price" + "\n 4.Quantity available" + "\n 5.Discontinued");
						int editNo = ValidatingInt();
						//runs appropriate method based on the user input
						switch (editNo) {
						case 1:
							String proMake = EditMake();
							Suppliers.get(i).getSupProducts().get(x).setProMake(proMake);
							break;
						case 2:
							String proModel = EditModel();
							Suppliers.get(i).getSupProducts().get(x).setProModel(proModel);
							break;
						case 3:
							double proPrice = EditPrice();
							Suppliers.get(i).getSupProducts().get(x).setProPrice(proPrice);
							break;
						case 4:
							int proQuantity = EditQuantity();
							Suppliers.get(i).getSupProducts().get(x).setProQtyAvailable(proQuantity);
							break;
						case 5:
							boolean proDiscontinued = EditDiscontinued();
							Suppliers.get(i).getSupProducts().get(x).setProDiscontinued(proDiscontinued);
							break;
						default:
							System.out.println("Error. You must select an option within specified range.");
							System.out.println();
							editProductDetails(sc);

						}
					}
				}
		}
		MainMenu();
	}
	
   //methods which take the user input and returns the values to variables in edit method.
	public static String EditMake() {

		System.out.println("Enter new make:");
		String proMake = sc.nextLine();
		return proMake;

	}

	public static String EditModel() {
		System.out.println("Enter new model:");
		String proModel = sc.nextLine();
		return proModel;
	}

	public static double EditPrice() {
		System.out.println("Enter new price:");
		Double proPrice = ValidatingDouble();

		return proPrice;
	}

	public static int EditQuantity() {

		System.out.println("Enter new quantity available:");
		int proQtyAvailable = ValidatingQuantity();
		return proQtyAvailable;
	}

	public static boolean EditDiscontinued() {
		System.out.println("Update whether the product is discontinued by typing 'y' for yes and 'n' for no:");
		char input = sc.next().charAt(0);
		boolean proDiscontinued = false;
		if (input == 'y') {
			proDiscontinued = true;
		}
		return proDiscontinued;

	}

}
