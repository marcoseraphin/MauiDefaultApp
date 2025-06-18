using System.Diagnostics;
using MauiDefaultApp.Interfaces;

namespace MauiDefaultApp.Services;

public class DiagnosticService() : IDiagnosticService
{

    public void WriteException(Exception exception)
    {
        //SentrySdk.CaptureException(exception);
#if DEBUG
        Debug.WriteLine(exception.Message);
#endif
    }
}