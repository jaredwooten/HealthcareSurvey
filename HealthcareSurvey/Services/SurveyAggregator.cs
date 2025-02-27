using HealthcareSurvey.Models;

namespace HealthcareSurvey.Services
{
    /// <summary>
    /// Combines ratings from different categories into a single "experience score."
    /// </summary>
    public static class SurveyAggregator
    {
        /// <summary>
        /// A bug currently exists in how we handle weighting for Staff Courtesy. 
        /// We also want to add a new feature to allow dynamic weighting or new categories.
        /// </summary>
        public static decimal CalculateOverallScore(PatientSurvey survey)
        {
            // NOTE: This is a simplistic approach, with "magic numbers" for weighting.
            // We want to refactor this into a design that’s easier to modify and test.

            // The intended logic:
            //   Staff Courtesy (weight 0.3)
            //   Wait Times (weight 0.3)
            //   Facility Cleanliness (weight 0.4)
            // Then we sum each rating * weighting, and normalize or scale to some final range (e.g., out of 5).
            
            // The bug: Staff Courtesy weighting is being ignored 
            // (or incorrectly used as 0.0m instead of 0.3m).

            decimal staffCourtesyRating = survey.GetRating(SurveyCategory.StaffCourtesy);
            decimal waitTimesRating = survey.GetRating(SurveyCategory.WaitTimes);
            decimal facilityCleanlinessRating = survey.GetRating(SurveyCategory.FacilityCleanliness);

            // BUG: staffCourtesyWeight is incorrectly set to 0.0m
            decimal staffCourtesyWeight = 0.0m;       // Should be 0.3m
            decimal waitTimesWeight = 0.3m;
            decimal facilityCleanWeight = 0.4m;

            // Weighted sum
            var weightedSum = 
                (staffCourtesyRating * staffCourtesyWeight) +
                (waitTimesRating * waitTimesWeight) +
                (facilityCleanlinessRating * facilityCleanWeight);

            // If we want a final score out of 5, we might do:
            // (Sum of ratings * weight) / (Sum of weights) * 5
            // But for simplicity, let’s just keep it in the range [0..5].
            // We'll do a naive approach: just treat the weighted sum as is for now.

            return weightedSum; // This is likely far less than expected due to the staff courtesy bug
        }
    }
}
