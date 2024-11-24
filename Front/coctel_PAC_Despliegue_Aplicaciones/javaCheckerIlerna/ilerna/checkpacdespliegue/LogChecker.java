package ilerna.checkpacdespliegue;

public class LogChecker {
   private final String textoCifrado;

   public LogChecker(String textoCifrado) {
      this.textoCifrado = textoCifrado;
   }

   public String getTextoDescifrado() throws Exception {
      return EncryptionUtil.decrypt(this.textoCifrado);
   }

   private boolean verificarPrimeraLínea() throws Exception {
      String[] lineas = this.getTextoDescifrado().split("\n");
      return lineas.length > 0 && lineas[0].trim().equals("========== Nuevo Log ==========");
   }

   private boolean verificarFecha() throws Exception {
      String[] lineas = this.getTextoDescifrado().split("\n");
      if (lineas.length <= 1) {
         return false;
      } else {
         String lineaFecha = lineas[1].trim();
         return lineaFecha.startsWith("Fecha de ejecución: ") && lineaFecha.length() > "Fecha de ejecución: ".length();
      }
   }

   private boolean verificarApache() throws Exception {
      String[] lineas = this.getTextoDescifrado().split("\n");
      if (lineas.length > 2) {
         String lineaServidor = lineas[2].trim();
         return lineaServidor.startsWith("Servidor: Apache Tomcat");
      } else {
         return false;
      }
   }

   private boolean verificarJava() throws Exception {
      String[] lineas = this.getTextoDescifrado().split("\n");
      if (lineas.length <= 3) {
         return false;
      } else {
         String lineaJava = lineas[3].trim();
         return lineaJava.startsWith("Versión de Java: ") && lineaJava.length() > "Versión de Java: ".length();
      }
   }

   private boolean tieneFormulario() throws Exception {
      String[] lineas = this.getTextoDescifrado().split("\n");
      if (lineas.length > 4) {
         String lineaFormulario = lineas[4].trim();
         return lineaFormulario.equals("Formulario: Formulario de Búsqueda de Cócteles");
      } else {
         return false;
      }
   }

   private boolean tieneCoctel() throws Exception {
      String[] lineas = this.getTextoDescifrado().split("\n");
      if (lineas.length <= 5) {
         return false;
      } else {
         String lineaCoctel = lineas[5].trim();
         return lineaCoctel.startsWith("Cóctel elegido: ") && lineaCoctel.length() > "Cóctel elegido: ".length();
      }
   }

   private boolean tieneDescripcion() throws Exception {
      String[] lineas = this.getTextoDescifrado().split("\n");
      if (lineas.length <= 6) {
         return false;
      } else {
         String lineaDescripcion = lineas[6].trim();
         return lineaDescripcion.startsWith("Descripción: ") && lineaDescripcion.length() > "Descripción: ".length();
      }
   }

   private boolean tieneLineaFinal() throws Exception {
      String[] lineas = this.getTextoDescifrado().split("\n");
      return lineas.length > 7 && lineas[7].trim().equals("================================");
   }

   public boolean verificarLog() throws Exception {
      return this.verificarPrimeraLínea() && this.verificarFecha() && this.verificarApache() && this.verificarJava() && this.tieneFormulario() && this.tieneCoctel() && this.tieneDescripcion() && this.tieneLineaFinal();
   }
}
