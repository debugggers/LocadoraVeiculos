using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraVeiculos.Dominio.ModuloDevolucao;
using System.IO;

namespace locadoraVeiculos.PDF.ModuloDevolucao
{
    public class GeradorPdfDEvolucao : IGeradorPdfDevolucao
    {
        public void GerarPdf(Devolucao comprovante)
        {

            Document document = new Document(PageSize.A4, 20f, 20f, 30f, 30f);

            FileStream fileStream = new FileStream(@"C:\temp\" + $"{comprovante.Id}.pdf", FileMode.Create);

            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular));
            Paragraph paragrafo2 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular));


            paragrafo.Alignment = Element.ALIGN_LEFT;
            paragrafo2.Alignment = Element.ALIGN_CENTER;

            paragrafo2.Add("Comprovante de devolução" + "\n\n");
            paragrafo.Add("------------------------------------------------------------------" + "\n\n");
            paragrafo.Add("Id da devolução: "  + comprovante.Id + "\n");
            paragrafo.Add("Nome do Cliente: "  + comprovante.Locacao.Cliente.Nome + "\n");
            paragrafo.Add("Grupo de veículos: "  + comprovante.Locacao.GrupoVeiculos.Nome + "\n");
            paragrafo.Add("Placa do veículo: "  + comprovante.Locacao.Veiculo.Placa + "\n");
            paragrafo.Add("Plano de cobrança: "  + comprovante.Locacao.PlanosCobranca.ToString() + "\n");
            paragrafo.Add("Data de locação: "  + comprovante.Locacao.DataLocacao.ToShortDateString() + "\n");
            paragrafo.Add("Data de devolução: "  + comprovante.DataDevolucao.ToShortDateString() + "\n");
            paragrafo.Add("Quilometragem percorrida: "  + (comprovante.QuilometragemVeiculo - comprovante.Locacao.Veiculo.QuilometragemPercorrida) + " Km" + "\n");
            paragrafo.Add("Nivel do tanque: "  + comprovante.NivelDoTanque * 100 + "%" + "\n");
            paragrafo.Add("Taxas adicionadas na devolução: " + "\n");
            int j = 1;
            for (int i = 0; i < comprovante.Taxas.Count; i++)
            {

                paragrafo.Add("Taxa "+ j +": " + comprovante.Taxas[i].Descricao + "\n");
                j++;

            }
            var precoCombustivel = comprovante.CalcularCombustivel();
            var precoTaxas = comprovante.CalcularTaxas();
            paragrafo.Add("Valor total para completar o tanque: " + "R$" + precoCombustivel + "\n");
            paragrafo.Add("Valor total das taxas: " + "R$" + precoTaxas + "\n");
            paragrafo.Add("Valor total: "  + "R$" + comprovante.ValorTotal + "\n");

            document.Open();
            document.Add(paragrafo2);
            document.Add(paragrafo);
            document.Close();
        }
    }
}
