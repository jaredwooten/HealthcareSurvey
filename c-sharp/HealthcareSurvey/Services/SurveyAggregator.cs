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

            var totalWeight = 0m;
            var weightedSum = 0m;

            if (staffCourtesyRating > 0)
            {
                weightedSum += staffCourtesyRating * staffCourtesyWeight;
                totalWeight += staffCourtesyWeight;
            }
            if (waitTimesRating > 0)
            {
                weightedSum += waitTimesRating * waitTimesWeight;
                totalWeight += waitTimesWeight;
            }
            if (facilityCleanlinessRating > 0)
            {
                weightedSum += facilityCleanlinessRating * facilityCleanWeight;
                totalWeight += facilityCleanWeight;
            }

            return totalWeight > 0 ? weightedSum / totalWeight : 0;
        }

        /// <summary>
        /// Gets all the category weights
        /// </summary>
        public static Dictionary<SurveyCategory, decimal> GetCategoryWeights()
        {
            return new Dictionary<SurveyCategory, decimal>
            {
                { SurveyCategory.StaffCourtesy, 0.3m },
                { SurveyCategory.WaitTimes, 0.3m },
                { SurveyCategory.FacilityCleanliness, 0.4m }
            };
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
