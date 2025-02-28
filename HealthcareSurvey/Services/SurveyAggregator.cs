using HealthcareSurvey.Models;

namespace HealthcareSurvey.Services
{
    /// <summary>
    /// Combines ratings from different categories into a single "experience score."
    /// </summary>
    public class SurveyAggregator(PatientSurvey survey)
    {
        private readonly PatientSurvey _survey = survey;

        /// <summary>
        /// Calculates the overall score based on ratings from different categories.
        /// </summary>
        public decimal CalculateOverallScore()
        {
            var staffCourtesyRating = _survey.GetRating(SurveyCategory.StaffCourtesy);
            var waitTimesRating = _survey.GetRating(SurveyCategory.WaitTimes);
            var facilityCleanlinessRating = _survey.GetRating(SurveyCategory.FacilityCleanliness);

            var staffCourtesyWeight = 0.3m;
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
