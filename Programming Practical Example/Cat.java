
public class Cat extends Feline implements Pet {

	public Cat(foodType food, int hunger, String name, int age, boolean sleepStatus) {
		super(food, hunger, name, age, sleepStatus);
		// TODO Auto-generated constructor stub
	}

	@Override
	void makeNoise() {
		System.out.println("I meowed like a cat.");

	}

	@Override
	void eat() {
		System.out.println("I am a cat and have just eaten my " + getFood() + ".");

	}

	@Override
	void roam() {
		System.out.println("I have just gone for a walk and ignored other felines.");

	}

	@Override
	public void beFriendly() {
		System.out.println("As I am a pet I enjoy time with my family");
		
	}

	@Override
	public void play() {
		System.out.println("As I am a pet I can enjoy playing with the toy mice. ");
		
	}
}
