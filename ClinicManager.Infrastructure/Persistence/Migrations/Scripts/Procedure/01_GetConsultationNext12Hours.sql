CREATE OR ALTER PROCEDURE GetConsultationNext12Hours
AS
BEGIN
    
    SELECT 
	  P.FirstName AS NamePatient
	 ,P.Email AS EmailPatient
	 ,S.Name  AS ServiceName
	 ,S.Description AS ServiceDescription
	 ,D.FirstName AS NameDoctor
	 ,D.Email AS EmailDoctor
	 ,C.Healthinsurance AS HealthyPlan
	 ,C.Start AS StartDate
	 ,C.[End] AS FinishDate
	 ,C.TypeService AS TypeService
	FROM [Care] AS C
	INNER JOIN [Patients] AS P ON P.Id = C.PatientId
	INNER JOIN [Services] AS S ON S.Id = C.ServiceId
	INNER JOIN [Doctors] AS D ON D.Id = C.DoctorId
    --WHERE DATEDIFF(HOUR, GETDATE(), [Start]) <= 12 AND C.[Active] = 1;
	WHERE DATEDIFF(HOUR, '2024-07-28 00:00:00', [Start]) <= 24 AND C.[Active] = 1;

END;
GO
