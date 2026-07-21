 public class SingletonTest {

    public static void main(String[] args) {

        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();

        logger1.log("First Log");
        logger2.log("Second Log");

        if(logger1 == logger2) {
            System.out.println("Only one instance exists");
        }
    }
}