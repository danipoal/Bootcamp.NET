using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerEjemplo
{
    public partial class SiteMaster : MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty((string)Session["user"]))
            {
                Button logIn = new Button();
                logIn.ID = "Button1";
                logIn.CssClass = "btn btn-primary";
                logIn.Text = "Iniciar Sesión";

                logIn.Click += new EventHandler(Button1_Click);
                logDiv.Controls.Add(logIn);

            }
            else
            {
                // Agrega un párrafo con información de la sesión
                Literal literal = new Literal();
                
                literal.Text = $"<p class='text-light'>{Session["user"]}</p>";
                logDiv.Controls.Add(literal);

                // Agrega el botón de cerrar sesión
                Button closeSessionButton = new Button();
                closeSessionButton.ID = "closeSession";
                closeSessionButton.CssClass = "btn btn-danger";
                closeSessionButton.Text = "Cerrar sesión";

                closeSessionButton.Click += new EventHandler(CloseSessionButton_Click);
                logDiv.Controls.Add(closeSessionButton);
            }
        }

        private void CloseSessionButton_Click(object sender, EventArgs e)
        {
            Session["user"] = null; // Limpiar la sesión o lo que necesites hacer
            Response.Redirect("Default.aspx"); // Redireccionar si es necesario
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}