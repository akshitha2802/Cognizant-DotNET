public class BuilderTest {

    public static void main(String[] args) {

        Computer pc = new Computer.Builder()
                .setCpu("Intel i7")
                .setRam(16)
                .setStorage(512)
                .build();

        pc.display();
    }
}