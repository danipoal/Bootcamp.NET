package ilerna.checkpacdespliegue;

public class CheckPacDespliegue {
   static void pruebaDesencriptar() throws Exception {
      String texto = "/LRfh+THA8WlTv1QSc6RwqUFEbyt7YiSYX3U2zf/hLjtUJpRuxpDJRxDKChSa5nLHqCWHaXLBNab8cREaO3amuJjuep6EywYIu8mmFw4Ipulf1RL/Elv7IxZMUB6WhlPezxli7MYHLpH8fiqzv8xnT0eiFef+8TnB1zqXoZl5Gv0IWaqqOD3buuw6POTAuXbMM1ksHlhgntIzPzv+W02uZsXii9ViaYvcUcDdHJpHbUbfFVxvGcgy2OjZPFcPIpgKUdiMTv7CueiQ4A3BggyVhI7rSZluGcvduYmxPTdesbyECn7uioxWVjO5ysRNHw1hLQ1NqyNAplGM1cSCnvDqYB0YwVfCbwG2ByAjXLxvovtwMzBUQmHOkcoACtUx9S5t7stwnx+nB+asDkzE2t5e5sDWo/+mjKusRZ6X2fH4yR3pEMCEFoKy8N0OZZ6CyTC8gQPm+BwJUBLwBHVcdYjhJkfDIDJLn3Nfnc6zfeEnOTKYoG7LqTzcYLzTqPvdfjv";
      String textoDecrypt = EncryptionUtil.decrypt(texto);
      System.out.println(textoDecrypt);
   }

   static void pruebaVerificarLog() throws Exception {
      String texto = "/LRfh+THA8WlTv1QSc6RwqUFEbyt7YiSYX3U2zf/hLjtUJpRuxpDJRxDKChSa5nLHqCWHaXLBNab8cREaO3amuJjuep6EywYIu8mmFw4Ipulf1RL/Elv7IxZMUB6WhlPezxli7MYHLpH8fiqzv8xnT0eiFef+8TnB1zqXoZl5Gv0IWaqqOD3buuw6POTAuXbMM1ksHlhgntIzPzv+W02uZsXii9ViaYvcUcDdHJpHbUbfFVxvGcgy2OjZPFcPIpgKUdiMTv7CueiQ4A3BggyVhI7rSZluGcvduYmxPTdesbyECn7uioxWVjO5ysRNHw1hLQ1NqyNAplGM1cSCnvDqYB0YwVfCbwG2ByAjXLxvovtwMzBUQmHOkcoACtUx9S5t7stwnx+nB+asDkzE2t5e5sDWo/+mjKusRZ6X2fH4yR3pEMCEFoKy8N0OZZ6CyTC8gQPm+BwJUBLwBHVcdYjhJkfDIDJLn3Nfnc6zfeEnOTKYoG7LqTzcYLzTqPvdfjv";
      String textoDecrypt = EncryptionUtil.decrypt(texto);
      System.out.println(textoDecrypt);
      LogChecker checker = new LogChecker(texto);
      if (checker.verificarLog()) {
         System.out.println("El log es correcto");
      } else {
         System.out.println("El log no es correcto");
      }

   }
}
