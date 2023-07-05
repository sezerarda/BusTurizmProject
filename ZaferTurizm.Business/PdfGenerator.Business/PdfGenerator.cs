using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.PdfGenerator.Business
{
    public class PdfGenerator
    {
        //public void GenerateTicketPdf(string customerName, string seatNumber, string departure, string arrival, string date, string price)
        //{
        //    // PDF dosyasını oluştur
        //    var pdfPath = "Ticket.pdf";
        //    var writer = new PdfWriter(pdfPath);
        //    var pdf = new PdfDocument(writer);
        //    var document = new Document(pdf);

        //    // Başlık
        //    var title = new Paragraph("Bilet Bilgileri")
        //        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
        //        .SetFontSize(20)
        //        .SetBold();
        //    document.Add(title);

        //    // Bilet bilgileri
        //    var info = new Paragraph($"Yolcu Adı: {customerName}\nKoltuk Numarası: {seatNumber}\nKalkış: {departure}\nVarış: {arrival}\nTarih: {date}\nÜcret: {price}")
        //        .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
        //        .SetFontSize(12);
        //    document.Add(info);

        //    // PDF'i kaydet
        //    document.Close();

        //    Console.WriteLine("PDF oluşturuldu: " + pdfPath);
        //}

        //public byte[] GeneratePdf(TicketDto ticket)
        //{
        //    byte[] pdfBytes;

        //    using (var outputStream = new MemoryStream())
        //    {
        //        var writer = new PdfWriter(outputStream);
        //        var pdf = new PdfDocument(writer);
        //        var document = new Document(pdf);

        //        // PDF içeriğini oluştur
        //        document.Add(new Paragraph("Ticket Details"));
        //        document.Add(new Paragraph($"Ticket Number: {ticket.CustomerIdentityNumber}"));
        //        document.Add(new Paragraph($"Customer Name: {ticket.CustomerName}"));
        //        document.Add(new Paragraph($"Customer Surname: {ticket.CustomerSurname}"));
        //        document.Add(new Paragraph($"Seat Number: {ticket.SeatNumber}"));
        //        document.Add(new Paragraph($"Price: {ticket.Price}"));

        //        // PDF'yi tamamla ve bellek akışını al
        //        document.Close();
        //        pdfBytes = outputStream.ToArray();
        //    }

        //    return pdfBytes;
        //}



       
    }

 
}
