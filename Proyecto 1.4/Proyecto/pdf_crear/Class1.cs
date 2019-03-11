using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace pdf_crear
{
    public class Class1
    {
        public static iTextSharp.text.Image img = Image.GetInstance("tec.jpg");
        public void creado(string nom, string appat, string apmat, string doc, int nocon, string carr, string act, string desem, int valnum, string peresc,int peranio, int valcur, int d, int m, int a)
        {
            //separacion entre a quien esta dirigido y  cuerpo
            string parteespacio2 = "\n \n";
            Paragraph espacio2 = new Paragraph(string.Format(parteespacio2));
            string parteespacio1 = "\n";
            Paragraph espacio1 = new Paragraph(string.Format(parteespacio1));

            //se crea el objeto para hacer el pdf
            Document documento = new Document(PageSize.LETTER);
            FileStream fs = new FileStream("prueba"+nocon.ToString()+".pdf", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            PdfWriter escrito = PdfWriter.GetInstance(documento, fs);
            documento.Open();
            documento.SetMargins(2.2f, 1.6f, 2.54f, 2.54f);
            //imagen inicial
            try
            {
                img.Alignment = Element.ALIGN_CENTER;
                documento.Add(img);
                documento.Add(espacio2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            //encabezado
            string encabezado = "Anexo XVI Constancia de Cumplimiento de Actividad Complementaria";
            Paragraph texto = new Paragraph(string.Format(encabezado), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 15));
            texto.Alignment = Element.ALIGN_CENTER;
            documento.Add(texto);
            documento.Add(espacio2);

            //a quien esta dirigido
            string parte1 = "Lic. Doroteo Luna Castañeda\nJefe de servicios escolares\nPresente";
            Paragraph texto2 = new Paragraph(string.Format(parte1), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD));
            texto2.Alignment = Element.ALIGN_LEFT;
            documento.Add(texto2);
            documento.Add(espacio2);
            //string de los valores dados
            string nombre = nom;
            string apellidopat = appat;
            string apellidomat = apmat;
            string docente = doc;
            string nocontrol = nocon.ToString();
            string carrera = carr;
            string actividad = act;
            string desempenio = desem;
            string valnumerico = valnum.ToString();
            string periodoesc = peresc + " "+ peranio.ToString();
            string valcurricular = valcur.ToString();
            string dia = d.ToString();
            string mes;
            switch (m)
            {
                case 1:
                    mes = "Enero";
                    break;
                case 2:
                    mes = "Febrero";
                    break;
                case 3:
                    mes = "Marzo";
                    break;
                case 4:
                    mes = "Abril";
                    break;
                case 5:
                    mes = "Mayo";
                    break;
                case 6:
                    mes = "Junio";
                    break;
                case 7:
                    mes = "Julio";
                    break;
                case 8:
                    mes = "Agosto";
                    break;
                case 9:
                    mes = "Septiembre";
                    break;
                case 10:
                    mes = "Octubre";
                    break;
                case 11:
                    mes = "Noviembre";
                    break;
                default:
                    mes = "Diciembre";
                    break;

            }
            string anio = a.ToString();
            //string de las lineas predefinidas
            string linea1 = "El (la) que suscribe ";
            string linea2 = " por este medio se permite hacer de su conocimiento que el estudiante ";
            string linea3 = " con número de control ";
            string linea4 = " de la carrera de ";
            string linea5 = " ha cumplido su actividad complementaria de ";
            string linea6 = " con el nivel de desempeño ";
            string linea7 = " y un valor numérico de ";
            string linea8 = " durante el periodo escolar ";
            string linea9 = " con un valor curricular de ";
            string linea10 = " crédito(s).";
            string linea11 = "Se extiende la presente en la ciudad de Tijuana Baja California a los ";
            string linea12 = " días de ";
            string linea13 = " de ";
            //formato de letra para el cuerpo
            iTextSharp.text.Font normal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);
            iTextSharp.text.Font negrita = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            //se crea la frase completa hecha por pedazos de texto
            Phrase frase = new Phrase();
            Chunk c1 = new Chunk(linea1, normal);
            Chunk c2 = new Chunk(docente, negrita);
            Chunk c3 = new Chunk(linea2, normal);
            Chunk c4 = new Chunk(nombre + " " + apellidopat + " " + apellidomat, negrita);
            Chunk c5 = new Chunk(linea3, normal);
            Chunk c6 = new Chunk(nocontrol, negrita);
            Chunk c7 = new Chunk(linea4, normal);
            Chunk c8 = new Chunk(carrera, negrita);
            Chunk c9 = new Chunk(linea5, normal);
            Chunk c10 = new Chunk(actividad, negrita);
            Chunk c11 = new Chunk(linea6, normal);
            Chunk c12 = new Chunk(desempenio, negrita);
            Chunk c13 = new Chunk(linea7, normal);
            Chunk c14 = new Chunk(valnumerico, negrita);
            Chunk c15 = new Chunk(linea8, normal);
            Chunk c16 = new Chunk(periodoesc, negrita);
            Chunk c17 = new Chunk(linea9, normal);
            Chunk c18 = new Chunk(valcurricular, negrita);
            Chunk c19 = new Chunk(linea10, normal);
            
            //se agregan a la frase los pedazos de texto
            frase.Add(c1);
            frase.Add(c2);
            frase.Add(c3);
            frase.Add(c4);
    //        frase.Add(c33);
    //       frase.Add(c34);
            frase.Add(c5);
            frase.Add(c6);
            frase.Add(c7);
            frase.Add(c8);
            frase.Add(c9);
            frase.Add(c10);
            frase.Add(c11);
            frase.Add(c12);
            frase.Add(c13);
            frase.Add(c14);
            frase.Add(c15);
            frase.Add(c16);
            frase.Add(c17);
            frase.Add(c18);
            frase.Add(c19);
            //se crea el parrafo del cuerpo del texto
            Paragraph cuerpo = new Paragraph(frase);
            cuerpo.Alignment = Element.ALIGN_JUSTIFIED;
            documento.Add(cuerpo);
            documento.Add(espacio1);
            //se crea la otra frase
            Phrase frase2 = new Phrase();
            Chunk c20 = new Chunk(linea11, normal);
            Chunk c21 = new Chunk(dia, negrita);
            Chunk c22 = new Chunk(linea12, normal);
            Chunk c23 = new Chunk(mes, negrita);
            Chunk c24 = new Chunk(linea13, normal);
            Chunk c25 = new Chunk(anio, negrita);
            frase2.Add(c20);
            frase2.Add(c21);
            frase2.Add(c22);
            frase2.Add(c23);
            frase2.Add(c24);
            frase2.Add(c25);
            Paragraph fechaexpedicion = new Paragraph(frase2);
            documento.Add(fechaexpedicion);
            documento.Add(espacio2);
            //texto atentamente
            Paragraph atentamente = new Paragraph("ATENTAMENTE", normal);
            atentamente.Alignment = Element.ALIGN_CENTER;
            documento.Add(atentamente);
            documento.Add(espacio2);

            //tabla para las firmas
            PdfPTable tabla = new PdfPTable(2);
            tabla.WidthPercentage = 100f;
            tabla.HorizontalAlignment = Element.ALIGN_CENTER;
            //firma
            PdfPCell cell = new PdfPCell(new Phrase("_______________________________"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = Rectangle.NO_BORDER;
            tabla.AddCell(cell);
            tabla.AddCell(cell);
            //nombre del docente
            PdfPCell cell2 = new PdfPCell(new Phrase(docente));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.Border = Rectangle.NO_BORDER;
            tabla.AddCell(cell2);
            PdfPCell cell3 = new PdfPCell(new Phrase("MA Gabriela Lourdes Tapia González"));
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            cell3.Border = Rectangle.NO_BORDER;
            tabla.AddCell(cell3);
            //cargo
            PdfPCell cell4 = new PdfPCell(new Phrase(""));
            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
            cell4.Border = Rectangle.NO_BORDER;
            tabla.AddCell(cell4);
            PdfPCell cell5 = new PdfPCell(new Phrase("Jefe de depto. de sistemas y computación"));
            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
            cell5.Border = Rectangle.NO_BORDER;
            tabla.AddCell(cell5);
            documento.Add(tabla);
            documento.Add(espacio2);
            documento.Add(espacio2);
            //con copia para
            iTextSharp.text.Font letrapequenia = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);
            Phrase copia = new Phrase();
            Chunk c30 = new Chunk("C.c.p MA Gabriela Lourdes Tapia González", letrapequenia);
            Chunk c31 = new Chunk("Jefe del Departamento de Sistemas y Computación", letrapequenia);
            copia.Add(c30);
            copia.Add("\n");
            copia.Add(c31);
            Paragraph copiafrase = new Paragraph(copia);
            documento.Add(copiafrase);
            documento.Close();

        }
    }
}
