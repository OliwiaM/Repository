
public class HippoTester {

	public HippoTester() {
		// TODO Auto-generated constructor stub
	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		Hippo henry = new Hippo(foodType.GRASSES, 50, "Henry", 2, false );
		henry.eat();
		henry.makeNoise();
		henry.roam();
		System.out.println(henry.getName() + " the hippo" + henry.sleep(10));
	}

}
