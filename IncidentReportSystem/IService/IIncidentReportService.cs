using System;

public interface IIncidentReportService
{
    string IncidentLog();
    void CreateIncidentReport(Incident incident);
    Incident GetIncidentReportById(int id);
    void UpdateIncidentReport(Incident incident);
    void DeleteIncidentReport(int id);
    IEnumerable<Incident> GetAllIncidentReports();

}
