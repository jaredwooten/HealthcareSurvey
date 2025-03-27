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
            var aggregator = new SurveyAggregator(survey);

            var result = aggregator.CalculateOverallScore();

            Assert.Equal(4.0m, result);
        }

        [Fact]
        public void CalculateOverallScore_VariedRatings_ReturnsExpectedScore()
        {
            var survey = new PatientSurvey("PatientB");
            survey.SetRating(SurveyCategory.StaffCourtesy, 2);
            survey.SetRating(SurveyCategory.WaitTimes, 4);
            survey.SetRating(SurveyCategory.FacilityCleanliness, 3);
            var aggregator = new SurveyAggregator(survey);
            
            var result = aggregator.CalculateOverallScore();

            Assert.Equal(3.0m, result);
        }

        [Fact]
        public void CalculateOverallScore_NoRatingForCategory_ReturnsExpectedScore()
        {
            var survey = new PatientSurvey("PatientC");
            survey.SetRating(SurveyCategory.StaffCourtesy, 5);
            survey.SetRating(SurveyCategory.WaitTimes, 4);
            var aggregator = new SurveyAggregator(survey);
            
            var result = aggregator.CalculateOverallScore();

            Assert.Equal(4.5m, result);
        }
    }
}