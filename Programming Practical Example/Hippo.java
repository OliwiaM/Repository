
public class Hippo extends Animal {

	public Hippo(foodType food, int hunger, String name, int age, boolean sleepStatus) {
		super(food, hunger, name, age, sleepStatus);
		// TODO Auto-generated constructor stub
	}

	@Override
	void makeNoise() {
		System.out.println("I talked like a hippo.");

	}

	@Override
	void eat() {
		System.out.println("I am a hippo and have just eaten my " + getFood() + ".");

	}

	@Override
	void roam() {
		System.out.println("I lazed about in my mud bath and didn't walk much today.");

	}

}
