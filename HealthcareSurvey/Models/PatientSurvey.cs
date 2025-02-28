
namespace HealthcareSurvey.Models
{
    public class PatientSurvey(string patientId)
    {
        public string PatientId { get; set; } = patientId;

        /// <summary>
        /// Ratings for each category (e.g., Staff Courtesy, Wait Times, Facility Cleanliness).
        /// Values typically range from 1 to 5.
        /// </summary>
        public Dictionary<SurveyCategory, int> CategoryRatings { get; set; } = [];

        public void SetRating(SurveyCategory category, int rating)
        {
            if (rating < 1) rating = 1;
            if (rating > 5) rating = 5;

            CategoryRatings[category] = rating;
        }

        public int GetRating(SurveyCategory category)
        {
            return CategoryRatings.ContainsKey(category) ? CategoryRatings[category] : 0;
        }
    }
}