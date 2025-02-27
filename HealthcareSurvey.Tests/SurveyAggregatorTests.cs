using HealthcareSurvey.Models;
using HealthcareSurvey.Services;

namespace HealthcareSurvey.Tests
{
    public class SurveyAggregatorTests
    {
        [Fact]
        public void CalculateOverallScore_BasicScenario_ReturnsExpectedScore()
        {
            var survey = new PatientSurvey("PatientA");
            survey.SetRating(SurveyCategory.StaffCourtesy, 5);
            survey.SetRating(SurveyCategory.WaitTimes, 3);
            survey.SetRating(SurveyCategory.FacilityCleanliness, 4);

            var result = SurveyAggregator.CalculateOverallScore(survey);

            Assert.Equal(4.0m, result);
        }

        // Additional test ideas:
        // - Test with varied ratings
        // - Test no rating set for a category
        // - Test adding new categories or dynamic weighting
    }
}