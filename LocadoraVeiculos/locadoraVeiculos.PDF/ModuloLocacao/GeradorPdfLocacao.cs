using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System.IO;

namespace locadoraVeiculos.PDF.ModuloLocacao
{
    public class GeradorPdfLocacao : IGeradorPdfLocacao
    {
        public void GerarPdf(Locacao comprovante)
        {
            Document document = new Document(PageSize.A4, 20f, 20f, 30f, 30f);

            FileStream fileStream = new FileStream(@"C:\temp\" + $"{comprovante.Id}.pdf", FileMode.Create);

            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular));
            Paragraph paragrafo2 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular));


            paragrafo.Alignment = Element.ALIGN_LEFT;
            paragrafo2.Alignment = Element.ALIGN_CENTER;

            paragrafo2.Add("Comprovante de locação" + "\n\n");
            paragrafo.Add("------------------------------------------------------------------" + "\n\n");
            paragrafo.Add("Id da locação: " + comprovante.Id + "\n");
            paragrafo.Add("Nome do Cliente: " + comprovante.Cliente.Nome + "\n");
            paragrafo.Add("Grupo de veículos: " + comprovante.GrupoVeiculos.Nome + "\n");
            paragrafo.Add("Placa do veículo: " + comprovante.Veiculo.Placa + "\n");
            paragrafo.Add("Plano de cobrança: " + comprovante.PlanosCobranca.ToString() + "\n");
            paragrafo.Add("Data de locação: " + comprovante.DataLocacao.ToShortDateString() + "\n");
            paragrafo.Add("Data de devolução prevista: " + comprovante.DataPrevistaEntrega.ToShortDateString() + "\n");
            paragrafo.Add("Quilometragem atual percorrida pelo veículo: " + comprovante.Veiculo.QuilometragemPercorrida + " Km" + "\n");
            paragrafo.Add("Taxas adicionadas: " + "\n");
            for (int i = 1; i <= comprovante.Taxas.Count; i++)
            {

                paragrafo.Add("Taxa" + i + ": " + comprovante.Taxas[i].Descricao + "\n");

            }

            paragrafo.Add("Valor total previsto: " + "R$" + comprovante.ValorPrevisto + "\n");

            document.Open();
            document.Add(paragrafo2);
            document.Add(paragrafo);
            document.Close();
        }
    }
}
