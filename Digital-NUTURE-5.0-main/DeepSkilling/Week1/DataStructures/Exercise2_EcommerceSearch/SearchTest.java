import java.util.Arrays;
import java.util.Comparator;

public class SearchTest {

    public static Product linearSearch(Product[] products, String name) {

        for(Product product : products) {
            if(product.productName.equalsIgnoreCase(name)) {
                return product;
            }
        }

        return null;
    }

    public static Product binarySearch(Product[] products, String name) {

        int left = 0;
        int right = products.length - 1;

        while(left <= right) {

            int mid = (left + right) / 2;

            int compare =
                    products[mid].productName.compareToIgnoreCase(name);

            if(compare == 0)
                return products[mid];

            if(compare < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    public static void main(String[] args) {

        Product[] products = {
                new Product(1,"Laptop","Electronics"),
                new Product(2,"Phone","Electronics"),
                new Product(3,"Shoes","Fashion"),
                new Product(4,"Watch","Accessories")
        };

        Product linearResult =
                linearSearch(products,"Shoes");

        System.out.println("Linear Search:");
        System.out.println(linearResult.productName);

        Arrays.sort(products,
                Comparator.comparing(p -> p.productName));

        Product binaryResult =
                binarySearch(products,"Shoes");

        System.out.println("Binary Search:");
        System.out.println(binaryResult.productName);
    }
}