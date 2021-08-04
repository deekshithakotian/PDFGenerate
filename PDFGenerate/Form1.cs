using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment;

namespace PDFGenerate
{
    public partial class Form1 : Form
    {
        private Button btnCreate;
        private Label label;
        List<String> tableHeader = new List<String>();
        List<String> HSNHeader = new List<String>();
        //List<String> tableHeader = new List<String>;
        DataTable productInfo;
        string organization_name = "MMPs Dry Fruit Shoppe";
        string phone = "98856567890";
        string gstin = "29AADCB2230M1ZP";
        string party_name = "Walkin";
        string add_line1 = "Mangalore";
        string add_line2 = "Karnataka";
        string city = "Belman";
        string reference = "DKD/21/002";
        string Date = "04-Aug-2021";
        string payment = "Paid";
        string place_of_supply = "Karnataka";
        string pin_number = "573456";

        string shop_address = "Shop No.6,PVS Centernary Building,Kodailbail,Mangaluru-575003";


        public Form1()
        {
            InitializeComponent();
            btnCreate = new Button();
            label = new Label();

            //Label
            label.Location = new System.Drawing.Point(0, 40);
            label.Size = new System.Drawing.Size(426, 35);
            label.Text = "Click the button to generate PDF file by Essential PDF";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //Button
            btnCreate.Location = new System.Drawing.Point(180, 110);
            btnCreate.Size = new System.Drawing.Size(85, 26);
            btnCreate.Text = "Create PDF";
            btnCreate.Click += new EventHandler(btnCreate_Click);

            //Create PDF
            ClientSize = new System.Drawing.Size(450, 150);
            Controls.Add(label);
            Controls.Add(btnCreate);
            Text = "Create PDF";
        }



        private void btnCreate_Click(object sender, EventArgs e)
        {


            DrawTable();



        }

        private void PdfGrid_BeginCellLayout(object sender, PdfGridBeginCellLayoutEventArgs args)
        {
            //Set the font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Courier, 12, PdfFontStyle.Bold);

            //Change the column font size 
            if (args.CellIndex == 0)
            {
                args.Style.Font = font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createtableHeader();
            LoadtableData();
        }

        public void createtableHeader()
        {
            tableHeader.Add("Product");
            tableHeader.Add("Quantity");
            tableHeader.Add("MRP");
            tableHeader.Add("Total");

            HSNHeader.Add("Rate");
            HSNHeader.Add("Value");
            HSNHeader.Add("CGST%");
            HSNHeader.Add("Amt");
            HSNHeader.Add("SGST%");
            HSNHeader.Add("Amt");
            HSNHeader.Add("IGST%");
            HSNHeader.Add("Amt");


        }


        public void LoadtableData()
        {

            productInfo = new DataTable();
            productInfo.Columns.Add("SL.NO");
            productInfo.Columns.Add("Product");
            productInfo.Columns.Add("Quantity");
            productInfo.Columns.Add("MRP");
            productInfo.Columns.Add("Total");
            productInfo.Columns.Add("Description");

            for (int i = 0; i < ProductInfoAdapter.ProductInfoAdapterList().Count; i++)
            {
                productInfo.Rows.Add(ProductInfoAdapter.ProductInfoAdapterList()[i].SL_No,
                ProductInfoAdapter.ProductInfoAdapterList()[i].ProductName,
                 ProductInfoAdapter.ProductInfoAdapterList()[i].Quantity,
               ProductInfoAdapter.ProductInfoAdapterList()[i].MRP,
              ProductInfoAdapter.ProductInfoAdapterList()[i].Total,
              ProductInfoAdapter.ProductInfoAdapterList()[i].Description);
            }



        }
        //Creates a new PDF document
        PdfDocument document = new PdfDocument();
        PdfPage page;
        PdfGraphics graphics;
        PdfLayoutResult result;
        PdfFont subHeadingFont;
        RectangleF bound;
        int count_of_page = 0;
        public void createRectangle()
        {
            count_of_page += 1;

            //Adds page settings
            document.PageSettings.Orientation = PdfPageOrientation.Portrait;
            document.PageSettings.Margins.All = 50;
            //Adds a page to the document
            page = document.Pages.Add();
            graphics = page.Graphics;

           // if (count_of_page > 1)
           // {
              //  result = new PdfLayoutResult(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 100));
             //   bound = new RectangleF(0, result.Bounds.Bottom - 50, graphics.ClientSize.Width, 250);
           // }
           // else
           // {
                result = new PdfLayoutResult(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 180));
                bound = new RectangleF(0, result.Bounds.Bottom + 15, graphics.ClientSize.Width, 250);
           // }

            subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            //Draw Rectangle place on location


            graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(Color.AliceBlue)), bound);
            //document.Watermark = null;
            //Loads the image from disk

        }



        public void DrawTable()
        {


            createRectangle();

            DrawHeader();
            createHeaderWithVerticleLine();


            LoadTableContent();

            DrawFooter();
            DrawHSN();

            DrawFooterValue();
            //Save and close the PDF document 
            document.Save("D:\\Visual Studio Test Projects\\Output.pdf");
            document.Close(true);
            //Close the document

            ////This will open the PDF file and the result will be seen in the default PDF Viewer
            Process.Start("D:\\Visual Studio Test Projects\\Output.pdf");




        }
        RectangleF footerbound;
        public void DrawFooter()
        {
            //footer code


            //draw footer rectangle
            footerbound = new RectangleF(0, bound.Bottom, graphics.ClientSize.Width, 30);
            graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(Color.AliceBlue)), footerbound);

            //draw footer line Horizontal end1
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, bound.Bottom), new PointF(graphics.ClientSize.Width, bound.Bottom));

            //draw footer line Horizontal end2
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, bound.Bottom + 30), new PointF(graphics.ClientSize.Width, bound.Bottom + 30));

            //draw footer verticle line

            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, footerbound.Top), new PointF(0, footerbound.Bottom));
            float footerVerticle_x = 0;
            for (int i = 0; i < 4; i++)
            {
                footerVerticle_x += graphics.ClientSize.Width / 4;

                if (i == 0)
                {
                    footerVerticle_x = footerVerticle_x - 90;


                }
                else if (i == 1)
                {
                    footerVerticle_x = footerVerticle_x + 160;

                    //draw total
                    PdfTextElement total = new PdfTextElement("Total ", new PdfStandardFont(PdfFontFamily.TimesRoman, 15));
                    total.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
                    result = total.Draw(page, new PointF(footerVerticle_x - 60, footerbound.Top + 9));
                }
                else if (i == 2)
                {
                    footerVerticle_x = footerVerticle_x - 80;

                }
                else if (i == 3)
                {
                    // footerVerticle_x = footerVerticle_x - 40;
                    footerVerticle_x = footerVerticle_x - 70;
                    PdfTextElement total = new PdfTextElement("1560 ", new PdfStandardFont(PdfFontFamily.TimesRoman, 15));
                    total.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
                    result = total.Draw(page, new PointF(footerVerticle_x + 10, footerbound.Top + 9));
                }

                graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(footerVerticle_x, footerbound.Top), new PointF(footerVerticle_x, footerbound.Bottom));
            }


        }

        public void createHeaderWithVerticleLine()
        {
            //Draw Header line1

            PointF startHBegin = new PointF(0, bound.Top);
            PointF endHBegin = new PointF(graphics.ClientSize.Width, bound.Top);
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), startHBegin, endHBegin);


            //draw Header Horizontal Line2
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, bound.Top + 30), new PointF(graphics.ClientSize.Width, bound.Top + 30));

            //draw verticle line 1
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, bound.Top), new PointF(0, bound.Bottom));


            //Draw Bill header
            PdfTextElement element = new PdfTextElement("SL.NO ", new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
            element.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            result = element.Draw(page, new PointF(5, bound.Top + 9));

            float startX_vertical = 0;
            float endX_vertical = 0;


            for (int i = 0; i < 4; i++)
            {
                startX_vertical += graphics.ClientSize.Width / 4;
                endX_vertical += graphics.ClientSize.Width / 4;

                if (i == 0)
                {
                    startX_vertical = startX_vertical - 90;
                    endX_vertical = endX_vertical - 90;

                }
                else if (i == 1)
                {
                    startX_vertical = startX_vertical + 160;
                    endX_vertical = endX_vertical + 160;

                }
                else if (i == 2)
                {
                    startX_vertical = startX_vertical - 80;
                    endX_vertical = endX_vertical - 80;
                }
                else if (i == 3)
                {
                    startX_vertical = startX_vertical - 70;
                    endX_vertical = endX_vertical - 70;
                }

                graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(startX_vertical, bound.Top), new PointF(endX_vertical, bound.Bottom));

                //Draw Header
                PdfTextElement elementH = new PdfTextElement(tableHeader[i], new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                elementH.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
                result = elementH.Draw(page, new PointF(startX_vertical + 5, bound.Top + 9));


            }

        }

        public void LoadTableContent()
        {
            //load Table data
            //If table reaches max fit load table data in second page
            float tableX_value = 0;
            float tableY_value = bound.Top + 45;
            float productX_value = 0;
            float productY_value = 0;
            float space_in_page = 0;
            PdfTextElement elementContent;
            int i_value = 0;



            space_in_page = 410;


            for (int i = 0; i < productInfo.Rows.Count; i++)
            {
                tableX_value = 0;

                if (tableY_value > space_in_page)
                {
                    i_value = i;

                    // elementContent = new PdfTextElement("Continued..", new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
                    // elementContent.Brush = new PdfSolidBrush(new PdfColor(Color.Black));



                    //result = elementContent.Draw(page, new PointF(tableX_value + 40, space_in_page + 18));

                  //  DrawFooterValue();
                    DrawFooter();
                    DrawFooterValue();
                    createRectangle();
                    DrawHeader();
                    createHeaderWithVerticleLine();
                    
                   
                    // space_in_page = 0;
                    //space_in_page = 270;

                    //reload data

                    tableY_value = 0;
                    tableY_value = bound.Top + 45;
                    i--;


                }
                else
                {


                    for (int j = 0; j < 6; j++)
                    {


                        if (j == 5)
                        {

                            if (!productInfo.Rows[i][j].ToString().Equals(""))
                            {
                                if (productInfo.Rows[i][j].ToString().Length > 50)
                                {

                                    string diff1 = productInfo.Rows[i][j].ToString().Substring(0, 50);
                                    elementContent = new PdfTextElement(diff1, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
                                    tableY_value = tableY_value + 20;
                                    result = elementContent.Draw(page, new PointF(productX_value, tableY_value));

                                    int remaining = productInfo.Rows[i][j].ToString().Length - 50;
                                    if (remaining < 50)
                                    {
                                        string diff2 = productInfo.Rows[i][j].ToString().Substring(50, remaining);
                                        elementContent = new PdfTextElement(diff2, new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                                        tableY_value = tableY_value + 20;
                                        result = elementContent.Draw(page, new PointF(productX_value, tableY_value));
                                    }
                                    else
                                    {

                                        for (int k = 0; k < 2; k++)
                                        {

                                            string diff2 = "";


                                            if (k == 1)
                                            {
                                                diff2 = productInfo.Rows[i][j].ToString().Substring(100);
                                            }
                                            else
                                            {
                                                diff2 = productInfo.Rows[i][j].ToString().Substring(50, 50);
                                            }
                                            elementContent = new PdfTextElement(diff2, new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                                            tableY_value = tableY_value + 20;
                                            result = elementContent.Draw(page, new PointF(productX_value, tableY_value));

                                            remaining = remaining - diff2.Length;

                                        }



                                    }



                                }
                                else
                                {

                                    elementContent = new PdfTextElement(productInfo.Rows[i][j].ToString(), new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                                    tableY_value = tableY_value + 20;
                                    result = elementContent.Draw(page, new PointF(productX_value, tableY_value));

                                }

                            }
                            else
                            {
                                elementContent = new PdfTextElement(productInfo.Rows[i][j].ToString(), new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                                result = elementContent.Draw(page, new PointF(tableX_value, tableY_value));
                            }


                        }


                        else
                        {

                            elementContent = new PdfTextElement(productInfo.Rows[i][j].ToString(), new PdfStandardFont(PdfFontFamily.TimesRoman, 11));
                            elementContent.Brush = new PdfSolidBrush(new PdfColor(Color.Black));

                            if (j == 0)
                            {
                                //tableX_value += 40;
                                tableX_value += 20;
                            }
                            if (j == 1)
                            {
                                tableX_value -= 100;
                                productX_value = tableX_value;
                            }
                            else if (j == 2)
                            {
                                tableX_value += 170;
                            }
                            else if (j == 3)
                            {
                                tableX_value -= 90;
                            }

                            else if (j == 4)
                            {
                                tableX_value -= 60;
                            }

                            result = elementContent.Draw(page, new PointF(tableX_value, tableY_value));
                        }


                        tableX_value += graphics.ClientSize.Width / 4;




                    }

                    tableY_value += 25;
                    productY_value = tableY_value;


                }


            }
        }

        RectangleF HSNbound;
        public void DrawHSN()
        {
            //draw footer rectangle
            RectangleF HSNbound = new RectangleF(0, footerbound.Bottom + 10, graphics.ClientSize.Width, 80);
            graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(Color.AliceBlue)), HSNbound);

            //draw HSN line Horizontal top end1
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, HSNbound.Top), new PointF(graphics.ClientSize.Width, HSNbound.Top));

            //draw HSN line Horizontal top end2
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, HSNbound.Top + 20), new PointF(graphics.ClientSize.Width, HSNbound.Top + 20));

            //draw HSN verticle line

            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, HSNbound.Top), new PointF(0, HSNbound.Bottom));

            PdfTextElement C1 = new PdfTextElement("Rate ", new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            C1.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            result = C1.Draw(page, new PointF(10, HSNbound.Top + 5));

            //draw HSN line Horizontal bootom end1
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, HSNbound.Bottom), new PointF(graphics.ClientSize.Width, HSNbound.Bottom));


        


            float footerVerticle_x = 0;
            float HSNVerticle_x = 0;
            for (int i = 1; i < 8; i++)
            {
                HSNVerticle_x += HSNbound.Width / 8;


                PdfTextElement C2 = new PdfTextElement(HSNHeader[i], new PdfStandardFont(PdfFontFamily.TimesRoman, 11));
                C2.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
                result = C2.Draw(page, new PointF(HSNVerticle_x + 20, HSNbound.Top + 7));


                graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(HSNVerticle_x, HSNbound.Top), new PointF(HSNVerticle_x, HSNbound.Bottom));

             
            }
        }

        public void DrawHeader()
        {
            //organization name
            PdfTextElement org_name = new PdfTextElement(organization_name, new PdfStandardFont(PdfFontFamily.TimesRoman, 15));
            org_name.Brush = new PdfSolidBrush(new PdfColor(Color.Red));
            float screen_center = graphics.ClientSize.Width / 2;
            result = org_name.Draw(page, new PointF(screen_center - 40, result.Bounds.Top));


            PdfImage image = PdfImage.FromFile("D:\\Visual Studio Test Projects\\company_logo.png");
            //Draws the image to the PDF page
            page.Graphics.DrawImage(image, new RectangleF(0, 0, 50, 40));

            // shop address 
            PdfTextElement shop_add1 = new PdfTextElement(shop_address, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            shop_add1.Brush = new PdfSolidBrush(new PdfColor(Color.Black));

            shop_add1.Draw(page, new PointF(100, result.Bounds.Top + 20));


            // phone number
            PdfTextElement phone_number = new PdfTextElement("Phone:" + phone, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            phone_number.Brush = new PdfSolidBrush(new PdfColor(Color.Black));

            phone_number.Draw(page, new PointF(10, result.Bounds.Top + 50));

            //  GSTIN_number
            PdfTextElement GSTIN_number = new PdfTextElement("GSTIN:" + gstin, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            GSTIN_number.Brush = new PdfSolidBrush(new PdfColor(Color.Black));

            GSTIN_number.Draw(page, new PointF(graphics.ClientSize.Width - 150, result.Bounds.Top + 50));


            //draw Main Header break H1
            float header_line = result.Bounds.Top + 70;
            graphics.DrawLine(new PdfPen(new PdfColor(126, 151, 173), 0.70f), new PointF(0, header_line), new PointF(graphics.ClientSize.Width, header_line));




            //content after line

            // line1 begin -party name
            PdfTextElement party = new PdfTextElement("To:" + party_name, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            party.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            party.Draw(page, new PointF(10, header_line + 20));

            // line1 end -Reference
            PdfTextElement reference_no = new PdfTextElement("Reference:" + reference, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            reference_no.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            reference_no.Draw(page, new PointF(graphics.ClientSize.Width - 150, header_line + 20));



            // line1 begin -address_line1 
            PdfTextElement address_line1 = new PdfTextElement(add_line1, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            address_line1.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            address_line1.Draw(page, new PointF(25, header_line + 40));

            // line1 end -Date
            PdfTextElement date = new PdfTextElement("Date:" + Date, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            date.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            date.Draw(page, new PointF(graphics.ClientSize.Width - 150, header_line + 40));



            // line1 begin -address_line2
            PdfTextElement address_line2 = new PdfTextElement(add_line2, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            address_line2.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            address_line2.Draw(page, new PointF(25, header_line + 60));

            // line1 end -payment
            PdfTextElement payment_type = new PdfTextElement("Payment:" + payment, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            payment_type.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            payment_type.Draw(page, new PointF(graphics.ClientSize.Width - 150, header_line + 60));



            // line1 begin -address_line2
            PdfTextElement city_name = new PdfTextElement(city + "  PIN:" + pin_number, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            city_name.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            city_name.Draw(page, new PointF(25, header_line + 80));

            // line1 end -payment
            PdfTextElement place_of_Supply = new PdfTextElement("Place Of Supply:" + place_of_supply, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            place_of_Supply.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            place_of_Supply.Draw(page, new PointF(graphics.ClientSize.Width - 150, header_line + 80));
        }

        public void DrawFooterValue()
        {
            //footer value
            PdfTextElement footervalue = new PdfTextElement("for " + organization_name, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            footervalue.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
           footervalue.Draw(page, new PointF(graphics.ClientSize.Width - 150, result.Bounds.Bottom + 100));


            PdfTextElement footervalue1 = new PdfTextElement("Authorised Signatory", new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
            footervalue1.Brush = new PdfSolidBrush(new PdfColor(Color.Black));
            result = footervalue1.Draw(page, new PointF(graphics.ClientSize.Width - 150, result.Bounds.Bottom + 150));
        }
    
    }
}
