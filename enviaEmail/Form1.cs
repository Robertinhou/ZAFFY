using System.Net;
using System.Net.Mail;
namespace enviaEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply@gmail.com", "Zaffy");
            mail.To.Add(new MailAddress("0001082383@senaimgaluno.com.br", "Matheus"));

            Random r = new Random();


            string codigo = "";

            for (int i = 0; i < 8; i++)
            {


                codigo += r.Next(9).ToString();

            }
            MessageBox.Show(codigo);

            mail.Subject = "Hackearam sua conta do SENAI";
            mail.Body = $"Foi solicitada a mudança de senha para a conta! O seu código é {codigo}";

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {

                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("robertmenezesp9@gmail.com", "");

                try
                {
                    smtp.Send(mail);
                    MessageBox.Show("Enviado!");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Não mandou");
                }

            }




        }

        
    }
}
