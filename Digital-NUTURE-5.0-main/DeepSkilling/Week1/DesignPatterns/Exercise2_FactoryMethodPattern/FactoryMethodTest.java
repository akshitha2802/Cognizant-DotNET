public class FactoryMethodTest {

    public static void main(String[] args) {

        DocumentFactory wordFactory =
                new WordDocumentFactory();

        DocumentFactory pdfFactory =
                new PdfDocumentFactory();

        DocumentFactory excelFactory =
                new ExcelDocumentFactory();

        wordFactory.createDocument().open();
        pdfFactory.createDocument().open();
        excelFactory.createDocument().open();
    }
}