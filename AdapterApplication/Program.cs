using DatabaseReader;
using DataToJsonAdaptor;
using JSONDataPrinter;

DbReader dbReader = new();
IJsonTarget jsonTarget = new DatabaseToJsonAdapter(dbReader);
try
{
    dbReader.ConnectToDataSource();
    JsonDataPrinter jsonDataPrinter = new(jsonTarget);
    jsonDataPrinter.DisplayVehicleInfo();
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to read data {ex.Message}");
}
finally
{
    if (dbReader != null)
        dbReader.Disconnect();
}
