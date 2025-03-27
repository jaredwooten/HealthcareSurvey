namespace HealthcareSurvey.Models
{
    public enum SurveyCategory
    {
        StaffCourtesy,
        WaitTimes,
        FacilityCleanliness,
        
        // We might add more categories, e.g., BillingExperience, TelehealthQuality, etc.
        // Also, we want to allow dynamic weighting in the future.
    }
}