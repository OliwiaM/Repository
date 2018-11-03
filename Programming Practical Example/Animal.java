
public abstract class Animal {

	private foodType Food;
	private int hunger;
	private String name;
	private int age;
	private boolean sleepStatus;
	
	public Animal(foodType food, int hunger, String name, int age, boolean sleepStatus) {
		super();
		Food = food;
		this.hunger = hunger;
		this.name = name;
		this.age = age;
		this.sleepStatus = sleepStatus;
	}

	public foodType getFood() {
		return Food;
	}

	public void setFood(foodType food) {
		Food = food;
	}

	public int getHunger() {
		return hunger;
	}

	public void setHunger(int hunger) {
		this.hunger = hunger;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getAge() {
		return age;
	}

	public void setAge(int age) {
		this.age = age;
	}

	public boolean isSleepStatus() {
		return sleepStatus;
	}

	public void setSleepStatus(boolean sleepStatus) {
		this.sleepStatus = sleepStatus;
	}
	
	abstract void makeNoise();
	abstract void eat();
	abstract void roam();
	
	public String sleep(double time) {
		if(this.sleepStatus) {
			this.sleepStatus = !this.sleepStatus;
			return " is sleeping and will be for " + time + " minutes.";
		}
		else {
			return " is already sleeping, please wait until it wakens.";
		}
	}
	
}
