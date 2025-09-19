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

            var totalWeight = 0m;
            var weightedSum = 0m;

            if (staffCourtesyRating > 0)
            {
                weightedSum += staffCourtesyRating * 0.3m;
                totalWeight += 0.3m;
            }
            if (waitTimesRating > 0)
            {
                weightedSum += waitTimesRating * 0.3m;
                totalWeight += 0.3m;
            }
            if (facilityCleanlinessRating > 0)
            {
                weightedSum += facilityCleanlinessRating * 0.4m;
                totalWeight += 0.4m;
            }

            return totalWeight > 0 ? weightedSum / totalWeight : 0;
        }

        /// <summary>
        /// Gets a summary of all ratings
        /// </summary>
        public string GetRatingSummary()
        {
            var staff = _survey.GetRating(SurveyCategory.StaffCourtesy);
            var wait = _survey.GetRating(SurveyCategory.WaitTimes);
            var facility = _survey.GetRating(SurveyCategory.FacilityCleanliness);

            return $"Staff: {staff}, Wait: {wait}, Facility: {facility}";
        }
    }
}
