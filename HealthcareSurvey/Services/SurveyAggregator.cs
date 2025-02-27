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
            var staffCourtesyRating = survey.GetRating(SurveyCategory.StaffCourtesy);
            var waitTimesRating = survey.GetRating(SurveyCategory.WaitTimes);
            var facilityCleanlinessRating = survey.GetRating(SurveyCategory.FacilityCleanliness);

            var staffCourtesyWeight = 0.0m;
            var waitTimesWeight = 0.3m;
            var facilityCleanWeight = 0.4m;

            var weightedSum = 
                staffCourtesyRating * staffCourtesyWeight +
                waitTimesRating * waitTimesWeight +
                facilityCleanlinessRating * facilityCleanWeight;

            return weightedSum;
        }
    }
}
