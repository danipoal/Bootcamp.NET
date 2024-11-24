package ilerna.checkpacdespliegue;

import java.nio.charset.StandardCharsets;
import java.util.Base64;
import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

public class EncryptionUtil {
   private static final String ALGORITHM = "AES";
   private static final String SECRET_KEY = "1234567890123456";

   public static String encrypt(String data) throws Exception {
      SecretKeySpec keySpec = new SecretKeySpec("1234567890123456".getBytes(StandardCharsets.UTF_8), "AES");
      Cipher cipher = Cipher.getInstance("AES");
      cipher.init(1, keySpec);
      byte[] encryptedData = cipher.doFinal(data.getBytes(StandardCharsets.UTF_8));
      return Base64.getEncoder().encodeToString(encryptedData);
   }

   public static String decrypt(String encryptedData) throws Exception {
      SecretKeySpec keySpec = new SecretKeySpec("1234567890123456".getBytes(StandardCharsets.UTF_8), "AES");
      Cipher cipher = Cipher.getInstance("AES");
      cipher.init(2, keySpec);
      byte[] decodedData = Base64.getDecoder().decode(encryptedData);
      byte[] decryptedData = cipher.doFinal(decodedData);
      return new String(decryptedData, StandardCharsets.UTF_8);
   }
}
