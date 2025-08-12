public class HealthSystemApp
{
    private Repository<Patient> _patientRepo;
    private Repository<Prescription> _prescriptionRepo;
    private Dictionary<int, List<Prescription>> _prescriptionMap;

    public HealthSystemApp()
    {
        _patientRepo = new Repository<Patient>();
        _prescriptionRepo = new Repository<Prescription>();
        _prescriptionMap = new Dictionary<int, List<Prescription>>();
    }

    public void SeedData()
    {
        // Add 2–3 Patient objects
        _patientRepo.Add(new Patient(1, "John Doe", 35, "Male"));
        _patientRepo.Add(new Patient(2, "Jane Smith", 28, "Female"));
        _patientRepo.Add(new Patient(3, "Bob Johnson", 42, "Male"));

        // Add 4–5 Prescription objects
        _prescriptionRepo.Add(new Prescription(101, 1, "Aspirin", DateTime.Now.AddDays(-5)));
        _prescriptionRepo.Add(new Prescription(102, 1, "Ibuprofen", DateTime.Now.AddDays(-3)));
        _prescriptionRepo.Add(new Prescription(103, 2, "Paracetamol", DateTime.Now.AddDays(-7)));
        _prescriptionRepo.Add(new Prescription(104, 2, "Vitamin D", DateTime.Now.AddDays(-2)));
        _prescriptionRepo.Add(new Prescription(105, 3, "Antibiotics", DateTime.Now.AddDays(-1)));
    }

    public void BuildPrescriptionMap()
    {
        List<Prescription> allPrescriptions = _prescriptionRepo.GetAll();

        foreach (Prescription prescription in allPrescriptions)
        {
            if (!_prescriptionMap.ContainsKey(prescription.PatientId))
            {
                _prescriptionMap[prescription.PatientId] = new List<Prescription>();
            }
            _prescriptionMap[prescription.PatientId].Add(prescription);
        }
    }

    public void PrintAllPatients()
    {
        List<Patient> patients = _patientRepo.GetAll();
        foreach (Patient patient in patients)
        {
            Console.WriteLine($"Patient ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
        }
    }

    public List<Prescription> GetPrescriptionsByPatientId(int patientId)
    {
        if (_prescriptionMap.ContainsKey(patientId))
        {
            return _prescriptionMap[patientId];
        }
        return new List<Prescription>();
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
        List<Prescription> prescriptions = GetPrescriptionsByPatientId(patientId);
        foreach (Prescription prescription in prescriptions)
        {
            Console.WriteLine($"Prescription ID: {prescription.Id}, Medication: {prescription.MedicationName}, Date: {prescription.DateIssued:yyyy-MM-dd}");
        }
    }
}