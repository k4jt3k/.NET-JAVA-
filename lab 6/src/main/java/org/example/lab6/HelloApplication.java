package org.example.lab6;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.*;
import javafx.stage.Stage;

import java.util.Objects;

public class HelloApplication extends Application {

    //interfejs
    private ImageView originalImageView;
    private ImageView processedImageView;
    private ComboBox<String> operationComboBox;
    private Button btnExecute;
    private Button btnSave;
    private Button btnLoad;
    private Button btnRotateLeft;
    private Button btnRotateRight;
    private static final java.util.logging.Logger LOGGER = java.util.logging.Logger.getLogger(HelloApplication.class.getName());

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Laboratorium 6");
        setupLogger();

        BorderPane root = new BorderPane();
        root.setPadding(new Insets(10));
        HBox header = new HBox(20);
        header.setAlignment(Pos.CENTER);
        Label welcomeLabel = new Label("Edytor obrazów");
        welcomeLabel.setStyle("-fx-font-size: 20px; -fx-font-weight: bold;");

        ImageView logoView = new ImageView();
        try {
            Image logo = new Image(Objects.requireNonNull(getClass().getResourceAsStream("/logo.png")));
            logoView.setImage(logo);
            logoView.setFitHeight(50);
            logoView.setPreserveRatio(true);
        } catch (Exception e) {
            System.out.println("Nie znaleziono logo.png ");
        }
        header.getChildren().addAll(welcomeLabel, logoView);
        root.setTop(header);

        //Podglad
        HBox imagesBox = new HBox(20);
        imagesBox.setAlignment(Pos.CENTER);
        imagesBox.setPadding(new Insets(20));

        originalImageView = new ImageView();
        originalImageView.setFitWidth(300);
        originalImageView.setFitHeight(300);
        originalImageView.setPreserveRatio(true);
        originalImageView.setStyle("-fx-border-color: black;");

        processedImageView = new ImageView();
        processedImageView.setFitWidth(300);
        processedImageView.setFitHeight(300);
        processedImageView.setPreserveRatio(true);

        imagesBox.getChildren().addAll(
                new VBox(5, new Label("Oryginał:"), originalImageView),
                new VBox(5, new Label("Po zmianach:"), processedImageView)
        );
        root.setCenter(imagesBox);

        //stopka
        VBox bottomArea = new VBox(15);
        bottomArea.setAlignment(Pos.CENTER);

        HBox controls = new HBox(15);
        controls.setAlignment(Pos.CENTER);

        btnLoad = new Button("Wczytaj plik");
        btnSave = new Button("Zapisz plik");
        btnSave.setDisable(true);

        btnRotateLeft = new Button("Lewo");
        btnRotateRight = new Button("Prawo");
        btnRotateLeft.setDisable(true);
        btnRotateRight.setDisable(true);
        btnRotateLeft.setDisable(false);
        btnRotateRight.setDisable(false);

        btnRotateLeft.setOnAction(e -> applyRotation(false));
        btnRotateRight.setOnAction(e -> applyRotation(true));

        operationComboBox = new ComboBox<>();
        operationComboBox.getItems().addAll("Skalowanie", "Negatyw", "Progowanie", "Konturowanie");
        operationComboBox.setPromptText("Wybierz operację...");

        btnExecute = new Button("Wykonaj");
        btnExecute.setDisable(true);

        btnLoad.setOnAction(e -> loadImage(primaryStage));
        btnSave.setOnAction(e -> openSaveDialog(primaryStage));

        btnExecute.setOnAction(e -> {
            String selectedOperation = operationComboBox.getValue();
            if (selectedOperation == null) {
                showToast("Nie wybrano operacji do wykonania", Alert.AlertType.WARNING);
                return;
            }
            try {
                switch (selectedOperation) {
                    case "Negatyw": applyNegative(); break;
                    case "Skalowanie": openScaleDialog(primaryStage); break;
                    case "Progowanie": openThresholdDialog(primaryStage); break;
                    case "Konturowanie": applyContouring(); break;
                }
            } catch (Exception ex) {
                showToast("Błąd wykonania operacji", Alert.AlertType.ERROR);
            }
        });

        controls.getChildren().addAll(btnLoad, btnRotateLeft, btnRotateRight, operationComboBox, btnExecute, btnSave);

        Label footerLabel = new Label("Kajetan Spychała 281423");

        bottomArea.getChildren().addAll(controls, footerLabel);
        root.setBottom(bottomArea);

        //uruchomienie okna
        Scene scene = new Scene(root, 800, 600);
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    public static void main(String[] args) {
        launch();
    }

    private void showToast(String message, Alert.AlertType type) {
        if (type == Alert.AlertType.ERROR) {
            LOGGER.severe("BŁĄD: " + message);
        } else if (type == Alert.AlertType.WARNING) {
            LOGGER.warning("OSTRZEŻENIE: " + message);
        } else {
            LOGGER.info("AKCJA: " + message);
        }

        Alert alert = new Alert(type);
        alert.setTitle("Powiadomienie");
        alert.setHeaderText(null);
        alert.setContentText(message);
        alert.showAndWait();
    }
    //wczytywanie pliku
    private void loadImage(Stage stage) {
        javafx.stage.FileChooser fileChooser = new javafx.stage.FileChooser();
        fileChooser.setTitle("Wybierz plik obrazka");

        //tylko jpg
        fileChooser.getExtensionFilters().add(
                new javafx.stage.FileChooser.ExtensionFilter("Obrazy JPG (*.jpg)", "*.jpg", "*.jpeg")
        );

        java.io.File file = fileChooser.showOpenDialog(stage);

        if (file != null) {
            try {
                //wczytanie obrazu
                Image image = new Image(file.toURI().toString());
                originalImageView.setImage(image);

                processedImageView.setImage(null);

                btnExecute.setDisable(false);
                btnSave.setDisable(false);

                showToast("Pomyślnie załadowano plik", Alert.AlertType.INFORMATION);
            } catch (Exception e) {
                showToast("Nie udało się załadować pliku", Alert.AlertType.ERROR);
            }
        }
    }

    //Zapisywanie
    private void openSaveDialog(Stage parentStage) {
        Stage modalStage = new Stage();
        modalStage.initOwner(parentStage);
        modalStage.initModality(javafx.stage.Modality.APPLICATION_MODAL);
        modalStage.setTitle("Zapisz plik");

        VBox vbox = new VBox(10);
        vbox.setPadding(new Insets(20));
        vbox.setAlignment(Pos.CENTER);

        if (processedImageView.getImage() == null) {
            Label warningLabel = new Label("Na pliku nie zostały wykonane żadne operacje!");
            warningLabel.setStyle("-fx-text-fill: orange; -fx-font-weight: bold;");
            vbox.getChildren().add(warningLabel);
        }

        TextField nameInput = new TextField();
        nameInput.setPromptText("Podaj nazwę pliku...");

        nameInput.textProperty().addListener((observable, oldValue, newValue) -> {
            if (newValue.length() > 100) nameInput.setText(oldValue);
        });

        Label errorLabel = new Label();
        errorLabel.setStyle("-fx-text-fill: red;");

        HBox btnBox = new HBox(10);
        btnBox.setAlignment(Pos.CENTER);
        Button confirmBtn = new Button("Zapisz");
        Button cancelBtn = new Button("Anuluj");
        cancelBtn.setOnAction(e -> modalStage.close());

        //zapisz
        confirmBtn.setOnAction(e -> {
            String fileName = nameInput.getText();

            if (fileName == null || fileName.length() < 3) {
                errorLabel.setText("Wpisz co najmniej 3 znaki");
                return;
            }

            String userHome = System.getProperty("user.home");
            java.io.File picturesDir = new java.io.File(userHome, "Pictures");
            if (!picturesDir.exists()) picturesDir.mkdirs();

            java.io.File fileToSave = new java.io.File(picturesDir, fileName + ".jpg");

            //jesli plik juz isteniej
            if (fileToSave.exists()) {
                showToast("Plik " + fileName + ".jpg już istnieje w systemie. Podaj inną nazwę pliku!", Alert.AlertType.ERROR);
                return;
            }

            //zapis pliku
            try {
                Image imageToSave = processedImageView.getImage() != null ? processedImageView.getImage() : originalImageView.getImage();

                //konwersja na jpg
                java.awt.image.BufferedImage bImage = javafx.embed.swing.SwingFXUtils.fromFXImage(imageToSave, null);
                java.awt.image.BufferedImage rgbImage = new java.awt.image.BufferedImage(bImage.getWidth(), bImage.getHeight(), java.awt.image.BufferedImage.TYPE_INT_RGB);
                java.awt.Graphics2D g = rgbImage.createGraphics();
                g.drawImage(bImage, 0, 0, null);
                g.dispose();

                //zapis
                javax.imageio.ImageIO.write(rgbImage, "jpg", fileToSave);

                showToast("Zapisano obraz w pliku " + fileName + ".jpg", Alert.AlertType.INFORMATION);
                modalStage.close();
            } catch (Exception ex) {
                showToast("Nie udało się zapisać pliku " + fileName + ".jpg", Alert.AlertType.ERROR);
            }
        });

        btnBox.getChildren().addAll(confirmBtn, cancelBtn);
        vbox.getChildren().addAll(new Label("Nazwa pliku:"), nameInput, errorLabel, btnBox);

        Scene scene = new Scene(vbox, 350, 200);
        modalStage.setScene(scene);
        modalStage.show();
    }

    //negatyw
    private void applyNegative() {
        Image sourceImage = processedImageView.getImage() != null ? processedImageView.getImage() : originalImageView.getImage();
        if (sourceImage == null) return;

        int width = (int) sourceImage.getWidth();
        int height = (int) sourceImage.getHeight();
        javafx.scene.image.WritableImage wImage = new javafx.scene.image.WritableImage(width, height);
        javafx.scene.image.PixelReader pr = sourceImage.getPixelReader();
        javafx.scene.image.PixelWriter pw = wImage.getPixelWriter();

        new Thread(() -> {
            int numThreads = 4; //watki
            java.util.concurrent.ExecutorService executor = java.util.concurrent.Executors.newFixedThreadPool(numThreads);

            for (int i = 0; i < numThreads; i++) {
                final int startY = i * (height / numThreads);
                final int endY = (i == numThreads - 1) ? height : (i + 1) * (height / numThreads);

                executor.submit(() -> {
                    for (int y = startY; y < endY; y++) {
                        for (int x = 0; x < width; x++) {
                            javafx.scene.paint.Color color = pr.getColor(x, y);
                            javafx.scene.paint.Color negative = new javafx.scene.paint.Color(
                                    1.0 - color.getRed(), 1.0 - color.getGreen(), 1.0 - color.getBlue(), color.getOpacity());
                            pw.setColor(x, y, negative);
                        }
                    }
                });
            }

            executor.shutdown();
            try { executor.awaitTermination(1, java.util.concurrent.TimeUnit.MINUTES); } catch (Exception ignored) {}

            javafx.application.Platform.runLater(() -> {
                processedImageView.setImage(wImage);
                showToast("Negatyw został wygenerowany pomyślnie!", Alert.AlertType.INFORMATION);
            });
        }).start();
    }

    //skalowanie
    private void openScaleDialog(Stage parentStage) {
        Stage modalStage = new Stage();
        modalStage.initOwner(parentStage);
        modalStage.initModality(javafx.stage.Modality.APPLICATION_MODAL);
        modalStage.setTitle("Skalowanie obrazu");

        VBox vbox = new VBox(10);
        vbox.setPadding(new Insets(20));
        vbox.setAlignment(Pos.CENTER);

        TextField widthInput = new TextField();
        widthInput.setPromptText("Szerokość (0-3000)");

        TextField heightInput = new TextField();
        heightInput.setPromptText("Wysokość (0-3000)");

        Label errorLabel = new Label();
        errorLabel.setStyle("-fx-text-fill: red;");

        Button confirmBtn = new Button("Zmień rozmiar");
        Button cancelBtn = new Button("Anuluj");
        Button restoreBtn = new Button("Przywróć oryginał");

        cancelBtn.setOnAction(e -> modalStage.close());

        //przywracanie oryginalu
        restoreBtn.setOnAction(e -> {
            if (originalImageView.getImage() != null) {
                processedImageView.setImage(originalImageView.getImage());
                showToast("Przywrócono oryginalny obraz", Alert.AlertType.INFORMATION);
                modalStage.close();
            }
        });

        //zmiana rozmiaru
        confirmBtn.setOnAction(e -> {
            String wText = widthInput.getText();
            String hText = heightInput.getText();

            if (wText.isEmpty() || hText.isEmpty()) {
                errorLabel.setText("Pole jest wymagane");
                return;
            }

            try {
                int w = Integer.parseInt(wText);
                int h = Integer.parseInt(hText);

                if (w < 0 || w > 3000 || h < 0 || h > 3000) {
                    errorLabel.setText("Wartości muszą być z zakresu 0-3000");
                    return;
                }

                Image sourceImage = processedImageView.getImage() != null ? processedImageView.getImage() : originalImageView.getImage();
                if (sourceImage == null) return;

                //renderowanie obrazu jako widok o nowych wymiarach
                ImageView tempView = new ImageView(sourceImage);
                tempView.setFitWidth(w);
                tempView.setFitHeight(h);
                tempView.setPreserveRatio(false);

                javafx.scene.SnapshotParameters params = new javafx.scene.SnapshotParameters();
                params.setFill(javafx.scene.paint.Color.TRANSPARENT);
                Image scaledImage = tempView.snapshot(params, null);

                processedImageView.setImage(scaledImage);
                showToast("Obraz został przeskalowany pomyślnie!", Alert.AlertType.INFORMATION);
                modalStage.close();

            } catch (NumberFormatException ex) {
                errorLabel.setText("Wpisz poprawne liczby całkowite!");
            }
        });

        HBox btnBox = new HBox(10, confirmBtn, restoreBtn, cancelBtn);
        btnBox.setAlignment(Pos.CENTER);

        vbox.getChildren().addAll(
                new Label("Nowa szerokość w pikselach:"), widthInput,
                new Label("Nowa wysokość w pikselach:"), heightInput,
                errorLabel, btnBox
        );

        Scene scene = new Scene(vbox, 400, 250);
        modalStage.setScene(scene);
        modalStage.show();
    }

    //obrot
    private void applyRotation(boolean right) {
        Image sourceImage = processedImageView.getImage() != null ? processedImageView.getImage() : originalImageView.getImage();
        if (sourceImage == null) return;

        int width = (int) sourceImage.getWidth();
        int height = (int) sourceImage.getHeight();

        javafx.scene.image.WritableImage wImage = new javafx.scene.image.WritableImage(height, width);
        javafx.scene.image.PixelReader pr = sourceImage.getPixelReader();
        javafx.scene.image.PixelWriter pw = wImage.getPixelWriter();

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                javafx.scene.paint.Color color = pr.getColor(x, y);
                if (right) {
                    pw.setColor(height - 1 - y, x, color); //w prawo
                } else {
                    pw.setColor(y, width - 1 - x, color); //w lewo
                }
            }
        }
        processedImageView.setImage(wImage);
        showToast("Obraz obrócony pomyślnie!", Alert.AlertType.INFORMATION);
    }

    //progowanie
    private void openThresholdDialog(Stage parentStage) {
        Stage modalStage = new Stage();
        modalStage.initOwner(parentStage);
        modalStage.initModality(javafx.stage.Modality.APPLICATION_MODAL);
        modalStage.setTitle("Progowanie obrazu");

        VBox vbox = new VBox(10);
        vbox.setPadding(new Insets(20));
        vbox.setAlignment(Pos.CENTER);

        TextField thresholdInput = new TextField();
        thresholdInput.setPromptText("Próg (0-255)");

        Label errorLabel = new Label();
        errorLabel.setStyle("-fx-text-fill: red;");

        Button confirmBtn = new Button("Wykonaj progowanie");
        Button cancelBtn = new Button("Anuluj");

        cancelBtn.setOnAction(e -> modalStage.close());

        confirmBtn.setOnAction(e -> {
            try {
                int threshold = Integer.parseInt(thresholdInput.getText());
                if (threshold < 0 || threshold > 255) {
                    errorLabel.setText("Próg musi być z zakresu 0-255");
                    return;
                }

                Image sourceImage = processedImageView.getImage() != null ? processedImageView.getImage() : originalImageView.getImage();
                if (sourceImage == null) return;

                int width = (int) sourceImage.getWidth();
                int height = (int) sourceImage.getHeight();
                javafx.scene.image.WritableImage wImage = new javafx.scene.image.WritableImage(width, height);
                javafx.scene.image.PixelReader pr = sourceImage.getPixelReader();
                javafx.scene.image.PixelWriter pw = wImage.getPixelWriter();

                //wielowatkowosc
                new Thread(() -> {
                    int numThreads = 4;
                    java.util.concurrent.ExecutorService executor = java.util.concurrent.Executors.newFixedThreadPool(numThreads);

                    for (int i = 0; i < numThreads; i++) {
                        final int startY = i * (height / numThreads);
                        final int endY = (i == numThreads - 1) ? height : (i + 1) * (height / numThreads);

                        executor.submit(() -> {
                            for (int y = startY; y < endY; y++) {
                                for (int x = 0; x < width; x++) {
                                    javafx.scene.paint.Color c = pr.getColor(x, y);
                                    double brightness = c.getBrightness() * 255.0;
                                    pw.setColor(x, y, brightness >= threshold ? javafx.scene.paint.Color.WHITE : javafx.scene.paint.Color.BLACK);
                                }
                            }
                        });
                    }

                    executor.shutdown();
                    try { executor.awaitTermination(1, java.util.concurrent.TimeUnit.MINUTES); } catch (Exception ignored) {}

                    javafx.application.Platform.runLater(() -> {
                        processedImageView.setImage(wImage);
                        showToast("Progowanie zostało przeprowadzone pomyślnie!", Alert.AlertType.INFORMATION);
                    });
                }).start();

                modalStage.close();

            } catch (Exception ex) {
                errorLabel.setText("Wpisz poprawną liczbę!");
            }
        });

        HBox btnBox = new HBox(10, confirmBtn, cancelBtn);
        btnBox.setAlignment(Pos.CENTER);
        vbox.getChildren().addAll(new Label("Podaj próg (0-255):"), thresholdInput, errorLabel, btnBox);

        modalStage.setScene(new Scene(vbox, 300, 150));
        modalStage.show();
    }

    //konturowanie
    private void applyContouring() {
        Image sourceImage = processedImageView.getImage() != null ? processedImageView.getImage() : originalImageView.getImage();
        if (sourceImage == null) return;

        int width = (int) sourceImage.getWidth();
        int height = (int) sourceImage.getHeight();
        javafx.scene.image.WritableImage wImage = new javafx.scene.image.WritableImage(width, height);
        javafx.scene.image.PixelReader pr = sourceImage.getPixelReader();
        javafx.scene.image.PixelWriter pw = wImage.getPixelWriter();

        new Thread(() -> {
            int numThreads = 4;
            java.util.concurrent.ExecutorService executor = java.util.concurrent.Executors.newFixedThreadPool(numThreads);

            for (int i = 0; i < numThreads; i++) {
                final int startY = i * ((height - 1) / numThreads);
                final int endY = (i == numThreads - 1) ? height - 1 : (i + 1) * ((height - 1) / numThreads);

                executor.submit(() -> {
                    for (int y = startY; y < endY; y++) {
                        for (int x = 0; x < width - 1; x++) {
                            double currentBright = pr.getColor(x, y).getBrightness();
                            double rightBright = pr.getColor(x + 1, y).getBrightness();
                            double bottomBright = pr.getColor(x, y + 1).getBrightness();

                            double difference = Math.abs(currentBright - rightBright) + Math.abs(currentBright - bottomBright);
                            pw.setColor(x, y, difference > 0.15 ? javafx.scene.paint.Color.BLACK : javafx.scene.paint.Color.WHITE);
                        }
                    }
                });
            }

            executor.shutdown();
            try { executor.awaitTermination(1, java.util.concurrent.TimeUnit.MINUTES); } catch (Exception ignored) {}

            javafx.application.Platform.runLater(() -> {
                processedImageView.setImage(wImage);
                showToast("Konturowanie zostało przeprowadzone pomyślnie!", Alert.AlertType.INFORMATION);
            });
        }).start();
    }

    //logi
    private void setupLogger() {
        try {
            java.util.logging.FileHandler fileHandler = new java.util.logging.FileHandler("app_logs.txt", true);
            fileHandler.setFormatter(new java.util.logging.SimpleFormatter()); //data i czas
            LOGGER.addHandler(fileHandler);
            LOGGER.setUseParentHandlers(false);

            LOGGER.info("URUCHOMIENIE APLIKACJI");
        } catch (Exception e) {
            System.out.println("Nie udało się utworzyć pliku logów.");
        }
    }

    @Override
    public void stop() {
        LOGGER.info("ZAMKNIĘCIE APLIKACJI");
    }

}
