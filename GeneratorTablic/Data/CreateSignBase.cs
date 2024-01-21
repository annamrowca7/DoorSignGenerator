using GeneratorTablic.Data;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

// CreateSignBase.cs
namespace GeneratorTablic.Data;

public class CreateSignBase : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; }

    [Inject] protected PdfService PdfService { get; set; }
    protected RoomSign RoomSign { get; set; } = new RoomSign();

    protected virtual void CreateSign()
    {
        string json = JsonConvert.SerializeObject(RoomSign);

        // Ustal ścieżkę do miejsca zapisu pliku (możesz dostosować według swoich potrzeb)
        string filePath = "C:\\Users\\annam\\Documents\\studia\\4 rok\\GeneratorTablic\\GeneratorTablic\\JsonFiles";

        // Zapisz dane do pliku
        // File.WriteAllText(filePath, json);
        var pdfBytes = PdfService.GeneratePdf(RoomSign);

        var pdfFileName = "RoomSign.pdf";
        var pdfFilePath = Path.Combine(filePath, pdfFileName);
        File.WriteAllBytes(pdfFilePath, pdfBytes);
        NavigationManager.NavigateTo("/createdsuccessfully");
    }
}