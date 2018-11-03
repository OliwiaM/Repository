
public class DogTester {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		Dog doggo = new Dog(foodType.CEREAL,30, "Doggo", 3, false);
		doggo.makeNoise();
		doggo.eat();
		doggo.roam();
		System.out.println(doggo.getName() + doggo.sleep(20));
		doggo.beFriendly();
		doggo.play();
		
	}

}
