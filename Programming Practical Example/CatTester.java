
public class CatTester {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		Cat kitty = new Cat(foodType.MEAT, 2, "Kitty", 3, true);
		kitty.eat();
		kitty.makeNoise();
		kitty.roam();
		System.out.println(kitty.getName() + kitty.sleep(20));
		kitty.beFriendly();
		kitty.play();
	}

}
