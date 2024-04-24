namespace shared.Model;

public class PN : Ordination {
	public double antalEnheder { get; set; }
    public List<Dato> dates { get; set; } = new List<Dato>();

    public PN (DateTime startDen, DateTime slutDen, double antalEnheder, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen) {
		this.antalEnheder = antalEnheder;
	}

    public PN() : base(null!, new DateTime(), new DateTime()) {
    }

    /// <summary>
    /// Registrerer at der er givet en dosis på dagen givesDen
    /// Returnerer true hvis givesDen er inden for ordinationens gyldighedsperiode og datoen huskes
    /// Returner false ellers og datoen givesDen ignoreres
    /// </summary>
    public bool givDosis(Dato givesDen) {

        if (givesDen.dato >= startDen && givesDen.dato <= slutDen)
        {
            // Add the given date to the list of dates when doses were given
            dates.Add(givesDen);
            return true;
        }
        else
        {
            // The provided date is not within the validity period, so ignore it
            return false;
        }
    }

    public override double doegnDosis() {
        int totalDays = (slutDen - startDen).Days + 1;

        // Calculate the total number of doses given
        int totalDosesGiven = dates.Count;

        // Calculate the average daily dose
        double averageDailyDose = totalDosesGiven / (double)totalDays;

        return averageDailyDose;
    }


    public override double samletDosis() {
        return dates.Count() * antalEnheder;
    }

    public int getAntalGangeGivet() {
        return dates.Count();
    }

	public override String getType() {
		return "PN";
	}
}
