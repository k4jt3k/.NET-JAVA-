module org.example.lab6 {
    requires javafx.controls;
    requires javafx.fxml;
    requires javafx.swing;
    requires java.desktop;
    requires java.logging;

    opens org.example.lab6 to javafx.fxml;
    exports org.example.lab6;
}