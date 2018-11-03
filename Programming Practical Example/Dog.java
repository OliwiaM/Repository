
public class Dog extends Canine implements Pet {

	public Dog(foodType food, int hunger, String name, int age, boolean sleepStatus) {
		super(food, hunger, name, age, sleepStatus);
		// TODO Auto-generated constructor stub
	}

	@Override
	void makeNoise() {
		System.out.println("I barked like a dog.");

	}

	@Override
	void eat() {
		System.out.println("I am a dog and I have just eaten my " + getFood() + ".");

	}

	@Override
	public void beFriendly() {
		System.out.println("As I am a dog I enjoy spending time with my family.");
		
	}

	@Override
	public void play() {
		System.out.println("As I am a dog I enjoy playing with bones.");
		
	}

}
