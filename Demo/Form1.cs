namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SendData()
        {
            String s = textBox1.Text;
            String res = Client.Client.Handle(s);
            textBox2.Text = res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           SendData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}