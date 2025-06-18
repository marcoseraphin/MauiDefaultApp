namespace MauiDefaultApp.Interfaces;

public interface IDiagnosticService
{
    void WriteException(Exception exception);
}