/*
Colegio Técnico Antônio Teixeira Fernandes (Univap)
Curso Técnico em Informática - Data de Entrega: 14 / 09 / 2021
Autores do Projeto: Ricardo Rossato Lataro Rodrigues - 50200259
                    Roberto Gomes Rivoli Junior - 50200119
Turma: 2F
Atividade Projeto PVB 3º Bimestre
Observação: < colocar se houver> 
******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_PVB_3ºBimestre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int parcelas, vezes, diasemana, confirma = 0, controluniv = 1, teste = 0, x = 1;
        double preco, parcelado, novopreco;
        string datatemp, dataparc;
        DateTime exemp;
        DateTime[] arrayparcela = new DateTime[1000];
        DateTime[] parcelaspagas = new DateTime[1000];
        
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
             x += 1;
             for (int i = x; i <= parcelas; i++)
             {
                 textBox4.AppendText("Parcela " + i.ToString() + ": " + (preco / parcelas).ToString("0.00") + "/ Data: " + arrayparcela[i - 1].ToString("dd-MM-yyyy") + Environment.NewLine);
                 
             }
            if(vezes == 0)
            {
                textBox4.AppendText("Você não pode pagar parcelas enquanto não for realizada uma compra !!"+Environment.NewLine);
            }
            else
            {
                dataparc = textBox5.Text;
                int ano = Convert.ToInt32(dataparc.Substring(0, 4));
                int mes = Convert.ToInt32(dataparc.Substring(5, 2));
                int dia = Convert.ToInt32(dataparc.Substring(8, 2));
                DateTime data2 = new DateTime(ano, mes, dia);
                for (int cont3 = 0; cont3 <= parcelas; cont3++)
                {
                    if (data2 == parcelaspagas[cont3])
                    {
                        teste++;
                    }
                }
                if (teste == 0)
                {
                    for (int cont = 0; cont <= parcelas; cont++)
                    {
                        if (data2 == arrayparcela[cont])
                        {
                            textBox4.AppendText("Parcela paga !" + Environment.NewLine);
                            novopreco -= parcelado;
                            label4.Text = "Total: " + novopreco.ToString("0.00");
                            confirma++;
                            controluniv++;
                            
                            parcelaspagas[controluniv] = data2;
                        }
                    }
                    if (confirma == 0)
                    {
                        controluniv++;
                        textBox4.AppendText("Parcela fora da data devida !!" + Environment.NewLine);
                        novopreco -= parcelado + (parcelado * 0.03);
                        label4.Text = "Total: " + novopreco.ToString("0.00");
                        
                        parcelaspagas[controluniv] = data2;
                    }
                    confirma = 0;
                }
                else
                {
                    textBox4.AppendText("Essa parcela já foi paga !!" + Environment.NewLine);
                }
                teste = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vezes += 1;
            datatemp = textBox1.Text;
            int ano = Convert.ToInt32(datatemp.Substring(0, 4));
            int mes = Convert.ToInt32(datatemp.Substring(5, 2));
            int dia = Convert.ToInt32(datatemp.Substring(8, 2));
            DateTime data = new DateTime(ano, mes, dia);
            preco = double.Parse(textBox2.Text);
            parcelas = Convert.ToInt32(textBox3.Text);

            for (int i = 1; i <= parcelas; i++)
            {


                label4.Text = "Total: " + preco.ToString();
                DateTime datadiasuteis = new DateTime(ano, mes, dia);
                DayOfWeek semana = new DayOfWeek();
                semana = datadiasuteis.DayOfWeek;
                for (int cont2 = 0; cont2 <= parcelas; cont2++)
                {
                    for (int cont = 1; cont < 22; cont++)
                    {
                        exemp = datadiasuteis.AddDays(1);
                        diasemana = (int)datadiasuteis.DayOfWeek;
                        while (diasemana == 0 || diasemana == 6)
                        {
                            exemp = datadiasuteis.AddDays(1);
                            diasemana = (int)datadiasuteis.DayOfWeek;
                            datadiasuteis = exemp;
                        }
                        datadiasuteis = exemp;
                    }
                    while (diasemana == 0 || diasemana == 6)
                    {
                        exemp = datadiasuteis.AddDays(1);
                        diasemana = (int)datadiasuteis.DayOfWeek;
                        datadiasuteis = exemp;
                    }
                    arrayparcela[cont2] = exemp;

                }
                textBox4.AppendText("Parcela " + i.ToString() + ": " + (preco / parcelas).ToString("0.00") + "/ Data: " + arrayparcela[controluniv - 1].ToString("dd-MM-yyyy") + Environment.NewLine);
                controluniv++;
            }
                parcelado = (preco / parcelas);
                novopreco = preco;
            
        }
    }
}
