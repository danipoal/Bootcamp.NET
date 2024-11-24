package ilerna.checkpacdespliegue;

import ilerna.checkpacdespliegue.PacChecker.1;
import ilerna.checkpacdespliegue.PacChecker.2;
import ilerna.checkpacdespliegue.PacChecker.3;
import java.awt.Component;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.GroupLayout;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;
import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;
import javax.swing.UIManager.LookAndFeelInfo;
import javax.swing.filechooser.FileNameExtensionFilter;

public class PacChecker extends JFrame {
   private File selectedFile;
   private LogChecker checker;
   private JButton btnCargarArchivo;
   private JButton btnValidarArchivo;
   private JFileChooser fileChooser;
   private JScrollPane jScrollPane1;
   private JLabel lblCargarArchivo;
   private JTextArea txtArchivo;

   public PacChecker() {
      this.initComponents();
      this.setLocationRelativeTo((Component)null);
      this.setApplicationIcon();
      this.fileChooser.setFileFilter(new FileNameExtensionFilter("Archivos PAC (*.pac)", new String[]{"pac"}));
   }

   private void setApplicationIcon() {
      URL iconURL = this.getClass().getResource("/assets/pingusIcon.png");
      if (iconURL != null) {
         ImageIcon icon = new ImageIcon(iconURL);
         this.setIconImage(icon.getImage());
      } else {
         System.err.println("Icono 'assets/pingusIcon.png' no encontrado en los recursos");
      }

   }

   private void initComponents() {
      this.fileChooser = new JFileChooser();
      this.lblCargarArchivo = new JLabel();
      this.btnCargarArchivo = new JButton();
      this.jScrollPane1 = new JScrollPane();
      this.txtArchivo = new JTextArea();
      this.btnValidarArchivo = new JButton();
      this.setDefaultCloseOperation(3);
      this.setTitle("Validador de la PAC 1s2425 de Despliegue");
      this.setResizable(false);
      this.lblCargarArchivo.setText("Escoge el Archivo de la PAC:");
      this.btnCargarArchivo.setText("Cargar Archivo");
      this.btnCargarArchivo.addActionListener(new 1(this));
      this.txtArchivo.setEditable(false);
      this.txtArchivo.setColumns(20);
      this.txtArchivo.setRows(5);
      this.jScrollPane1.setViewportView(this.txtArchivo);
      this.btnValidarArchivo.setText("Validar Archivo de la PAC");
      this.btnValidarArchivo.addActionListener(new 2(this));
      GroupLayout layout = new GroupLayout(this.getContentPane());
      this.getContentPane().setLayout(layout);
      layout.setHorizontalGroup(layout.createParallelGroup(Alignment.LEADING).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addComponent(this.jScrollPane1)).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(Alignment.LEADING).addGroup(layout.createSequentialGroup().addGap(344, 344, 344).addComponent(this.btnValidarArchivo)).addGroup(layout.createSequentialGroup().addGap(279, 279, 279).addComponent(this.lblCargarArchivo, -2, 160, -2).addPreferredGap(ComponentPlacement.UNRELATED).addComponent(this.btnCargarArchivo))).addGap(0, 314, 32767))).addContainerGap()));
      layout.setVerticalGroup(layout.createParallelGroup(Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(Alignment.BASELINE).addComponent(this.btnCargarArchivo).addComponent(this.lblCargarArchivo)).addPreferredGap(ComponentPlacement.UNRELATED).addComponent(this.jScrollPane1, -2, 244, -2).addPreferredGap(ComponentPlacement.UNRELATED).addComponent(this.btnValidarArchivo).addContainerGap(16, 32767)));
      this.pack();
   }

   private void btnCargarArchivoActionPerformed(ActionEvent evt) {
      int returnValue = this.fileChooser.showOpenDialog(this);
      if (returnValue == 0) {
         this.selectedFile = this.fileChooser.getSelectedFile();

         try {
            BufferedReader br = new BufferedReader(new InputStreamReader(new FileInputStream(this.selectedFile), "UTF-8"));

            try {
               StringBuilder fileContent = new StringBuilder();

               String line;
               while((line = br.readLine()) != null) {
                  fileContent.append(line);
               }

               String textoCifrado = fileContent.toString();

               try {
                  this.checker = new LogChecker(textoCifrado);
                  String textoDescifrado = this.checker.getTextoDescifrado();
                  this.txtArchivo.setText(textoDescifrado);
               } catch (IllegalArgumentException var9) {
                  JOptionPane.showMessageDialog(this, "El archivo no está en formato Base64 o es inválido", "Error de Formato", 0);
                  this.txtArchivo.setText(fileContent.toString());
               } catch (Exception var10) {
                  JOptionPane.showMessageDialog(this, "Error al descifrar el archivo", "Error de Descifrado", 0);
                  var10.printStackTrace();
               }
            } catch (Throwable var11) {
               try {
                  br.close();
               } catch (Throwable var8) {
                  var11.addSuppressed(var8);
               }

               throw var11;
            }

            br.close();
         } catch (IOException var12) {
            JOptionPane.showMessageDialog(this, "Error al leer el archivo", "Error", 0);
            var12.printStackTrace();
         }
      }

   }

   private void btnValidarArchivoActionPerformed(ActionEvent evt) {
      if (this.selectedFile == null) {
         JOptionPane.showMessageDialog(this, "Por favor, carga un archivo primero.", "Error", 0);
      } else {
         try {
            if (this.checker.verificarLog()) {
               JOptionPane.showMessageDialog(this, "El archivo es válido.", "Validación Exitosa", 1);
            } else {
               JOptionPane.showMessageDialog(this, "El archivo no es válido.", "Error de Validación", 0);
            }
         } catch (Exception var3) {
            JOptionPane.showMessageDialog(this, "El archivo no es válido.", "Error de Validación", 0);
         }

      }
   }

   public static void main(String[] args) {
      try {
         LookAndFeelInfo[] var1 = UIManager.getInstalledLookAndFeels();
         int var2 = var1.length;

         for(int var3 = 0; var3 < var2; ++var3) {
            LookAndFeelInfo info = var1[var3];
            if ("Nimbus".equals(info.getName())) {
               UIManager.setLookAndFeel(info.getClassName());
               break;
            }
         }
      } catch (ClassNotFoundException var5) {
         Logger.getLogger(PacChecker.class.getName()).log(Level.SEVERE, (String)null, var5);
      } catch (InstantiationException var6) {
         Logger.getLogger(PacChecker.class.getName()).log(Level.SEVERE, (String)null, var6);
      } catch (IllegalAccessException var7) {
         Logger.getLogger(PacChecker.class.getName()).log(Level.SEVERE, (String)null, var7);
      } catch (UnsupportedLookAndFeelException var8) {
         Logger.getLogger(PacChecker.class.getName()).log(Level.SEVERE, (String)null, var8);
      }

      EventQueue.invokeLater(new 3());
   }
}
