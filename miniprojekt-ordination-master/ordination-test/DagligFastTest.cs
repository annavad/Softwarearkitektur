using Data;
using Microsoft.EntityFrameworkCore;
using Service;
using shared.Model;

namespace ordination_test.Model;

[TestClass]
public class DagligFastTest

{
    private DataService service;


    [TestInitialize]
    public void SetupBeforeEachTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrdinationContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName: "test-database");
        var context = new OrdinationContext(optionsBuilder.Options);
        service = new DataService(context);
        service.SeedData();
    }

    [TestMethod]
    public void DoegnDosis_()
    {
        var fakeMorgenDosis = 1;
        var fakeMiddagDosis = 2;
        var fakeAftenDosis = 3;
        var fakeNatDosis = 4;

        var dagligFast = new DagligFast(new DateTime(2024, 1, 10), new DateTime(2024, 1, 12),
            new Laegemiddel("Acetylsalicylsyre", 0.1, 0.15, 0.16, "Styk"), fakeMorgenDosis, fakeMiddagDosis,
            fakeAftenDosis, fakeNatDosis);

        var result = dagligFast.doegnDosis();

        
       Assert.AreEqual(3.33, result, 0.01);
    }

    [TestMethod]

    public void Paracetamol_Undervægtig()
    {
      
        {
            
            var patientId = 1; 
            var laegemiddelId = 1; 
            

            var patient = new Patient { PatientId = patientId, vaegt = 20 }; 
            var lægemiddel = new Laegemiddel { LaegemiddelId = laegemiddelId, enhedPrKgPrDoegnLet = 0.5 }; 

            db.AddPatient(patient);
            db.AddLægemiddel(lægemiddel);

            
            var result = db.GetAnbefaletDosisPerDøgn(patientId, laegemiddelId);

            
            Assert.AreEqual(22, result); 
        }

    }



    [TestMethod]

    public void Paracetamol_Mellemvægtig()
    {

    }




    [TestMethod]

    public void Paracetamol_Overvægtig()
    {

    }





    [TestMethod]

    public void Methotrexat_Undervægtig()
    {
        
    }




    [TestMethod]

    public void Methotrexat_Mellemvægtig()
    {

    }




    [TestMethod]

    public void Methotrexat_Overvægtig()
    {

    }
}