using HealthcareSurvey.Models;
using HealthcareSurvey.Services;

namespace HealthcareSurvey.Tests
{
    public class SurveyAggregatorTests
    {
        [Fact]
        public void CalculateOverallScore_BasicScenario_ReturnsExpectedScore()
        {
            // Arrange
            var survey = new PatientSurvey("PatientA");
            survey.SetRating(SurveyCategory.StaffCourtesy, 5);
            survey.SetRating(SurveyCategory.WaitTimes, 3);
            survey.SetRating(SurveyCategory.FacilityCleanliness, 4);

            // Act
            var result = SurveyAggregator.CalculateOverallScore(survey);

            // BUG: We expect a certain result, but we’ll see it's off because staffCourtesyWeight = 0.0
            // Suppose we intended:
            //   staffCourtesyWeight = 0.3
            //   waitTimesWeight = 0.3
            //   facilityCleanWeight = 0.4
            // Weighted sum => (5*0.3) + (3*0.3) + (4*0.4) = 1.5 + 0.9 + 1.6 = 4.0
            // But with staffCourtesyWeight=0.0, result is 2.5
            // Let's place an assertion for what we *expected* to see if the aggregator was correct.

            Assert.Equal(4.0m, result);
        }

        // Additional test ideas:
        // - Test with varied ratings
        // - Test no rating set for a category
        // - Test adding new categories or dynamic weighting
    }
}