namespace GeneratorTablic.Data;

// PdfService.cs
using DinkToPdf;
using DinkToPdf.Contracts;

public class PdfService
{
    private readonly IConverter _pdfConverter;

    public PdfService(IConverter pdfConverter)
    {
        _pdfConverter = pdfConverter;
    }

    public byte[] GeneratePdf(RoomSign roomSign)
    {
        var htmlContent = GetHtmlContent(roomSign);

        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = htmlContent,
        };

        var pdf = _pdfConverter.Convert(new HtmlToPdfDocument
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings },
        });

        return pdf;
    }

    public byte[] GeneratePdfPreview(RoomSign roomSign)
    {
        var document = new HtmlToPdfDocument
        {
            Objects =
            {
                new ObjectSettings
                {
                    HtmlContent = GetHtmlContent(roomSign)
                }
            }
        };

        return _pdfConverter.Convert(document);
    }

//to jest absolutnie basic wzor ale znowu - za frontem nie przepadam 
    private string GetHtmlContent(RoomSign roomSign)
    {
        var roomNumberStyle = "color: {roomSign.RoomNumberFont.Color}; font-size: {roomSign.RoomNumberFont.Size}px;";
        var logoStyle = "";

        switch (roomSign.LogoPosition.Alignment)
        {
            case PositionAlignment.Left:
                logoStyle += "float: left; margin-right: 10px;";
                break;
            case PositionAlignment.Middle:
                logoStyle += "display: block; margin-left: auto; margin-right: auto;";
                break;
            case PositionAlignment.Right:
                logoStyle += "float: right; margin-left: 10px;";
                break;
        }

        var textAlignStyle = "";

        switch (roomSign.LogoPosition.Alignment)
        {
            case PositionAlignment.Left:
                textAlignStyle = "text-align: left;";
                break;
            case PositionAlignment.Middle:
                textAlignStyle = "text-align: center;";
                break;
            case PositionAlignment.Right:
                textAlignStyle = "text-align: right;";
                break;
        }


        var htmlContent = $@"
            <div class=""a4-page"" style=""{textAlignStyle}"">
                <div style=""position: relative;"">
                    <img src=""{roomSign.LogoPath}"" alt=""Logo"" style=""width: {roomSign.LogoPosition.Size}px; height: auto; {logoStyle}"" />
                    <div style=""clear: both;""></div>
                </div>
                <div>
                    <h2 style=""color: {roomSign.RoomNumberFont.Color}; font-size: {roomSign.RoomNumberFont.Size}px; font-family: {roomSign.RoomNumberFont.FontName}"">Room Number: {roomSign.RoomNumber}</h2>
                </div>
                <div>
                    <h3>Assigned People:</h3>
                    <ul>";

        foreach (var person in roomSign.AssignedPeople)
        {
            htmlContent += $"<li>{person}</li>";
        }

        htmlContent += @"
                    </ul>
                </div>
            </div>";

        return htmlContent;
    }
}