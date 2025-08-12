class Program
{
    static void Main(string[] args)
    {
        // i. Instantiate HealthSystemApp
        HealthSystemApp app = new HealthSystemApp();

        // ii. Call SeedData()
        app.SeedData();

        // iii. Call BuildPrescriptionMap()
        app.BuildPrescriptionMap();

        // iv. Print all patients
        app.PrintAllPatients();

        // v. Select one PatientId and display prescriptions
        app.PrintPrescriptionsForPatient(1);
    }
}